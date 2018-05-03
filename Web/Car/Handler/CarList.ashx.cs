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
				sb.Append(ListNotice[i].CarXSZCode + "~");
				sb.Append(ListNotice[i].CarDW + "~");
				sb.Append(ListNotice[i].CarZLC + "~");
				sb.Append((ListNotice[i].CreateDate) + "~");
				//sb.Append("<div class=\"pay btn btn-success\" onclick=\"v5.show('Car/CarList.aspx?id=" + ListNotice[i].ID + "', '查看详情', 'url', 360, 240)\">查看详情</div>");
				sb.Append("≌");
				sb.Append("≠");
				////数量
				sb.Append("9");
				sb.Append("≠");
				//内容(买家信息				
				sb.Append("发动机号:" + ListNotice[i].CarEngine);
				sb.Append("<br/>车架号:" + ListNotice[i].CarCJCode);
                sb.Append("<br/>营运证号:" + ListNotice[i].Spare2);
                sb.Append("<br/>罐体容积:" + ListNotice[i].Spare3);
                sb.Append("<br/>车辆类型:" + ListNotice[i].CType);
                sb.Append("<br/>保险到期时间:" + ListNotice[i].BXDate);
				sb.Append("<br/>营运证号到期时间:" + ListNotice[i].YYZDate);
				sb.Append("<br/>保养到期时间:" + ListNotice[i].BYDate);
				sb.Append("<br/>罐检验到期时间:" + ListNotice[i].GJYDate);
				sb.Append("<br/>安全阀检验到期日期:" + ListNotice[i].AQFDate);

                sb.Append("<br/>交强险到期日期:" + ListNotice[i].JQXDate);
                sb.Append("<br/>三责险到期日期:" + ListNotice[i].SZXDate);
                sb.Append("<br/>承运险到期日期:" + ListNotice[i].CYXDate);
                sb.Append("<br/>车辆入户时间日期:" + ListNotice[i].CLRHDate);
                sb.Append("<br/>车辆技术等级评定时间:" + ListNotice[i].CLJJPDDate);

                sb.Append("<br/>燃油类型:" + ListNotice[i].RYType);
				sb.Append("<br/>备注:" + ListNotice[i].Remark);
				sb.Append("≌");
			}
			var info = new { PageData = Traditionalized(sb), TotalCount = count };

			//var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
			context.Response.Write(JavaScriptConvert.SerializeObject(info));
		}
	}
}