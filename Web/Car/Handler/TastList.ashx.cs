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
			if (!string.IsNullOrEmpty(context.Request["coststate"]))
			{
				strWhere += " and TState='" + context.Request["coststate"] + "' ";
			}

			int count;
            List<Model.C_CarTast> ListNotice = BLL.C_CarTast.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].Name + "~");
                sb.Append(Model.C_CarTast.typename(ListNotice[i].TType) + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(ListNotice[i].SupplierName + "~");
                sb.Append(ListNotice[i].SupplierTel + "~");
                sb.Append(ListNotice[i].Spare2 + "~");
                sb.Append(BLL.C_CostType.GetModel(ListNotice[i].CostType).Name + "~");
                sb.Append((ListNotice[i].CreateDate) + "~");
				if (ListNotice[i].TState == 0)
				{
					sb.Append("<div class=\"pay btn btn-success\" onclick=\"celTast('"+ListNotice[i].ID+"')\">取消任务</div>");
				}


				sb.Append("≌");
				sb.Append("≠");
				////数量
				sb.Append("10");
				sb.Append("≠");
				//内容(买家信息				
				sb.Append("供应商地址:" + ListNotice[i].SupplierAddress);
				sb.Append("<br/>主司机:" + ListNotice[i].CarSJ1);
				sb.Append("<br/>副司机:" + ListNotice[i].CarSJ2);
				
				if (!string.IsNullOrEmpty( ListNotice[i].OCode)) //装车  卸车
				{
					sb.Append("<br/>商品订单:" + ListNotice[i].OCode);
					List<Model.OrderDetail> odlist= BLL.OrderDetail.GetList(" ordercode='"+ ListNotice[i].OCode.ToString() + "'; ");
					foreach (Model.OrderDetail item in odlist)
					{
						Model.Goods good = BLL.Goods.GetModel(item.GId);
						sb.Append(string.Format("<br/><span style='color:black; font-size:16px;'>{0}</span>&nbsp;&nbsp;&nbsp;<span style='color:red; font-size:20px;'>{1}</span><span style='color:green;'>{2}</span>", good.GName, item.GCount,good.Unit));
					}
				}
				sb.Append("<br/>磅单图片:<a href='" + ListNotice[i].BDImg + "' target='blank'><img src='" + ListNotice[i].BDImg + "' width='5%' /></a>");
				sb.Append("≌");
			}
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}