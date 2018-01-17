using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.OJ.Handler
{
    /// <summary>
    /// DepartTypeList 的摘要说明
    /// </summary>
    public class DepartTypeList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1'";
            //if (!string.IsNullOrEmpty(context.Request["tState"]))
            //{
            //    strWhere += " and State='" + context.Request["tState"] + "'";
            //}
            //if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            //{
            //    strWhere += " and Name like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            //}
            int count;
            List<Model.DepartType> ListNotice = BLL.DepartType.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].Name + "~");
                sb.Append(ListNotice[i].Remark + "");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}