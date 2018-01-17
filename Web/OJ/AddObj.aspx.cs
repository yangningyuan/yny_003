using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.OJ
{
    public partial class AddObj : BasePage
    {

        protected string impstr = "";

        protected override void SetPowerZone()
        {
            txtFundID.DataSource = BLL.FundType.GetList(" 1 = 1  order by ID");
            txtFundID.DataTextField = "Name";
            txtFundID.DataValueField = "ID";
            txtFundID.DataBind();

            txtDepartID.DataSource = BLL.DepartType.GetList(" 1 = 1  order by ID");
            txtDepartID.DataTextField = "Name";
            txtDepartID.DataValueField = "ID";
            txtDepartID.DataBind();

          
            List<Model.ImpType> implist= BLL.ImpType.GetModelList(" 1=1 ORDER BY ID ");
            foreach (Model.ImpType item in implist)
            {
                impstr += "<input type='checkbox'  value='" + item.ID+ "' name='txtImpType' />" + item.Name+ "&nbsp;&nbsp;&nbsp;";
            }

        }

     
        protected override string btnModify_Click()
        {
            bool result = false;
            Model.Obj model = new Model.Obj();
            model.Name = Request.Form["txtName"];
            model.Remark = Request.Form["txtRemark"];
            model.Person = Request.Form["txtPerson"];
            model.ImpUnit = Request.Form["txtImpType"];
            model.FundID = Convert.ToInt32(Request.Form["txtFundID"]);
            model.TheNumID = Request.Form["txtTheNumID"];
            model.DepartID = Convert.ToInt32(Request.Form["txtDepartID"]);
            model.Money = Convert.ToDecimal(Request.Form["txtMoney"]);
            model.EndDate = DateTime.MaxValue;
            model.State = Convert.ToInt32(Request.Form["selState"]);

            model.StateDate = DateTime.Now;

            result = BLL.Obj.Add(model);

            if (result)
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}