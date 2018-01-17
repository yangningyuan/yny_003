using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.OJ
{
    public partial class EditDepartType : BasePage
    {
        protected override void SetValue(string id)
        {
            NoticeModel = BLL.DepartType.GetModel(int.Parse(id));
        }

        private Model.DepartType NoticeModel
        {
            get
            {
                Model.DepartType model = new Model.DepartType();
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
                result = BLL.DepartType.Update(NoticeModel);
            }
            else {
                result = BLL.DepartType.Add(NoticeModel);
            }
            if (result)
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}