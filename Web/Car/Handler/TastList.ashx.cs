using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// TastList 的摘要说明
    /// </summary>
    public class TastList : BaseHandler
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
                strWhere += " and Name like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            }
            int count;
            List<Model.C_CarTast> ListNotice = BLL.C_CarTast.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].Name + "~");
                sb.Append(ListNotice[i].TType + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(ListNotice[i].SupplierName + "~");
                sb.Append(ListNotice[i].SupplierTel + "~");
                sb.Append(ListNotice[i].Spare2 + "~");
                sb.Append(ListNotice[i].CostType + "~");
                sb.Append((ListNotice[i].CreateDate) + "~");
                //sb.Append("<div class=\"pay btn btn-success\" onclick=\"v5.show('OJ/ObjSubList.aspx?id=" + ListNotice[i].ID + "', '查看详情', 'url', 360, 240)\">查看详情</div>");
                sb.Append("≌");
				sb.Append("≠");
				////数量
				sb.Append("9");
				sb.Append("≠");
				//内容(买家信息				
				sb.Append("供应商地址:" + ListNotice[i].SupplierAddress);
				sb.Append("<br/>主司机:" + ListNotice[i].CarSJ1);
				sb.Append("<br/>副司机:" + ListNotice[i].CarSJ2);
				sb.Append("<br/>磅单图片:<img src='"+ ListNotice[i].BDImg + "' width='40%' />" );
				//sb.Append("<br/>地址:" + ListNotice[i].Address);
				//sb.Append("<br/>备注:" + ListNotice[i].Remark);
				sb.Append("≌");
			}
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}