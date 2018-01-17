using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.OJ
{
    public partial class EditImpType :BasePage
    {
        protected override void SetValue(string id)
        {
            NoticeModel = BLL.ImpType.GetModel(int.Parse(id));
        }

        private Model.ImpType NoticeModel
        {
            get
            {
                Model.ImpType model = new Model.ImpType();
                model.Name = Request.Form["txtName"];
                model.Remark = Request.Form["txtRemark"];
                if (!string.IsNullOrEmpty(Request.Form["lbID"]))
                    model.ID = int.Parse(Request.Form["lbID"]);
                return model;
            }
            set
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    lbID.Value = Request.QueryString["id"].ToString();
                txtName.Value = value.Name;
                txtRemark.Value = value.Remark;
            }
        }

        protected override string btnModify_Click()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(Request.Form["lbID"]))
            {
                result = BLL.ImpType.Update(NoticeModel);
            }
            else {
                result = BLL.ImpType.Add(NoticeModel);
            }
            if (result)
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}