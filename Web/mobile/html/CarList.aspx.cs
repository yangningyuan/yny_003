using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class CarList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = " 1=1 ";
            string state = Request.Form["state"];
            if (!string.IsNullOrEmpty(state))
            {
                where += " and Isdelete=" + state + " ";
            }
            if (!string.IsNullOrEmpty(Request["begin_time"]))
            {
                where += " and CreateDate>'" + Request["begin_time"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(Request["end_time"]))
            {
                where += " and CreateDate<'" + Request["end_time"] + " 23:59:59' ";
            }

            List<Model.C_Car> listchange = null;

            listchange = BLL.C_Car.GetList(where, CurrentPage, ItemsPerPage, out totalCount);
            //if (!string.IsNullOrEmpty(state))
            //{
            //    if (state == "0" && listchange.Count > 0)
            //    {

            //        Model.C_CarTast ct = listchange.ToList().OrderByDescending(m => m.Prot).FirstOrDefault();
            //        listchange.Clear();
            //        listchange.Add(ct);
            //    }
            //}
            var list = listchange.Select(item => new
            {
                PZCode = item.PZCode,
                //SupplierName = item.SupplierName,
                CarType = item.CarType,
                CType = item.CType,
                CarZLC = item.CarZLC
            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }

      
    }
}