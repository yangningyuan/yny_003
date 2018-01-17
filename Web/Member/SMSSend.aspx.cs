using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.Member
{
    public partial class SMSSend : BasePage
    {
        protected Model.Member model = new Model.Member();
        protected override void SetValue(string id)
        {
            string mid = HttpUtility.UrlDecode(Request["id"].Trim());
            model = BllModel.GetModel(mid);
            if (model != null)
            {
                txtMID.Value = model.MID;
                txtMName.Value = model.MName;
                txtTel.Value = model.Tel;
            }
        }

        protected override string btnAdd_Click()
        {
            string tel = Request.Form["tel"];
            string content = Request.Form["contents"];
            Model.SMS model = new Model.SMS { SType = Model.SMSType.ZCYZ, Tel = tel, SContent = content, SMSKey = "" };
            string error = "";
            if (BLL.SMS.Insert(model, ref error))
            {
                return "发送成功";
            }
            else
            {
                return error;
            }
        }
    }
}