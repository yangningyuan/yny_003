using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
	public partial class AddCar : BasePage
	{

        protected override void SetPowerZone()
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                BXDate.Value = DateTime.Now.ToString();
                YYZDate.Value = DateTime.Now.ToString();
                BYDate.Value = DateTime.Now.ToString();
                GJYDate.Value = DateTime.Now.ToString();
                AQFDate.Value = DateTime.Now.ToString();
                JQXDate.Value = DateTime.Now.ToString();
                SZXDate.Value = DateTime.Now.ToString();
                CYXDate.Value = DateTime.Now.ToString();
                CLRHDate.Value = DateTime.Now.ToString();
                CLJJPDDate.Value = DateTime.Now.ToString();

            }
            
        }
        protected override string btnModify_Click()
		{
			Model.C_Car c = new Model.C_Car();
			c.PZCode = Request.Form["PZCode"];
			c.CarType = Request.Form["CarType"];
			c.CarBrand = Request.Form["CarBrand"];
			c.CarEngine = Request.Form["CarEngine"];
			c.CarCJCode = Request.Form["CarCJCode"];
			c.CarXSZCode = Request.Form["CarXSZCode"];
			c.CarDW = decimal.Parse(Request.Form["CarDW"]);
			c.RYType = Request.Form["RYType"];
			c.BXDate = DateTime.Parse(Request.Form["BXDate"]);
			c.YYZDate = DateTime.Parse(Request.Form["YYZDate"]);
			c.BYDate = DateTime.Parse(Request.Form["BYDate"]);
			c.GJYDate = DateTime.Parse(Request.Form["GJYDate"]);
			c.AQFDate = DateTime.Parse(Request.Form["AQFDate"]);

            c.JQXDate = DateTime.Parse(Request.Form["JQXDate"]);
            c.SZXDate = DateTime.Parse(Request.Form["SZXDate"]);
            c.CYXDate = DateTime.Parse(Request.Form["CYXDate"]);
            c.CLRHDate = DateTime.Parse(Request.Form["CLRHDate"]);
            c.CLJJPDDate = DateTime.Parse(Request.Form["CLJJPDDate"]);

            c.CarZLC = int.Parse(Request.Form["CarZLC"]);
			c.Remark = Request.Form["Remark"];
            c.Spare2 = Request.Form["CarYYZCode"];
            c.Spare3 = Request.Form["CarGTRJ"];
            c.CType = Request.Form["CType"];

            if (string.IsNullOrEmpty(Request.Form["fid"]))
			{
				if (BLL.C_Car.Add(c) > 0)
				{
					return "添加成功";
				}
				else {
					return "添加失败";
				}
			}
			else {
				c.ID = int.Parse(Request.Form["fid"]);
				if (BLL.C_Car.Update(c))
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
			Model.C_Car c = BLL.C_Car.GetModel(int.Parse(id));
			PZCode.Value = c.PZCode;
			CarType.Value = c.CarType;
			CarBrand.Value =c.CarBrand;
			CarEngine.Value = c.CarEngine;
			CarCJCode.Value = c.CarCJCode;
			CarXSZCode.Value = c.CarXSZCode;
			CarDW.Value = c.CarDW.ToString();
			RYType.Value = c.RYType.ToString();
			BXDate.Value = c.BXDate.ToString();
			YYZDate.Value = c.YYZDate.ToString();
			BYDate.Value = c.BYDate.ToString();
			GJYDate.Value= c.GJYDate.ToString();
			AQFDate.Value = c.AQFDate.ToString();


            JQXDate.Value = c.JQXDate.ToString();
            SZXDate.Value = c.SZXDate.ToString();
            CYXDate.Value = c.CYXDate.ToString();
            CLRHDate.Value = c.CLRHDate.ToString();
            CLJJPDDate.Value = c.CLJJPDDate.ToString();

            CarZLC.Value = c.CarZLC.ToString();
			Remark.Value = c.Remark;
            CarYYZCode.Value = c.Spare2;
            CarGTRJ.Value = c.Spare3;
            CType.Value = c.CType.ToString();
			fid.Value = c.ID.ToString();
		}
	}
}