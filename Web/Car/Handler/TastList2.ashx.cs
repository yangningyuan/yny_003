using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// TastList2 的摘要说明
    /// </summary>
    public class TastList2 : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and IsDelete='" + context.Request["tState"] + "'";
            }
            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            {
                strWhere += " and Name like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            }
            if (!string.IsNullOrEmpty(context.Request["tcode"]))
            {
                strWhere += " and TCode='" + context.Request["tcode"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["SupplierName"]))
            {
                strWhere += " and SupplierName in (select ID from C_Supplier where Name like '%" + context.Request["SupplierName"] + "%')";
            }
            if (!string.IsNullOrEmpty(context.Request["coststate"]))
            {
                strWhere += " and TState='" + context.Request["coststate"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["TType"]))
            {
                strWhere += " and TType='" + context.Request["TType"] + "' ";
            }

            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and CreateDate>='" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and CreateDate<='" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["startDate2"]))
            {
                strWhere += " and ComDate>='" + context.Request["startDate2"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate2"]))
            {
                strWhere += " and ComDate<='" + context.Request["endDate2"] + " 23:59:59' ";
            }

            if (!string.IsNullOrEmpty(context.Request["CarSJ1"]))
            {
                strWhere += " and CarSJ1 in(select MID from Member where RoleCode='SiJi' and MName like '%" + context.Request["CarSJ1"] + "%' AND FMID='1' AND IsClock=0 AND IsClose=0) ";
            }
            if (!string.IsNullOrEmpty(context.Request["CarSJ2"]))
            {
                strWhere += " and CarSJ2 in(select MID from Member where RoleCode='SiJi' and MName like '%" + context.Request["CarSJ2"] + "%' AND FMID in('2','3') AND IsClock=0 AND IsClose=0) ";
            }
            if (!string.IsNullOrEmpty(context.Request["Spare2"]))
            {
                strWhere += " and Spare2 like '%" + context.Request["Spare2"] + "%' ";
            }
            if (!string.IsNullOrEmpty(context.Request["CSpare2"]))
            {
                strWhere += " and CSpare2 like '%" + context.Request["CSpare2"] + "%' ";
            }

            int count;
            List<Model.C_CarTast> ListNotice = BLL.C_CarTast.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].Name + "~");
                sb.Append(ListNotice[i].TCode + "~");
                sb.Append(Model.C_CarTast.typename(ListNotice[i].TType) + "~");
                sb.Append(ListNotice[i].Prot + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(BLL.C_Supplier.GetModel(Convert.ToInt32(ListNotice[i].SupplierName)).Name + "~");
                //sb.Append(ListNotice[i].SupplierTel + "~");

                sb.Append(ListNotice[i].Spare2 + "~");
                sb.Append(ListNotice[i].CSpare2 + "~");
                string goodsname = "";
                string goodscount = "";
                string goodsrecount = "";
                string goodsprice = "";
                Model.Goods goods = new Model.Goods();
                if (!string.IsNullOrEmpty(ListNotice[i].OCode)) //装车  卸车
                {
                    List<Model.OrderDetail> odlist = BLL.OrderDetail.GetList(" ordercode='" + ListNotice[i].OCode.ToString() + "'; ");
                    foreach (Model.OrderDetail item in odlist)
                    {
                        goods = BLL.Goods.GetModel(item.GId);
                        goodsname = goods.GName;
                        goodscount = item.GCount.ToString();
                        goodsrecount = item.ReCount.ToString();
                        goodsprice = item.BuyPrice.ToString();
                    }
                }
                sb.Append(goodsname + "~");
                sb.Append(goodscount + "~");
                sb.Append(goodsrecount + "~");
                //sb.Append(BLL.C_CostType.GetModel(ListNotice[i].CostType).Name + "~");
                sb.Append((ListNotice[i].CreateDate) + "~");
                sb.Append((ListNotice[i].ComDate) + "~");
                sb.Append((Model.C_CarTast.statename(ListNotice[i].TState)) + "~");
                if (ListNotice[i].TState != 2 && TModel.Role.IsAdmin)
                {
                    sb.Append("<div class=\"pay btn btn-danger\" onclick=\"celTast('" + ListNotice[i].ID + "')\">取消任务</div>");
                    //sb.Append("<div class=\"pay btn btn-success\" onclick=\"callhtml('/Car/ModifyTast.aspx?id=" +ListNotice[i].ID +"','修改任务');onclickMenu()\">修改任务</div>");
                }
                else if (ListNotice[i].TState == -1 && TModel.Role.DiaoDu)
                {
                    sb.Append("<div class=\"pay btn btn-success\" onclick=\"callhtml('/Car/DDTast.aspx?id=" + ListNotice[i].ID + "','调度');onclickMenu()\">调度</div>");
                    //sb.Append("<div class=\"pay btn btn-success\" onclick=\"callhtml('/Car/ModifyTast.aspx?id=" +ListNotice[i].ID +"','修改任务');onclickMenu()\">修改任务</div>");
                }
                if (ListNotice[i].TState == 1)
                {
                    sb.Append("<div class=\"pay btn btn-success\" onclick=\"SetBJTast('" + ListNotice[i].ID + "')\">错误标记</div>");
                }
                if (ListNotice[i].TState == -2)
                {
                    sb.Append("<div class=\"pay btn btn-danger\" onclick=\"SetCelTast('" + ListNotice[i].ID + "')\">取消标记</div>");
                }
                //装车
                if (ListNotice[i].TType == 1)
                {
                    sb.Append("<div class=\"pay btn btn-danger\" onclick=\"callhtml('/Car/TastList2.aspx?tcode=" + ListNotice[i].Name + "','装车列表');onclickMenu()\" > 装车列表</div>");
                }

                sb.Append("≌");
                sb.Append("≠");
                ////数量
                sb.Append("10");
                sb.Append("≠");
                //内容(买家信息

                Model.Member mc1 = BLL.Member.GetModelByMID(ListNotice[i].CarSJ1);
                Model.Member mc2 = BLL.Member.GetModelByMID(ListNotice[i].CarSJ2);


                sb.Append("供应商地址:" + ListNotice[i].SupplierAddress);
                sb.Append("<br/>主司机:" + (mc1 != null ? mc1.MName : ""));
                sb.Append("<br/>押运员:" + (mc2 != null ? mc2.MName : ""));

                if (!string.IsNullOrEmpty(ListNotice[i].OCode)) //装车  卸车
                {
                    sb.Append("<br/>商品订单:" + ListNotice[i].OCode);
                    if (goods != null)
                    {
                        sb.Append("<br/>实际数量:" + goodsrecount + goods.Unit);
                        sb.Append("<br/>价格:" + goodsprice);
                        sb.Append(string.Format("<br/><span style='color:black; font-size:16px;'>{0}</span>&nbsp;&nbsp;&nbsp;<span style='color:red; font-size:20px;'>{1}</span><span style='color:green;'>{2}</span>", goods.GName, goodscount, goods.Unit));
                    }
                }
                sb.Append("<br/>磅单图片:<a href='" + ListNotice[i].BDImg + "' target='blank'><img src='" + ListNotice[i].BDImg + "' width='5%' /></a>");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}