using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.OJ
{
    public partial class AddObjSub : BasePage
    {
       
        protected override void SetPowerZone()
        {
            txtSubType.DataSource = BLL.ObjSubType.GetList(" 1 = 1  order by ID");
            txtSubType.DataTextField = "Name";
            txtSubType.DataValueField = "ID";
            txtSubType.DataBind();
            objid.Value = Request.QueryString["id"];
            Model.Obj obj = BLL.Obj.GetModel(Convert.ToInt32(Request.QueryString["id"]));
            txtPerson.Value = obj.Person;
        }

        protected override string btnModify_Click()
        {
            bool result = false;
            Model.ObjSub model = new Model.ObjSub();
            Model.Obj objmodel = BLL.Obj.GetModel(Convert.ToInt32(Request.Form["objid"]));
            model.ObjID = objmodel.ID;
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
            decimal rmoney = Convert.ToDecimal(BLL.CommonBase.GetSingle("SELECT ISNULL(SUM(CASE WHEN ReMoney>[Money] THEN ReMoney ELSE [Money] END),0) FROM dbo.ObjSub WHERE  OBJID=" + objmodel.ID + ";"));
            decimal cc = model.ReMoney > model.Money ? model.ReMoney : model.Money;
            if ((rmoney + cc) > objmodel.Money)
                return "提交失败，超出项目预算";
            result = BLL.ObjSub.Add(model);

            if (result)
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}