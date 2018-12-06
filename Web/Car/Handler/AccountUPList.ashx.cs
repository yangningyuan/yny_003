using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// AccountUPList 的摘要说明
    /// </summary>
    public class AccountUPList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1' and AType=0 ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and AStutas=" + context.Request["tState"] + " ";
            }
            if (!string.IsNullOrEmpty(context.Request["CName"]))
            {
                strWhere += " and CName like '%" + HttpUtility.UrlDecode(context.Request["CName"]) + "%'";
            }
            if (context.Request["SupplierName"] != "--请选择--")
            {
                strWhere += " and  SupplierID like '%" + context.Request["SupplierName"] + "%'";
            }

            if (!string.IsNullOrEmpty(context.Request["CSpare2"]))
            {
                strWhere += "AND CName in(select Name from C_CarTast  where OCode in(select OrderCode from OrderDetail where GId in(select GID from Goods where GName='" + context.Request["CSpare2"] + "'))) ";
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

            int count;
            List<Model.Account> ListNotice = BLL.Account.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                //sb.Append(ListNotice[i].Name + "~");
                
                sb.Append(ListNotice[i].CName + "~");
                sb.Append(ListNotice[i].SupplierName + "~");

                sb.Append(ListNotice[i].TotalMoney + "~");
                Model.C_CarTast tast = BLL.C_CarTast.GetModelname(ListNotice[i].CName);
                string GName = "";
                string goodsrecount = "";
                string goodsprice = "";
                string goodscount = "";
                Model.Goods g = null;
                if (!string.IsNullOrWhiteSpace(tast.OCode))
                {
                    Model.OrderDetail od = BLL.OrderDetail.GetModelCode(tast.OCode);
                    if (od != null)
                    {
                        goodsrecount = od.ReCount.ToString();
                        goodscount = od.GCount.ToString();
                        goodsprice = od.BuyPrice.ToString();
                    }
                    g = BLL.Goods.GetModel(od.GId);
                    if (g != null)
                        GName = g.GName;
                }
                sb.Append(GName + "~");
                sb.Append(ListNotice[i].OrderCount + "~");
                sb.Append(ListNotice[i].OrderPrice + "~");
                sb.Append(ListNotice[i].ReMoney + "~");
         
                sb.Append((ListNotice[i].AStutas==0? "未结账": "已结账") + "~");
                sb.Append((ListNotice[i].Spare == "1" ? "<span style='color:green;'>已开发票</span>" : "<span style='color:red;'>未开发票</span>") + "~");
                sb.Append((ListNotice[i].CreateDate) + "~");
                sb.Append((ListNotice[i].comDate) + "~");
                sb.Append((ListNotice[i].Spare2) + "~");
                if (ListNotice[i].AStutas == 0)
                {
                    //sb.Append("<div class=\"pay btn btn-success\" onclick=\"callhtml('/Car/AccountDetails.aspx?id=" + ListNotice[i].ID + "','结账');onclickMenu()\">结账</div>");
                }
                if (string.IsNullOrEmpty(ListNotice[i].Spare))
                {
                    sb.Append("<div class=\"pay btn btn-success\" onclick=\"execfp('" + ListNotice[i].ID + "')\">开发票</div>");
                }
                else {
                    sb.Append("<div class=\"pay btn btn-danger\" onclick=\"celfp('" + ListNotice[i].ID + "')\">取消发票</div>");
                }
                sb.Append("≌");
                sb.Append("≠");
                ////数量
                sb.Append("10");
                sb.Append("≠");
                //内容(买家信息

                Model.Member mc1 = BLL.Member.GetModelByMID(tast.CarSJ1);
                Model.Member mc2 = BLL.Member.GetModelByMID(tast.CarSJ2);


                sb.Append("供应商地址:" + tast.SupplierAddress);
                sb.Append("<br/>主司机:" + (mc1 != null ? mc1.MName : ""));
                sb.Append("<br/>押运员:" + (mc2 != null ? mc2.MName : ""));

                if (!string.IsNullOrEmpty(tast.OCode)) //装车  卸车
                {
                    sb.Append("<br/>商品订单:" + tast.OCode);
                    if (g != null)
                    {
                        sb.Append("<br/>实际数量:" + goodsrecount + g.Unit);
                        sb.Append("<br/>价格:" + goodsprice);
                        sb.Append(string.Format("<br/><span style='color:black; font-size:16px;'>{0}</span>&nbsp;&nbsp;&nbsp;<span style='color:red; font-size:20px;'>{1}</span><span style='color:green;'>{2}</span>", g.GName, goodscount, g.Unit));
                    }
                }
                sb.Append("<br/>磅单图片:<a href='" + tast.BDImg + "' target='blank'><img src='" + tast.BDImg + "' width='5%' /></a>");
                sb.Append("≌");

            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}