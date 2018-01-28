using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class TastView : BasePage
	{
		protected Model.Order order = null;
		protected Model.C_CarTast cartast = null;
		protected List<Model.OrderDetail> listord = null;
		protected override void SetValue(string id)
		{
			cartast = BLL.C_CarTast.GetModel(int.Parse(id));
			if (!string.IsNullOrEmpty(cartast.OCode))
			{
				order = BLL.Order.GetModel(cartast.OCode);
				listord = order.OrderDetail;
			}			
		}
	}
}