using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class upjiezhang2 : BasePage
    {
        protected string cid = "";
        protected string acode = "";
        protected string suppname = "";
        protected decimal totalmoney = 0;
        protected decimal blanmoney = 0;
        protected List<Model.Account> listacc = null;
        protected List<Model.C_SuppBank> listbank = null;
        protected override void SetPowerZone()
        {
            listbank = BLL.C_SuppBank.GetModelList("1=1");



            cid = Request.QueryString["cid"];
            //listacc = BLL.Account.GetModelList(" id in(" + cid + "); ");
            hcid.Value = cid;

            decimal money = 0;
            htotalmoney.Value = money.ToString();
            totalmoney = money;
            Random rd = new Random();
            string xx = rd.Next(10000, 99999).ToString();
            acode = DateTime.Now.ToString("yyyyMMddHHmmss") + xx;
            Model.C_Supplier supplier = BLL.C_Supplier.GetModel(Convert.ToInt32(Request.QueryString["suppid"]));
            suppname = supplier.Name;
            blanmoney = supplier.OverMoney;
            hsuppid.Value = supplier.ID.ToString();
            hacode.Value = acode;
        }

        protected override string btnModify_Click()
        {
            Hashtable MyHs = new Hashtable();

            Model.C_Supplier supplier = BLL.C_Supplier.GetModel(Convert.ToInt32(Request.Form["hsuppid"]));


            decimal blanmoney = 0;
            //if (Request.Form["JZType"] == "3")
            //{
            //    blanmoney = supplier.OverMoney;
            //}

            if (Request.Form["JZType"] == "2")
            {
                decimal money = Convert.ToDecimal(Request.Form["PayMoney"]) - Convert.ToDecimal(Request.Form["htotalmoney"]);
                supplier.OverMoney += money;
                BLL.C_Supplier.Update(supplier, MyHs);
            }
            if (Request.Form["JZType"] == "3")
            {
                decimal money = (Convert.ToDecimal(Request.Form["PayMoney"]) + blanmoney) - Convert.ToDecimal(Request.Form["htotalmoney"]);
                supplier.OverMoney += money;
                BLL.C_Supplier.Update(supplier, MyHs);
            }

            Model.SubAccount account = new Model.SubAccount();
            account.ACode = Request.Form["hacode"];
            account.PayMoney = Convert.ToDecimal(Request.Form["PayMoney"]);
            account.SuppID = supplier.ID;
            account.SuppName = supplier.Name;
            account.SuppType = supplier.Type;
            account.Balance = blanmoney;
            account.JZType = Convert.ToInt32(Request.Form["JZType"]);
            account.UserName = Request.Form["UserName"];
            BLL.SubAccount.Add(account, MyHs);

            if (BLL.CommonBase.RunHashtable(MyHs))
            {
                return "结账成功";
            }
            else {
                return "结账失败";
            }

        }
    }
}