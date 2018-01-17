using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.Member
{
    public partial class SHListSJ : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
                DivSearch.InnerHtml = "";
            if (!TModel.Role.CanSH)
                DivOperation.InnerHtml = "";

        }
    }
}