using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// LoanApplyList 的摘要说明
    /// </summary>
    public class LoanApplyList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1' ";
            if (context.Request["tState"] == "0")
            {
                strWhere += " and (SPMID is null or SPMID='') ";
            }
            else {
                strWhere += " and SPMID!='' and SPMID!=null ";
            }
            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            {
                strWhere += " and ApplyMID like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            }
            int count;
            List<Model.C_LoanApply> ListNotice = BLL.C_LoanApply.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].ApplyMID + "~");
                sb.Append(ListNotice[i].Money + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(ListNotice[i].RealMoney + "~");
                sb.Append(ListNotice[i].FFType + "~");
                sb.Append(ListNotice[i].Remark + "~");
                sb.Append(ListNotice[i].CareteDate + "~");
                sb.Append(ListNotice[i].SPMID + "~");
                sb.Append((ListNotice[i].RealDate) + "~");
                //sb.Append("<div class=\"pay btn btn-success\" onclick=\"v5.show('OJ/ObjSubList.aspx?id=" + ListNotice[i].ID + "', '查看详情', 'url', 360, 240)\">查看详情</div>");
                sb.Append("≌");

            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}