using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
	public partial class AddCost : BasePage
	{
		protected override string btnModify_Click()
		{
			Model.C_CostType c = new Model.C_CostType();
			c.Name = Request.Form["Name"];
			c.Details = Request.Form["Details"];
			c.XEMoney = int.Parse( Request.Form["XEMoney"]);
			
			if (string.IsNullOrEmpty(Request.Form["fid"]))
			{
				if (BLL.C_CostType.Add(c) > 0)
				{
					return "添加成功";
				}
				else {
					return "添加失败";
				}
			}
			else {
				c.ID = int.Parse(Request.Form["fid"]);
				if (BLL.C_CostType.Update(c))
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
			Model.C_CostType c = BLL.C_CostType.GetModel(int.Parse(id));
			Name.Value = c.Name;
			Details.Value = c.Details;
			XEMoney.Value = c.XEMoney.ToString();
			fid.Value = c.ID.ToString();
		}
	}
}