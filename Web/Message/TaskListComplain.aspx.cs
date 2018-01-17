using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.Message
{
    public partial class TaskListComplain : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!BllModel.TModel.Role.IsAdmin)
            {
                DivSearch.InnerHtml = "<input name='txtKey' id='mKey' value='" + BllModel.TModel.MID + "' style='display:none;' />";
                //DivChk.InnerHtml = "<input type='checkbox' id='chktrue' checked='checked' value='true' name='chkType' style='display:none;'/>";
            }
        }
    }
}