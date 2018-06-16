using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class SubAccount :BasePage
    {
        protected override void SetPowerZone()
        {
            SupplierName.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0  and Type=2 order by ID");
            SupplierName.DataTextField = "Name";
            SupplierName.DataValueField = "ID";
            SupplierName.DataBind();
            SupplierName.Items.Insert(0, "--请选择--");
        }
    }
}