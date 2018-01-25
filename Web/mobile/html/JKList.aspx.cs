using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class JKList : BasePage
	{
		protected override string btnOther_Click()
		{
			string where = "  ApplyMID='" + TModel.MID + "' ";


			List<Model.C_LoanApply> listchange = null;

			listchange = BLL.C_LoanApply.GetList(where, CurrentPage, ItemsPerPage, out totalCount);

			var list = listchange.Select(item => new
			{
				Money = item.Money,
				RealMoney = item.RealMoney,
				CareteDate = item.CareteDate.ToString("yyyy-MM-dd HH:ss"),
				FFType = item.FFType,
				SPMID =( string.IsNullOrEmpty( item.SPMID)?"未审批":item.SPMID)
			});
			return jss.Serialize(new { Items = list, TotalCount = totalCount });
		}
		
	}
}