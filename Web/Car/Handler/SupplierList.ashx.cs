using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// SupplierList 的摘要说明
    /// </summary>
    public class SupplierList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and IsDelete='" + context.Request["tState"] + "'";
            }

            if (!string.IsNullOrEmpty(context.Request["SType"]))
            {
                strWhere += " and Type=" + context.Request["SType"] + "";
            }
            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            {
                strWhere += " and Name like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            }
            int count;
            List<Model.C_Supplier> ListNotice = BLL.C_Supplier.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {

                if (pageIndex ==1&&i==0)
                {
                    sb.Append("~");
                    sb.Append("~");
                    sb.Append("<strong style='color:red;'>总计<strong>~");
                    sb.Append("~");
                    //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                    sb.Append("~");
                    sb.Append( "~");
                    sb.Append("<strong style='color:red;'>" + ListNotice.Sum(a => a.QCMoney) + "</strong>~");
                    sb.Append("<strong style='color:red;'>" + ListNotice.Sum(a => a.OverMoney) + "</strong>~");
                    sb.Append("~");
                    sb.Append("~");
                    sb.Append("≌");
                }

                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append((ListNotice[i].OverMoney > ListNotice[i].QCMoney ? "<strong style='color:red;'>" + ListNotice[i].Name + "</strong>" : ListNotice[i].Name.ToString()) + "~");
                sb.Append(ListNotice[i].TelName + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(ListNotice[i].Tel + "~");
                sb.Append(ListNotice[i].Address + "~");
                sb.Append((ListNotice[i].OverMoney > ListNotice[i].QCMoney? "<strong style='color:red;'>" + ListNotice[i].QCMoney + "</strong>" :ListNotice[i].QCMoney.ToString()) + "~");
                sb.Append((ListNotice[i].OverMoney > ListNotice[i].QCMoney ? "<strong style='color:red;'>" + ListNotice[i].OverMoney + "</strong>" : ListNotice[i].QCMoney.ToString()) + "~");
                sb.Append((ListNotice[i].CreateDate) + "~");
                sb.Append(((ListNotice[i].Spare3 == "-1" ? "是" : "否")) + "~");
                //sb.Append("<div class=\"pay btn btn-success\" onclick=\"ShowAccount('"+ListNotice[i].ID+"')\">查看账户</div>");
                sb.Append("≌");
                sb.Append("≠");
                ////数量
                sb.Append("9");
                sb.Append("≠");
                //内容(买家信息				
                sb.Append("税号:" + ListNotice[i].SHCode);
                sb.Append("<br/>账号:" + ListNotice[i].UserCode);
                sb.Append("<br/>结账周期:" + ListNotice[i].ZQDate);
                sb.Append("<br/>资质:" + ListNotice[i].ZZValue);
                sb.Append("<br/>地址:" + ListNotice[i].Address);
                sb.Append("<br/>备注:" + ListNotice[i].Remark);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}