using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
	public partial class CostList2 : BasePage
	{
		protected override void SetPowerZone()
		{
			object obj= BLL.CommonBase.GetSingle(" select isnull(sum(CostMoney),0) from C_CostDetalis where IsDelete=0; ");
			summoney.InnerHtml = obj.ToString();
		}
		protected override string btnOther_Click()
		{
			Model.C_CostDetalis cd = BLL.C_CostDetalis.GetModel(Convert.ToInt32(Request.Form["cid"]));
			if (cd.IsDelete != 0)
				return "审核失败，数据状态已改变，请刷新";
			cd.IsDelete = 2;
			if (BLL.C_CostDetalis.Update(cd))
				return "审核成功";
			else
				return "审核失败";
		}
	}
}