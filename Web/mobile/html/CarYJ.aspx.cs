using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class CarYJ : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = " 1=1 ";
            

            List<Model.C_Car> listchange = null;

            listchange = BLL.C_Car.GetList(where, CurrentPage, ItemsPerPage, out totalCount);
            List<Model.C_Car> listchange2 = null;

            string state = Request.Form["state"];
            if (state=="bx")
            {
                listchange2 = listchange.OrderBy(a=>a.BXDate).ToList();
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

            //if (!string.IsNullOrEmpty(state))
            //{
            //    if (state == "0" && listchange.Count > 0)
            //    {

            //        Model.C_CarTast ct = listchange.ToList().OrderByDescending(m => m.Prot).FirstOrDefault();
            //        listchange.Clear();
            //        listchange.Add(ct);
            //    }
            //}
            var list = listchange2.Select(item => new
            {
                PZCode = item.PZCode,
                //SupplierName = item.SupplierName,
                CarType = item.CarType,
                CType = item.CType,
                DQDate = strDQDate(item, state),
                CountDay = strCountDay(item, state)
            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }

        public static string strCountDay(Model.C_Car car,string state)
        {
            string listchange2 = "";
            if (state == "bx")
            {
                listchange2 =Convert.ToInt32((car.BXDate-DateTime.Now).TotalDays).ToString();
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
                listchange2 = "<span style='color:red;'>"+listchange2+"</span>";
            }

            return listchange2;
        }

        public static string strDQDate(Model.C_Car car,string state)
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