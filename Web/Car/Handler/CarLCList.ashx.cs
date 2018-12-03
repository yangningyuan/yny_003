using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// CarLCList 的摘要说明
    /// </summary>
    public class CarLCList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " '1'='1' and Type=1 ";
           
            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            {
                strWhere += " and CarCode like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%' ";
            }
            int count;
            List<Model.C_Mileage> ListNotice = BLL.C_Mileage.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].CarCode + "~");
                sb.Append(ListNotice[i].SIJI1 + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(ListNotice[i].SIJI2 + "~");
                sb.Append((ListNotice[i].Mileage-ListNotice[i].DiffCount) + "~");
                sb.Append(ListNotice[i].Mileage + "~");
                sb.Append(ListNotice[i].DiffCount + "~");
                sb.Append((ListNotice[i].CreateDate) + "");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}