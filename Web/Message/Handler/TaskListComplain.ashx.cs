using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace zx270.Web.Handler
{
    /// <summary>
    /// TaskListComplain 的摘要说明
    /// </summary>
    public class TaskListComplain : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1'";
            string type = "";
            string mkey = "";
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }
            if (!BllModel.TModel.Role.Super)
                mkey = BllModel.TModel.MID;
            if (!string.IsNullOrEmpty(mkey))
            {
                strWhere += " and TFromMID = '" + mkey + "' ";
            }

            strWhere += " and TType = '008' ";

            int count;
            List<Model.Task> ListTask = BllModel.GetTaskEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListTask.Count; i++)
            {
                sb.Append(ListTask[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListTask[i].TFromMID + "~");
                //sb.Append(ListTask[i].TToMID + "~");
                sb.Append(ListTask[i].TContent + "~");
                sb.Append(ListTask[i].TTypeStr + "~");
                sb.Append(ListTask[i].TDateTime.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = sb.ToString(), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}