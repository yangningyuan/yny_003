using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
	/// <summary>
	/// CostList2 的摘要说明
	/// </summary>
	public class CostList2 : BaseHandler
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
				strWhere += " and Remark like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
			}
			int count;
			List<Model.C_CostDetalis> ListNotice = BLL.C_CostDetalis.GetList(strWhere, pageIndex, pageSize, out count);

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < ListNotice.Count; i++)
			{
				sb.Append(ListNotice[i].ID + "~");
				sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
				sb.Append(ListNotice[i].MID + "~");
				sb.Append(ListNotice[i].Remark + "~");
				//sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
				sb.Append(ListNotice[i].CostMoney + "~");
				sb.Append(("<a href='"+ ListNotice[i].CostImgUrl + "'><img src=\""+ ListNotice[i].CostImgUrl + "\" width='100px;' height='100px' /></a>") + "~");
				sb.Append((ListNotice[i].CareteDate) + "~");
				sb.Append((ListNotice[i].IsDelete==0? "<div class=\"pay btn btn-success\" onclick=\"shcost('" + ListNotice[i].ID + "')\">审核</div>":""));
				sb.Append("≌");

			}
			var info = new { PageData = Traditionalized(sb), TotalCount = count };

			//var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
			context.Response.Write(JavaScriptConvert.SerializeObject(info));
		}
	}
}