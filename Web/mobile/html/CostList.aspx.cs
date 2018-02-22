using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class CostList : BasePage
	{
		protected override string btnOther_Click()
		{
			string where = "  MID='" + TModel.MID + "' ";


			List<Model.C_CostDetalis> listchange = null;

			listchange = BLL.C_CostDetalis.GetList(where, CurrentPage, ItemsPerPage, out totalCount);

			var list = listchange.Select(item => new
			{
				Money = item.CostMoney,
				Remark = item.Remark,
				CreateDate = item.CareteDate.ToString("yyyy-MM-dd HH:ss"),
				dhtml = (item.IsDelete.ToString().Replace("0", "<a class=\"button button-fill button-success\" href=\"Javascript:delCost('" + item.ID + "')\">删除</a>").Replace("1","已删除").Replace("2","已审核"))

			});
			return jss.Serialize(new { Items = list, TotalCount = totalCount });
		}

		protected override string btnAdd_Click()
		{
			Model.C_CostDetalis cd = BLL.C_CostDetalis.GetModel(Convert.ToInt32(Request.Form["cid"]));
			if (cd.IsDelete != 0)
				return "状态已改变，请刷新重试";
			cd.IsDelete = 1;
			if (BLL.C_CostDetalis.Update(cd))
				return "删除成功";
			else
				return "删除失败";
		}
	}
}