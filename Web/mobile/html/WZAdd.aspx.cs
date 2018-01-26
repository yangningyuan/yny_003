using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class WZAdd : BasePage
    {
        protected override string btnAdd_Click()
        {
            try
            {
                string paizhao = Request.Form["txtName"] ;
                string txtDateils = Request.Form["txtDateils"];
                string txtRemark = Request.Form["txtRemark"];
                
                    Model.C_Violation apply = new Model.C_Violation();
                    apply.MID = TModel.MID;
                    apply.Name= paizhao;
                    apply.CLDetails = txtDateils;
                    apply.CreateDate = DateTime.Now;
                    apply.Remark = txtRemark;
                    if (BLL.C_Violation.Add(apply) > 0)
                    {
                        return "违章记录已提交";
                    }
                    else {
                        return "数据有误，请重试";
                    }
                
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}