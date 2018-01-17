using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace zx270.Web.Handler
{
    /// <summary>
    /// BCenterList 的摘要说明
    /// </summary>
    public class BCenterList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            string strWhere = " MID<>''";
            string sh = " and IsValid=0 ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (context.Request["tState"] == "true")
                    sh = " and IsValid=1 ";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and MID='{0}' ", (context.Request["mKey"]));
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and CreateTime>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and CreateTime<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            int count;
            List<Model.Agents> ListMember = BLL.Agents.GetBCenterEntityList(strWhere + sh, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                Model.Member model = BllModel.GetModel(ListMember[i].MID);
                sb.Append(ListMember[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].MID + "~");
                sb.Append(model.MName + "~");
                sb.Append(model.Tel + "~");
                sb.Append(ListMember[i].CreateTime.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(BLL.Roles.RolsList[ListMember[i].Type].RName + "~");
                sb.Append(ListMember[i].Province + ListMember[i].City + ListMember[i].Zone + "~");
                sb.Append(ListMember[i].IsValidStr);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}