using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class DDTastAdd : BasePage
    {
        protected override void SetPowerZone()
        {
            txtGood.DataSource = BLL.Goods.GetList(" IsDeleted = 0 order by GID");
            txtGood.DataTextField = "GName";
            txtGood.DataValueField = "GID";
            txtGood.DataBind();
            txtGood.Items.Insert(0, "--请选择--");

            SupplierName.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0 and (Spare3 is null or Spare3='')  and Type=1 order by ID");
            SupplierName.DataTextField = "Name";
            SupplierName.DataValueField = "ID";
            SupplierName.DataBind();
            SupplierName.Items.Insert(0, "--请选择--");
            SupplierName2.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0 and (Spare3 is null or Spare3='')  and Type=2  order by ID");
            SupplierName2.DataTextField = "Name";
            SupplierName2.DataValueField = "ID";
            SupplierName2.DataBind();
            SupplierName2.Items.Insert(0, "--请选择--");
            SupplierName3.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0 and (Spare3 is null or Spare3='')  order by ID");
            SupplierName3.DataTextField = "Name";
            SupplierName3.DataValueField = "ID";
            SupplierName3.DataBind();
            SupplierName3.Items.Insert(0, "--请选择--");

            Name.Value = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                ocode.Value = Request.QueryString["oid"];
                oid.Value = Request.QueryString["oid"];
            }
            else {

            }
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Name.Value = BLL.C_CarTast.GetModel(Convert.ToInt32(Request.QueryString["id"])).Name;
            }
            //ocode.Disabled = true;
        }

        protected override void SetValue(string id)
        {
            Model.C_CarTast c = BLL.C_CarTast.GetModel(int.Parse(id));
            Name.Value = c.Name;
            TType.Value = c.TType.ToString();
            SupplierName.Value = c.SupplierName;
            SupplierName2.Value = c.SupplierName;
            SupplierName3.Value = c.SupplierName;

            SupplierAddress.Value = c.SupplierAddress;
            SupplierTelName.Value = c.SupplierTelName;
            SupplierTel.Value = c.SupplierTel;

            uploadurl.Value = c.BDImg.ToString();
            Spare1.Value = c.Spare1.ToString();
            ocode.Value = c.OCode;
            fid.Value = c.ID.ToString();
            oid.Value = c.OCode.ToString();
            ComDate.Value = c.ComDate.ToString();
            txtProt.Value = c.Prot.ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                ocode.Value = Request.QueryString["oid"];
            }
        }
    }
}