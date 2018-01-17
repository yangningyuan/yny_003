using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.OJ.Handler
{
    /// <summary>
    /// ObjList 的摘要说明
    /// </summary>
    public class ObjList : BaseHandler
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
            int count;
            List<Model.Obj> ListNotice = BLL.Obj.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].Name + "~");
                sb.Append(ListNotice[i].Person + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(ListNotice[i].Money + "~");
                sb.Append(BLL.DepartType.GetModel(ListNotice[i].DepartID).Name + "~");
                sb.Append(ListNotice[i].StateDate + "~");
                sb.Append(ListNotice[i].EndDate + "~");
                sb.Append((ListNotice[i].State==1?"已完成":"未完成" )+ "~");
                sb.Append("<div class=\"pay btn btn-success\" onclick=\"v5.show('OJ/ObjSubList.aspx?id=" + ListNotice[i].ID + "', '查看详情', 'url', 360, 240)\">查看详情</div>");
                sb.Append("≌");

            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}