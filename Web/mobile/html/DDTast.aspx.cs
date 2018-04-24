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

            CarSJ1.DataSource = BLL.Member.ManageMember.GetMemberEntityList("  RoleCode='SiJi' AND FMID='1' AND IsClock=0 AND IsClose=0  order by ID");
            CarSJ1.DataTextField = "MID";
            CarSJ1.DataValueField = "MID";
            CarSJ1.DataBind();
            CarSJ1.Items.Insert(0, "--请选择--");

            CarSJ2.DataSource = BLL.Member.ManageMember.GetMemberEntityList("  RoleCode='SiJi' AND FMID IN('2','3') AND IsClock=0 AND IsClose=0  order by ID");
            CarSJ2.DataTextField = "MID";
            CarSJ2.DataValueField = "MID";
            CarSJ2.DataBind();
            CarSJ2.Items.Insert(0, "--请选择--");
            if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
            {
                ocode.Value = Request.QueryString["oid"];
                oid.Value = Request.QueryString["oid"];

            }
        }
        protected override void SetValue(string id)
        {
            Model.C_CarTast c = BLL.C_CarTast.GetModel(int.Parse(id));
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
            if (c.TState != -1)
            {
                subview.Visible = false;
            }
        }
    }
}