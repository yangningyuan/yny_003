using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Admin
{
    public partial class Index : BasePage
    {
        private List<Model.RolePowers> listPowers;
        
        protected override void SetPowerZone()
        {
            
            listPowers = TModel.Role.PowersList.Where(emp => emp.Content.VState).ToList();
           
        }

        protected List<Model.RolePowers> GetPowers(string cfid)
        {
            return listPowers.Where(emp => emp.Content.CFID == cfid).ToList();
        }

        protected List<Model.RolePowers> GetQuickMenu()
        {
            List<Model.RolePowers> list = listPowers.Where(emp => emp.Content.IsQuickMenu).ToList();
            return list;
        }
    }
}