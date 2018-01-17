using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;

namespace zx270.Web.SecurityCenter
{
    public partial class AddBankInfo : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.Super)
                txtMID.Attributes.Add("readonly", "readonly");
            else
                lb_Tip.Visible = false;
            chkIsPrimary.Checked = true;
            txtBankCardName.Value = TModel.MName;
            txtMID.Value = TModel.MID;
            Sys_BankInfoBLL BLL = new Sys_BankInfoBLL();
            txtBank.DataSource = BLL.GetList(" 1=1 and  IsDeleted=0 order by ID desc");
            txtBank.DataTextField = "Name";
            txtBank.DataValueField = "Id";
            txtBank.DataBind();
            txtBankCardName.Value = TModel.MName;
        }
        private Model.BankModel BankInfo
        {
            get
            {
                Model.BankModel model = new Model.BankModel();
                model.Bank = Request.Form["txtBank"];
                model.BankCardName = Request.Form["txtBankCardName"];
                //model.BankCardName = TModel.MName;
                model.BankCreateDate = DateTime.Now;
                model.BankNumber = Request.Form["txtBankNumber"];
                model.Branch = Request.Form["txtBranch"];
                model.MID = Request.Form["txtMID"];
                if (!TModel.Role.Super)
                    model.MID = TModel.MID;
                model.IsPrimary = Request.Form["chkIsPrimary"] == "on";
                return model;
            }
        }
        protected override string btnAdd_Click()
        {
            if (BLL.BankModel.Insert(BankInfo))
                return "操作成功";
            return "操作失败";
        }
    }
}