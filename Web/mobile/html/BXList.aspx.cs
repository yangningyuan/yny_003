using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class BXList : BasePage
	{
		protected override string btnOther_Click()
		{
			string where = "  MID='" + TModel.MID + "' ";


			List<Model.C_Error> listchange = null;

			listchange = BLL.C_Error.GetList(where, CurrentPage, ItemsPerPage, out totalCount);

			var list = listchange.Select(item => new
			{
				CPCode = item.CarCode,
				EType = item.EType,
				CreateDate = item.CreateDate.ToString("yyyy-MM-dd HH:mm"),
				dhtml = "<a class=\"button button-fill button-success\" href=\"javascript:pcallhtml('/mobile/html/BXView.aspx?id="+item.ID+"','我要报修');\">详情</a>"

			});
			return jss.Serialize(new { Items = list, TotalCount = totalCount });
		}
	}
}