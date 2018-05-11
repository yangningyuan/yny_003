using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_003.Web.Car.Handler
{
    /// <summary>
    /// CarYJ 的摘要说明
    /// </summary>
    public class CarYJ : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1' ";
            
            int count;
            List<Model.C_Car> listchange = BLL.C_Car.GetList(strWhere, pageIndex, pageSize, out count);

            List<Model.C_Car> listchange2 = null;

            string state = context.Request["tState"];
            if (state == "bx")
            {
                listchange2 = listchange.OrderBy(a => a.BXDate).ToList();
            }
            if (state == "yy")
            {
                listchange2 = listchange.OrderBy(a => a.YYZDate).ToList();
            }
            if (state == "by")
            {
                listchange2 = listchange.OrderBy(a => a.BYDate).ToList();
            }
            if (state == "gj")
            {
                listchange2 = listchange.OrderBy(a => a.GJYDate).ToList();
            }
            if (state == "aqf")
            {
                listchange2 = listchange.OrderBy(a => a.AQFDate).ToList();
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listchange2.Count; i++)
            {
                sb.Append(listchange2[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(listchange2[i].PZCode + "~");
                sb.Append(listchange2[i].CarType + "~");
                //sb.Append((ListNotice[i].ImpUnit.ToString())+ "~");
                sb.Append(listchange2[i].CType + "~");
                sb.Append(strDQDate(listchange2[i], state) + "~");
                sb.Append(strCountDay(listchange2[i], state) + "");
                
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
        public static string strCountDay(Model.C_Car car, string state)
        {
            string listchange2 = "";
            if (state == "bx")
            {
                listchange2 = Convert.ToInt32((car.BXDate - DateTime.Now).TotalDays).ToString();
            }
            if (state == "yy")
            {
                listchange2 = Convert.ToInt32((car.YYZDate - DateTime.Now).TotalDays).ToString();
            }
            if (state == "by")
            {
                listchange2 = Convert.ToInt32((car.BYDate - DateTime.Now).TotalDays).ToString();
            }
            if (state == "gj")
            {
                listchange2 = Convert.ToInt32((car.GJYDate - DateTime.Now).TotalDays).ToString();
            }
            if (state == "aqf")
            {
                listchange2 = Convert.ToInt32((car.AQFDate - DateTime.Now).TotalDays).ToString();
            }
            if (Convert.ToInt32(listchange2) <= 60)
            {
                listchange2 = "<span style='color:red;'>" + listchange2 + "</span>";
            }

            return listchange2;
        }
        public static string strDQDate(Model.C_Car car, string state)
        {
            string listchange2 = "";
            if (state == "bx")
            {
                listchange2 = car.BXDate.ToString("yyyy-MM-dd");
            }
            if (state == "yy")
            {
                listchange2 = car.YYZDate.ToString("yyyy-MM-dd");
            }
            if (state == "by")
            {
                listchange2 = car.BYDate.ToString("yyyy-MM-dd");
            }
            if (state == "gj")
            {
                listchange2 = car.GJYDate.ToString("yyyy-MM-dd");
            }
            if (state == "aqf")
            {
                listchange2 = car.AQFDate.ToString("yyyy-MM-dd");
            }
            return listchange2;
        }
    }
}