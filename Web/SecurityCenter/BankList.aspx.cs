using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.SecurityCenter
{
    public partial class BankList : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.Super)
            {
                DivSearch.InnerHtml = "<input name='txtKey' id='mKey' value='" + TModel.MID + "' style='display:none;' />";
                DivOp.Visible = false;
            }
        }

    }
}