using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.OJ.Handler
{
    /// <summary>
    /// ObjSubList 的摘要说明
    /// </summary>
    public class ObjSubList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1' and ISDELETE=0 ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and State='" + context.Request["tState"] + "'";
            }
            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            {
                strWhere += " and Name like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            }
            if (!string.IsNullOrEmpty(context.Request["matchid"]))
            {
                strWhere += " and ObjID=" + context.Request["matchid"] + " ";
            }
            int count;
            List<Model.ObjSub> ListNotice = BLL.ObjSub.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                //sb.Append(ListNotice[i].Name + "~");
                sb.Append(ListNotice[i].Person + "~"); 
                sb.Append(BLL.ObjSubType.GetModel(ListNotice[i].SubType).Name + "~");
                sb.Append(ListNotice[i].Money.ToString("F2") + "~");
                sb.Append(ListNotice[i].ReMoney.ToString("F2") + "~");
                sb.Append(ListNotice[i].CZFloat.ToString("F4") + "~");
                sb.Append((ListNotice[i].Money*(1+ListNotice[i].CZFloat)).ToString("f2") + "~");
                sb.Append(ListNotice[i].CreateDate.ToString("yyyy-MM-dd") + "~");
                sb.Append("<input id=\"txtZCMoney"+ListNotice[i].ID+"\" class=\"normal_input\" runat=\"server\" style=\"width: 50 %; \" />" + "~");
                sb.Append("<div class=\"pay btn btn-success\" onclick=\"zhichu("+ListNotice[i].ID+")\">支出</div>");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}