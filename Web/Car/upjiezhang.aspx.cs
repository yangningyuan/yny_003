using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class upjiezhang : BasePage
    {
        protected string cid = "";
        protected override void SetPowerZone()
        {
             cid= Request.QueryString["cid"];
            
        }
    }
}