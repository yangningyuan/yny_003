using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
	public partial class ModifyTast : BasePage
	{
		protected override void SetPowerZone()
		{
			//CostType.DataSource = BLL.C_CostType.GetList(" 1 = 1  order by ID");
			//CostType.DataTextField = "Name";
			//CostType.DataValueField = "ID";
			//CostType.DataBind();


			txtGood.DataSource = BLL.Goods.GetList(" IsDeleted = 0 order by GID");
			txtGood.DataTextField = "GName";
			txtGood.DataValueField = "GID";
			txtGood.DataBind();

			Spare2.DataSource = BLL.C_Car.GetList(" IsDelete = 0 and CType='牵引车' order by ID");
			Spare2.DataTextField = "PZCode";
			Spare2.DataValueField = "PZCode";
			Spare2.DataBind();

			CSpare2.DataSource = BLL.C_Car.GetList(" IsDelete = 0 and CType='挂车' order by ID");
			CSpare2.DataTextField = "PZCode";
			CSpare2.DataValueField = "PZCode";
			CSpare2.DataBind();

			SupplierName.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0  and Type=1 order by ID");
			SupplierName.DataTextField = "Name";
			SupplierName.DataValueField = "ID";
			SupplierName.DataBind();
			SupplierName.Items.Insert(0, "--请选择--");
			SupplierName2.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0  and Type=2  order by ID");
			SupplierName2.DataTextField = "Name";
			SupplierName2.DataValueField = "ID";
			SupplierName2.DataBind();
			SupplierName2.Items.Insert(0, "--请选择--");
			SupplierName3.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0  order by ID");
			SupplierName3.DataTextField = "Name";
			SupplierName3.DataValueField = "ID";
			SupplierName3.DataBind();
			SupplierName3.Items.Insert(0, "--请选择--");


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

            binddata(Request.QueryString["id"]);

			if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
			{
				ocode.Value = Request.QueryString["oid"];
				oid.Value = Request.QueryString["oid"];

			}
			else {

			}
			//ocode.Disabled = true;
		}
		protected override string btnModify_Click()
		{
			Model.C_CarTast c = new Model.C_CarTast();
			c.Name = Request.Form["Name"];
			c.TType = int.Parse(Request.Form["TType"]);
			if (c.TType == 1)
			{
				c.SupplierName = Request.Form["SupplierName"];
			}
			else if (c.TType == 2)
			{
				c.SupplierName = Request.Form["SupplierName2"];
			}
			else {
				c.SupplierName = Request.Form["SupplierName3"];
			}

			c.SupplierAddress = Request.Form["SupplierAddress"];
			c.SupplierTelName = Request.Form["SupplierTelName"];
			c.SupplierTel = Request.Form["SupplierTel"];
			c.Spare2 = Request.Form["Spare2"];
			c.CSpare2 = Request.Form["CSpare2"];
			c.CarSJ1 = Request.Form["CarSJ1"];
			c.CarSJ2 = Request.Form["CarSJ2"];
			//c.CostType = int.Parse(Request.Form["CostType"]);
			c.BDImg = Request.Form["uploadurl"];
			//c.OCode = Request.Form["ocode"];
			c.Spare1 = Request.Form["Spare1"];
			c.ComDate = DateTime.Parse(Request.Form["ComDate"]);

			#region 司机车辆验证
			Model.C_Car car = BLL.C_Car.GetModelByCode(c.Spare2);
			if (car == null)
				return "此牵引车不存在，请正确输入车辆牌照";
			//if (!string.IsNullOrEmpty(car.Spare1)&&car.ID!=c.ID)
			//	return "此牵引车任务未完成，请选择别的车辆";
			if (!string.IsNullOrEmpty(c.CSpare2))
			{
				Model.C_Car car2 = BLL.C_Car.GetModelByCode(c.CSpare2);
				if (car2 == null)
					return "此挂车不存在，请正确输入车辆牌照";
				//if (!string.IsNullOrEmpty(car2.Spare1) && car.ID != c.ID)
				//	return "此挂车任务未完成，请选择别的车辆";
			}

			Model.Member siji1 = BLL.Member.GetModelByMID(c.CarSJ1);
			if (siji1 != null)
			{
				if (siji1.FMID != "1")
					return "此司机不是主司机";
			}
			else
				return "主司机不存在";
			Model.Member siji2 = BLL.Member.GetModelByMID(c.CarSJ2);
			if (siji2 != null)
			{
				if (siji2.FMID != "2" && siji2.FMID != "3")
					return "此司机不是副司机";
			}
			else
				return "副司机不存在";
			#endregion


			c.ID = int.Parse(Request.Form["fid"]);

			if (BLL.C_CarTast.Update(c))
			{
				return "修改成功";
			}
			else {
				return "修改失败";
			}

		}


		protected void binddata(string id)
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
			Spare2.Value = c.Spare2.ToString();
			CSpare2.Value = c.CSpare2.ToString();
			CarSJ1.Value = c.CarSJ1.ToString();
			CarSJ2.Value = c.CarSJ2.ToString();
			//CostType.Value = c.CostType.ToString();
			uploadurl.Value = c.BDImg.ToString();
			Spare1.Value = c.Spare1.ToString();
			ocode.Value = c.OCode;
			fid.Value = c.ID.ToString();
			oid.Value = c.OCode.ToString();
			ComDate.Value = c.ComDate.ToString();

			if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
			{
				ocode.Value = Request.QueryString["oid"];
			}
		}

		protected override string btnAdd_Click()
		{
			Model.Member mm1 = BLL.Member.GetModelByMID(Request.Form["CarSJ1"]);
			if (mm1 == null)
				return "此司机不存在";
			if (mm1.FMID != "1")
				return "此司机不是主司机";
			return string.Format("姓名：{0}，联系电话：{1}", mm1.MName, mm1.Tel);
		}
		protected override string btnOther_Click()
		{
			Model.Member mm1 = BLL.Member.GetModelByMID(Request.Form["CarSJ2"]);
			if (mm1 == null)
				return "此司机不存在";
			if (mm1.FMID != "2" && mm1.FMID != "3")
				return "此司机不是副司机";
			return string.Format("姓名：{0}，联系电话：{1}", mm1.MName, mm1.Tel);
		}
	}
}