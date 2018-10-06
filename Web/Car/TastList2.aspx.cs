using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class TastList2 : BasePage
    {
        protected override void SetPowerZone()
        {
            
            tcode.Value= Request.QueryString["tcode"]; 
        }
    }
}