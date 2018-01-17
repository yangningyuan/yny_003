using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace zx270.Web.Handler
{
    /// <summary>
    /// LuckyMoneyList 的摘要说明
    /// </summary>
    public class LuckyMoneyList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " 1 = 1 ";

            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (context.Request["tState"] == "true")
                {
                    strWhere += " and isValid = 1 ";
                }
                else
                {
                    strWhere += " and isValid = 0 ";
                }
            }

            if (TModel.Role.Super)
            {
                if (!string.IsNullOrEmpty(context.Request["mKey"]))
                {
                    strWhere += string.Format(" and MID='{0}' ", (context.Request["mKey"]));
                }
            }
            else
            {
                strWhere += string.Format(" and MID='{0}' ", TModel.MID);
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
            List<Model.LuckyMoney> ListMember = BLL.LuckyMoney.GetLuckyMoneyEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].MID + "~");
                sb.Append(ListMember[i].CreateTime.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(ListMember[i].FHMoney.ToFixedString() + "~");
                sb.Append(ListMember[i].FHTimes + "~");
                sb.Append((ListMember[i].isValid != 0 ? "有效" : "无效"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}