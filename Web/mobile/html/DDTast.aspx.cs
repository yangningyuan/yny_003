using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class DDTast : BasePage
    {
        protected Model.C_CarTast cartast = null; protected Model.C_Supplier supplier = null;
        protected override void SetPowerZone()
        {
            Spare2.DataSource = BLL.C_Car.GetList(" IsDelete = 0 and CType='牵引车' order by ID");
            Spare2.DataTextField = "PZCode";
            Spare2.DataValueField = "PZCode";
            Spare2.DataBind();

            CSpare2.DataSource = BLL.C_Car.GetList(" IsDelete = 0 and CType='挂车' order by ID");
            CSpare2.DataTextField = "PZCode";
            CSpare2.DataValueField = "PZCode";
            CSpare2.DataBind();
            //ListItem lt = new ListItem();
            //lt.Value = "";
            //lt.Text = "空项";
            //CSpare2.Items.Insert(0, lt);

            CarSJ1.DataSource = BLL.Member.ManageMember.GetMemberEntityList("  RoleCode='SiJi' AND FMID='1' AND IsClock=0 AND IsClose=0  order by ID");
            CarSJ1.DataTextField = "MName";
            CarSJ1.DataValueField = "MID";
            //CarSJ1.Items.Insert(0, "--请选择--");
            CarSJ1.DataBind();
            

            CarSJ2.DataSource = BLL.Member.ManageMember.GetMemberEntityList("  RoleCode='SiJi' AND FMID IN('2','3') AND IsClock=0 AND IsClose=0  order by ID");
            CarSJ2.DataTextField = "MName";
            CarSJ2.DataValueField = "MID";
            CarSJ2.DataBind();
            //CarSJ2.Items.Insert(0, "--请选择--");
            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                ocode.Value = Request.QueryString["oid"];
                oid.Value = Request.QueryString["oid"];
            }
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string id = Request.QueryString["id"];
                Model.C_CarTast car = BLL.C_CarTast.GetModel(Convert.ToInt32(id));
                Spare2.Value = car.Spare2.ToString();
                CSpare2.Value = car.CSpare2.ToString();
                CarSJ1.Value = car.CarSJ1.ToString();
                CarSJ2.Value = car.CarSJ2.ToString();
            }
            
        }
        protected override void SetValue(string id)
        {
            Model.C_CarTast c = BLL.C_CarTast.GetModel(int.Parse(id));
            supplier = BLL.C_Supplier.GetModel(int.Parse(c.SupplierName));
            cartast = c;
            Name.Value = c.Name;
            TType.Value = c.TType.ToString();

            Spare2.Value = c.Spare2.ToString();
            CSpare2.Value = c.CSpare2.ToString();
            CarSJ1.Value = c.CarSJ1.ToString();
            CarSJ2.Value = c.CarSJ2.ToString();


            ocode.Value = c.OCode;
            fid.Value = c.ID.ToString();
            oid.Value = c.OCode.ToString();
            ComDate.Value = c.ComDate.ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                ocode.Value = Request.QueryString["oid"];
            }
            if (c.TState != -1&&c.TState!=0)
            {
                subview.Visible = false;
            }
        }
    }
}