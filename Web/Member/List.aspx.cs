using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Member
{
    public partial class List : BasePage
    {
        protected string RoleListStr;
        protected int OnLineCount;
        protected string AgencyListStr;
        protected string NAgencyListStr;

        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                editMember.Visible = false;
            }
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList())
                RoleListStr += "<option value='" + item.RType + "'>" + item.RName + "</option>";
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.ToList())
                AgencyListStr += "<option value='" + item.MAgencyType + "'>" + item.MAgencyName + "</option>";
            //foreach (Model.NewSHMoney item in BLL.Configuration.Model.NewSHMoneyList.Values.ToList())
            //    NAgencyListStr += "<option value='" + item.NType + "'>" + item.NName + "</option>";
            OnLineCount = BLL.Member.OnLineCount;
        }
		protected override string btnAdd_Click()
		{
			try
			{
				string req = Request.Form["id"];
				Model.C_Supplier cc= BLL.C_Supplier.GetModel(int.Parse(req));
				if (cc != null)
				{
					return cc.Address + "^" + cc.TelName + "^" + cc.Tel;
				}
				else {
					return "-1";
				}
			}
			catch (Exception e)
			{
				return "-1";
			}
			
		}

        protected override string btnModify_Click()
        {
            try
            {
                string req = Request.Form["gid"];
                Model.Goods cc = BLL.Goods.GetModel(int.Parse(req));
                if (cc != null)
                {
                    return cc.Unit;
                }
                else {
                    return "-1";
                }
            }
            catch (Exception e)
            {
                return "-1";
            }
        }
        
    }
}