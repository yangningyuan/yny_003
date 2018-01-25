using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class index : BasePage
    {

        protected Model.Notice notice = null;
        protected string noticecontent = "";
		protected int isnotice = 0;
        protected override void SetPowerZone()
        {
			if (Convert.ToDateTime(TModel.ValidTime).ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))//当天第一次登陆
			{
				isnotice = 1;
				BLL.CommonBase.GetSingle(string.Format("update member set validtime='{0}' where mid='{1}'",DateTime.Now,TModel.MID));
			}

			notice = BLL.Notice.GetTopNotice();
            
        }

        
    }
}