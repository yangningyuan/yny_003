using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class AccountDownList : BasePage
    {
        protected override void SetPowerZone()
        {
            SupplierName.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0  and Type=2 order by ID");
            SupplierName.DataTextField = "Name";
            SupplierName.DataValueField = "ID";
            SupplierName.DataBind();
            SupplierName.Items.Insert(0, "--请选择--");
        }
        protected override string btnOther_Click()
        {
            Model.Account cd = BLL.Account.GetModel(Convert.ToInt32(Request.Form["cid"]));
            if (!string.IsNullOrEmpty(cd.Spare))
                return "此单已开发票，请勿重复操作";
            cd.Spare = "1";
            if (BLL.Account.Update(cd))
                return "开票成功";
            else
                return "开票失败";
        }
    }
}