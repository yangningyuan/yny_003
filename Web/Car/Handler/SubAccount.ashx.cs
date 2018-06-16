using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// SubAccount 的摘要说明
    /// </summary>
    public class SubAccount : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " ";

            if (!string.IsNullOrEmpty(context.Request["CName"]))
            {
                strWhere += " and ACode like '%" + HttpUtility.UrlDecode(context.Request["CName"]) + "%'";
            }
            //if (context.Request["SupplierName"] != "--请选择--")
            //{
            //    strWhere += " and  SupplierID like '%" + context.Request["SupplierName"] + "%'";
            //}

            int count;
            List<Model.SubAccount> ListNotice = BLL.SubAccount.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                //sb.Append(ListNotice[i].Name + "~");

                sb.Append(ListNotice[i].ACode + "~");
                sb.Append((ListNotice[i].SuppType.ToString().Replace("1", "供应商").Replace("2", "客户")) + "~");

                sb.Append(ListNotice[i].SuppName + "~");
                sb.Append((ListNotice[i].JZType.ToString().Replace("1", "余额支付").Replace("2", "卡付")) + "~");
                sb.Append((ListNotice[i].PayMoney) + "~");
                sb.Append((ListNotice[i].UserName) + "~");

                sb.Append((ListNotice[i].CreateDate) + "~");


                sb.Append("<div class=\"pay btn btn-success\" onclick=\"ReSubAccount('" + ListNotice[i].ID + "')\">回滚</div>");

                sb.Append("≌");


            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}