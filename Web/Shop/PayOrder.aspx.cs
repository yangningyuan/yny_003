using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace yny_003.Web.Shop
{
    public partial class PayOrder : BasePage
    {
        protected Model.Order orderModel;
        protected Model.ReceiveInfo ReceiveInfoModel;

        protected override void SetValue(string id)
        {

            string oid = HttpUtility.UrlDecode(Request["id"].Trim());//订单Id
            hidId.Value = oid;
            orderModel = BLL.Order.GetModel(oid);
            ReceiveInfoModel = BLL.ReceiveInfo.GetModel(orderModel.ReceiveId);
            ViewState["OrderInfo"] = orderModel;
            Session["OrderId"] = oid;
            string gids = "";
            foreach (Model.OrderDetail od in orderModel.OrderDetail)
            {
                gids += od.GId + ",";
            }
            gids = gids.TrimEnd(',');
            var listGood = BLL.Goods.GetList("GID in (" + gids + ")");
            repGoodList.DataSource = listGood;
            repGoodList.DataBind();
        }

        protected override void SetPowerZone()
        {

        }

        protected decimal GetOrderDetailCount(object gid)
        {
            Model.Order objOrder = (Model.Order)ViewState["OrderInfo"];
            if (objOrder != null)
            {
                int goodId = Convert.ToInt32(gid);
                Model.OrderDetail od = objOrder.OrderDetail.Where(c => c.GId == goodId).FirstOrDefault();
                if (od != null)
                {
                    return od.GCount;
                }
            }
            return 0;
        }

        private object lockObj = new object();
        protected override string btnModify_Click()
        {
            lock (lockObj)
            {
                string oid = Session["OrderId"] != null ? Session["OrderId"].ToString() : "";
                //查看订单信息
                if (!string.IsNullOrEmpty(oid))
                {
                    Model.Order order = BLL.Order.GetModel(oid);
                    if (order != null)
                    {
                        decimal totaoPay = order.DisCountTotalPrice;
                        if (BLL.ChangeMoney.EnoughChange(order.MID, totaoPay, "MHB;MCW"))
                        {
                            Hashtable MyHs = new Hashtable();
                            //计算每个币种扣费多少
                            if (BLL.ChangeMoney.EnoughChange(order.MID, totaoPay, "MCW"))
                            {
                                BLL.ChangeMoney.HBChangeTran(totaoPay, TModel.MID, BLL.Member.ManageMember.TModel.MID, "GW", null, "MCW", "支付订单" + order.Code, MyHs);
                                order.Remarks = string.Format("{0}:{1}", BLL.Reward.List["MCW"].RewardName, totaoPay.ToFixedString());
                            }
                            else
                            {
                                Model.Member payMember = BLL.Member.GetModelByMID(order.MID);
                                BLL.ChangeMoney.HBChangeTran(payMember.MConfig.MCW, TModel.MID, BLL.Member.ManageMember.TModel.MID, "GW", null, "MCW", "支付订单" + order.Code, MyHs);
                                BLL.ChangeMoney.HBChangeTran(totaoPay - payMember.MConfig.MCW, TModel.MID, BLL.Member.ManageMember.TModel.MID, "GW", null, "MHB", "支付订单" + order.Code, MyHs);
                                order.Remarks = string.Format("{0}:{1}<br />{2}:{3}", BLL.Reward.List["MHB"].RewardName, (totaoPay - payMember.MConfig.MCW).ToFixedString(), BLL.Reward.List["MCW"].RewardName, payMember.MConfig.MCW.ToFixedString());
                            }
                            //库存减少
                            foreach (Model.OrderDetail od in order.OrderDetail)
                            {
                                Model.Goods good = BLL.Goods.GetModel(od.GId);
                                if (good != null)
                                {
                                    good.SelledCount = good.SelledCount + od.GCount;
                                    good.SellingCount = good.SellingCount - od.GCount;
                                    BLL.Goods.Update(good, MyHs);
                                }
                            }
                            //修改订单状态
                            order.Status = 2;
                            BLL.Order.Update(order, MyHs);
                            BLL.ChangeMoney.GWChangeTran(TModel.MID, totaoPay /** BLL.Configuration.Model.E_GWYJFloat*/, MyHs);

                            if (BLL.CommonBase.RunHashtable(MyHs))
                            {
                                Session["OrderId"] = null;
                                return "支付成功！";
                            }
                            else
                            {
                                return "支付失败，请重试！";
                            }
                        }
                        else
                        {
                            Session["OrderId"] = null;
                            return "您的余额不足，请充值后购买！";
                        }
                    }
                }
                else
                {
                    return "该订单信息出现异常，请重新进入该页面支付";
                }
                return "操作失败";
            }
        }
    }
}