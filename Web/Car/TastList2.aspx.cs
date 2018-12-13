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

        protected override string btnModify_Click()
        {
            Model.C_CarTast cartast = BLL.C_CarTast.GetModel(Convert.ToInt32(Request.Form["tid"]));
            if (cartast.SHInt != 0)
                return "此任务审核状态为已审核状态";

            cartast.SHInt = 1;
            if (BLL.C_CarTast.Update(cartast))
                return "审核成功";
            else
                return "审核失败";
        }
    }
}