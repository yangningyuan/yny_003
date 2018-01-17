using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.OJ
{
    public partial class EditObjSub : BasePage
    {
        protected override void SetValue(string id)
        {
            
        }

        protected override void SetPowerZone()
        {
            txtSubType.DataSource = BLL.ObjSubType.GetList(" 1 = 1  order by ID");
            txtSubType.DataTextField = "Name";
            txtSubType.DataValueField = "ID";
            txtSubType.DataBind();

            Model.ObjSub model = BLL.ObjSub.GetModel(int.Parse(Request.QueryString["id"]));
            objid.Value = model.ObjID.ToString();
            subid.Value = model.ID.ToString();
            txtName.Value = model.Name;
            txtRemark.Value = model.Remark;
            txtPerson.Value = model.Person;
            txtSubType.Value = model.SubType.ToString();
            txtMoney.Value = model.Money.ToString("F2");
            txtReMoney.Value = model.ReMoney.ToString("F2");
            txtCZFloat.Value = model.CZFloat.ToString();
        }

        protected override string btnModify_Click()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(Request.Form["subid"]))
            {
                Model.ObjSub model = BLL.ObjSub.GetModel(Convert.ToInt32(Request.Form["subid"]));
                Model.Obj objmodel= BLL.Obj.GetModel(Convert.ToInt32(Request.Form["objid"]));
                model.Name = Request.Form["txtSubType"];
                model.Remark = Request.Form["txtRemark"];
                model.Person = Request.Form["txtPerson"];
                model.SubType = Convert.ToInt32(Request.Form["txtSubType"]);
                model.Money = Convert.ToDecimal(Request.Form["txtMoney"]);
                model.ReMoney = Convert.ToDecimal(Request.Form["txtReMoney"]);
                model.CZFloat = Convert.ToDecimal(Request.Form["txtCZFloat"]);
                model.Money = Convert.ToDecimal(Request.Form["txtMoney"]);
                if (model.ReMoney > model.Money * (1 + model.CZFloat))
                    return "提交失败，超出超支限额";
                decimal rmoney = Convert.ToDecimal(BLL.CommonBase.GetSingle("SELECT ISNULL(SUM(CASE WHEN ReMoney>[Money] THEN ReMoney ELSE [Money] END),0) FROM dbo.ObjSub WHERE ID<>" + model.ID+" and OBJID="+objmodel.ID+";"));
                decimal cc = model.ReMoney > model.Money ? model.ReMoney : model.Money;
                if ((rmoney + cc) > objmodel.Money)
                    return "提交失败，超出项目预算";

                result = BLL.ObjSub.Update(model);
            }
           
            if (result)
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}