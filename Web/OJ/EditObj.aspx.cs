using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.OJ
{
    public partial class EditObj : BasePage
    {
        protected override void SetValue(string id)
        {
            //NoticeModel = BLL.Obj.GetModel(int.Parse(id));
        }

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

            Model.Obj model = BLL.Obj.GetModel(Convert.ToInt32(Request.QueryString["ID"]));
            oID.Value = Request.QueryString["ID"];
            txtName.Value = model.Name;
            txtRemark.Value = model.Remark;
            txtPerson.Value = model.Person;
            //txtImpUnit.Value = model.ImpUnit;
            txtFundID.Value = model.FundID.ToString();
            txtTheNumID.Value = model.TheNumID;
            txtDepartID.Value = model.DepartID.ToString();
            selState.Value = model.State.ToString();
            txtMoney.Value = model.Money.ToString();
            string str = "";
            if (!string.IsNullOrEmpty(model.ImpUnit)) //有颜色属性
            {
                string[] arraylist = model.ImpUnit.Split(',');

                for (int i = 0; i < arraylist.Length; i++)
                {
                    Model.ImpType amodel = BLL.ImpType.GetModel(int.Parse(arraylist[i]));
                    if (amodel != null) //如果有属性的话
                    {
                        str += "<input type=\"checkbox\" checked=\"checked\" name=\"txtImpType\" value=" + arraylist[i] + ">" + amodel.Name;
                    }
                }
                List<Model.ImpType> adt = BLL.ImpType.GetModelList("  ID NOT IN(" + model.ImpUnit.Substring(0, model.ImpUnit.Length) + ") order by ID ASC");
                if (adt.Count > 0)
                {
                    for (int i = 0; i < adt.Count; i++)
                    {
                        str += "<input type=\"checkbox\"  name=\"txtImpType\" value=" + adt[i].ID + ">" + adt[i].Name;
                    }
                }
            }
            impstr = str;
        }



        protected override string btnModify_Click()
        {
            bool result = false;
            Model.Obj model = BLL.Obj.GetModel(Convert.ToInt32(Request.Form["oID"]));
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

            if (model.EndDate == DateTime.MaxValue && model.State == 1)
            {
                model.EndDate = DateTime.Now;
            }
            result = BLL.Obj.Update(model);

            if (result)
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}