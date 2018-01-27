using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class BXView : BasePage
	{
		protected Model.C_Error bxerror = null;
		protected override void SetPowerZone()
		{
			bxerror = BLL.C_Error.GetModel(Convert.ToInt32( Request.QueryString["id"]));
		}
	}
}