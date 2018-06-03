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
            if (!string.IsNullOrEmpty(context.Request["SupplierName"]))
            {
                strWhere += " and  SupplierName like '%" + context.Request["SupplierName"] + "%'";
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
                sb.Append(ListNotice[i].ReMoney + "~");

                sb.Append((ListNotice[i].AStutas == 0 ? "未结账" : "已结账") + "~");
                sb.Append((ListNotice[i].CreateDate) + "~");
                sb.Append((ListNotice[i].comDate) + "~");

                if (ListNotice[i].AStutas == 0)
                {
                    sb.Append("<div class=\"pay btn btn-success\" onclick=\"callhtml('/Car/AccountDetailsDown.aspx?id=" + ListNotice[i].ID + "','结账');onclickMenu()\">结账</div>");
                }
                sb.Append("≌");
                sb.Append("≠");

            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}