using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class SubAccount :BasePage
    {
        protected override void SetPowerZone()
        {
            SupplierName.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0  and Type=2 order by ID");
            SupplierName.DataTextField = "Name";
            SupplierName.DataValueField = "ID";
            SupplierName.DataBind();
            SupplierName.Items.Insert(0, "--请选择--");
        }

        protected override string btnModify_Click()
        {
            int oid=Convert.ToInt32( Request.Form["oid"]);
            Model.SubAccount submodel = BLL.SubAccount.GetModel(oid);
            Model.C_Supplier suppmodel = BLL.C_Supplier.GetModel(submodel.SuppID);
            if (submodel == null)
                return "未查询到数据";
            Hashtable MyHs = new Hashtable();
            List<Model.AccountDetails> listad= BLL.AccountDetails.GetModelList(" Spare1='"+ submodel.ACode+ "' ");

            suppmodel.OverMoney += submodel.PayMoney;
            BLL.C_Supplier.Update(suppmodel, MyHs);

            MyHs.Add("delete  subaccount where id="+oid+";",null);
            foreach (var item in listad)
            {
                MyHs.Add("delete AccountDetails where id="+item.ID+";", null);
                Model.Account mamodel= BLL.Account.GetModelName(item.CName);
                mamodel.AStutas = 0;
                mamodel.ReMoney = 0;
                mamodel.comDate = DateTime.MaxValue;
                BLL.Account.Update(mamodel,MyHs);
            }

            if (BLL.CommonBase.RunHashtable(MyHs))
            {
                return "反结账成功";
            }
            else {
                return "反结账失败";
            }
        }
    }
}