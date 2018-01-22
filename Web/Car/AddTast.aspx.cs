using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class AddTast : BasePage
    {
        protected override void SetPowerZone()
        {
            CostType.DataSource = BLL.C_CostType.GetList(" 1 = 1  order by ID");
            CostType.DataTextField = "Name";
            CostType.DataValueField = "ID";
            CostType.DataBind();
        }
        protected override string btnModify_Click()
        {
            Model.C_CarTast c = new Model.C_CarTast();
            c.Name = Request.Form["Name"];
            c.TType =int.Parse(Request.Form["TType"]);
            c.SupplierName = Request.Form["SupplierName"];
            c.SupplierAddress = Request.Form["SupplierAddress"];
            c.SupplierTelName = Request.Form["SupplierTelName"];
            c.SupplierTel = Request.Form["SupplierTel"];
            c.Spare2 =Request.Form["Spare2"];
            c.CarSJ1 = Request.Form["CarSJ1"];
            c.CarSJ2 = Request.Form["CarSJ2"];
            c.CostType = int.Parse(Request.Form["CostType"]);
            c.BDImg = Request.Form["uploadurl"];
            c.Spare1 = Request.Form["Spare1"];
            if (string.IsNullOrEmpty(Request.Form["fid"]))
            {
                if (BLL.C_CarTast.Add(c) > 0)
                {
                    return "添加成功";
                }
                else {
                    return "添加失败";
                }
            }
            else {
                c.ID = int.Parse(Request.Form["fid"]);
                if (BLL.C_CarTast.Update(c))
                {
                    return "修改成功";
                }
                else {
                    return "修改失败";
                }
            }
        }

        protected override void SetValue(string id)
        {
            Model.C_CarTast c = BLL.C_CarTast.GetModel(int.Parse(id));
            Name.Value = c.Name;
            TType.Value = c.TType.ToString();
            SupplierName.Value = c.SupplierName;
            SupplierAddress.Value = c.SupplierAddress;
            SupplierTelName.Value = c.SupplierTelName;
            SupplierTel.Value = c.SupplierTel;
            Spare2.Value = c.Spare2.ToString();
            CarSJ1.Value = c.CarSJ1.ToString();
            CarSJ2.Value = c.CarSJ2.ToString();
            CostType.Value = c.CostType.ToString();
            uploadurl.Value = c.BDImg.ToString();
            Spare1.Value = c.Spare1.ToString();
            fid.Value = c.ID.ToString();
        }
    }
}