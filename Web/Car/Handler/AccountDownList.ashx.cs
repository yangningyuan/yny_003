using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// AccountDownList 的摘要说明
    /// </summary>
    public class AccountDownList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1' and AType=1 ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and AStutas=" + context.Request["tState"] + " ";
            }
            if (!string.IsNullOrEmpty(context.Request["CName"]))
            {
                strWhere += " and CName like '%" + HttpUtility.UrlDecode(context.Request["CName"]) + "%'";
            }
            if (context.Request["SupplierName"]!= "--请选择--")
            {
                strWhere += " and  SupplierID like '%" + context.Request["SupplierName"] + "%'";
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

                Model.C_CarTast tast= BLL.C_CarTast.GetModelname(ListNotice[i].CName);
                string shuliang = "";
                string jiage = "";
                if (!string.IsNullOrWhiteSpace(tast.OCode))
                {
                    Model.OrderDetail od= BLL.OrderDetail.GetModelCode(tast.OCode);
                    shuliang = od.ReCount.ToString();
                    jiage = od.BuyPrice.ToString();
                }

                sb.Append(shuliang + "~");
                sb.Append(jiage + "~");

                sb.Append(ListNotice[i].ReMoney + "~");

                sb.Append((ListNotice[i].AStutas == 0 ? "未结账" : "已结账") + "~");
                sb.Append((ListNotice[i].Spare == "1" ? "<span style='color:green;'>已开发票</span>" : "<span style='color:red;'>未开发票</span>") + "~");
                sb.Append((ListNotice[i].CreateDate) + "~");
                sb.Append((ListNotice[i].comDate) + "~");

                if (ListNotice[i].AStutas == 0)
                {
                    //sb.Append("<div class=\"pay btn btn-success\" onclick=\"callhtml('/Car/AccountDetailsDown.aspx?id=" + ListNotice[i].ID + "','结账');onclickMenu()\">结账</div>");
                }
                if (string.IsNullOrEmpty(ListNotice[i].Spare))
                {
                    sb.Append("<div class=\"pay btn btn-success\" onclick=\"execfp('" + ListNotice[i].ID + "')\">开发票</div>");
                }
                sb.Append("≌");
              

            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}