using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
	public partial class AddSupplier : BasePage
	{
		protected override string btnModify_Click()
		{
			Model.C_Supplier c = new Model.C_Supplier();
			c.Type =int.Parse( Request.Form["sType"]);
			c.Name = Request.Form["Name"];
			c.SHCode = Request.Form["SHCode"];
			c.UserCode = Request.Form["UserCode"];
			c.ZQDate =int.Parse( Request.Form["ZQDate"]);
			c.ZZValue = Request.Form["ZZValue"];
			c.TelName = Request.Form["TelName"];
			c.Tel = Request.Form["Tel"];
			c.Address = Request.Form["Address"];
			c.QCMoney =decimal.Parse( Request.Form["QCMoney"]);
			
			c.Remark = Request.Form["Remark"];
			if (string.IsNullOrEmpty(Request.Form["fid"]))
			{
                c.OverMoney = decimal.Parse(Request.Form["OverMoney"]);
                if (BLL.C_Supplier.Add(c) > 0)
				{
					return "添加成功";
				}
				else {
					return "添加失败";
				}
			}
			else {
				c.ID = int.Parse(Request.Form["fid"]);
				if (BLL.C_Supplier.Update(c))
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
			Model.C_Supplier c = BLL.C_Supplier.GetModel(int.Parse(id));
			sType.Value = c.Type.ToString();
			Name.Value = c.Name;
			SHCode.Value = c.SHCode;
			UserCode.Value = c.UserCode;
			ZQDate.Value = c.ZQDate.ToString();
			ZZValue.Value = c.ZZValue;
			TelName.Value = c.TelName;
			Tel.Value = c.Tel;
			Address.Value = c.Address;
			QCMoney.Value = c.QCMoney.ToString();
			OverMoney.Value = c.OverMoney.ToString();
            
			Remark.Value = c.Remark;
			fid.Value = c.ID.ToString();
		}
	}
}