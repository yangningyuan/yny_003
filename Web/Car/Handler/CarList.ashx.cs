using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
	/// <summary>
	/// CarList 的摘要说明
	/// </summary>
	public class CarList : BaseHandler
	{

		public override void ProcessRequest(HttpContext context)
		{
			base.ProcessRequest(context);
			string strWhere = "'1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and IsDelete='" + context.Request["tState"] + "'";
            }
            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
			{
				strWhere += " and PZCode like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
			}
			int count;
			List<Model.C_Car> ListNotice = BLL.C_Car.GetList(strWhere, pageIndex, pageSize, out count);

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < ListNotice.Count; i++)
			{
				sb.Append(ListNotice[i].ID + "~");
				sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
				sb.Append(ListNotice[i].PZCode + "~");
				sb.Append(ListNotice[i].CarType + "~");
				//sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
				sb.Append(ListNotice[i].CarBrand + "~");
				sb.Append(ListNotice[i].CarXSZCode+ "~");
				sb.Append(ListNotice[i].CarDW + "~");
				sb.Append(ListNotice[i].CarZLC + "~");
				sb.Append((ListNotice[i].CreateDate) + "~");
				sb.Append("<div class=\"pay btn btn-success\" onclick=\"v5.show('OJ/ObjSubList.aspx?id=" + ListNotice[i].ID + "', '查看详情', 'url', 360, 240)\">查看详情</div>");
				sb.Append("≌");

			}
			var info = new { PageData = Traditionalized(sb), TotalCount = count };

			//var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
			context.Response.Write(JavaScriptConvert.SerializeObject(info));
		}
	}
}