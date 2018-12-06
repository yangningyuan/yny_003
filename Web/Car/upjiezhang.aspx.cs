using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class upjiezhang : BasePage
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
            
            listacc = BLL.Account.GetModelList(" id in(" + cid + "); ");
            hcid.Value = cid;

            decimal money = listacc.Sum(a => a.TotalMoney);
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
            List<Model.Account> listaccx = BLL.Account.GetModelList(" id in(" + Request.Form["hcid"] + "); ");

            Model.C_Supplier supplier = BLL.C_Supplier.GetModel(Convert.ToInt32(Request.Form["hsuppid"]));
            if (Request.Form["JZType"] == "1")//如若抵扣
            {
                if (Convert.ToDecimal(Request.Form["htotalmoney"]) > supplier.OverMoney)
                {
                    return "预付款不足，不能结账";
                }
                
                supplier.OverMoney -= Convert.ToDecimal(Request.Form["htotalmoney"]);
                BLL.C_Supplier.Update(supplier, MyHs);
            }

            decimal blanmoney = 0;
            if (Request.Form["JZType"] == "3")
            {
                blanmoney = supplier.OverMoney;
            }
            
            foreach (var ac in listaccx)
            {
                if (ac.AStutas == 1)
                    return "请勿重复结账";
                //Model.Account ac = BLL.Account.GetModel(int.Parse(Request.Form["fid"]));
                Model.AccountDetails c = new Model.AccountDetails();
                c.AID = ac.ID;
                c.CName = ac.CName;
                c.TotalMoney = ac.TotalMoney;
                c.ReMoney = ac.ReMoney;
                c.Remark = Request.Form["Remark"];
                c.PayMoney = ac.TotalMoney;

                c.Spare1 = Request.Form["hacode"];
                if (Request.Form["JZType"] == "2")
                {
                    if (Convert.ToDecimal(Request.Form["htotalmoney"]) > Convert.ToDecimal(Request.Form["PayMoney"]))
                    {
                        return "付款金额不能低于结账金额";
                    }
                    Model.C_SuppBank suppbank = BLL.C_SuppBank.GetModel(Convert.ToInt32(Request.Form["FKAccount"]));
                    c.Spare = suppbank.AccountName;
                }
                
                if (Request.Form["JZType"] == "3")
                {
                    if (Convert.ToDecimal(Request.Form["htotalmoney"]) >blanmoney + Convert.ToDecimal(Request.Form["PayMoney"]))
                    {
                        return "付款金额不能低于结账金额";
                    }
                    if (supplier.OverMoney >= Convert.ToDecimal(Request.Form["PayMoney"]))
                    {
                        return "余额足够结账，请选择余额结账";
                    }
                    else {
                        Model.C_SuppBank suppbank = BLL.C_SuppBank.GetModel(Convert.ToInt32(Request.Form["FKAccount"]));
                        c.Spare = suppbank.AccountName;
                    }
                }

                ac.comDate = DateTime.Now;
                ac.AStutas = 1;
                ac.ReMoney += c.PayMoney;//已付款加上
                BLL.Account.Update(ac, MyHs);
                BLL.AccountDetails.Add(c, MyHs);
            }

            if (Request.Form["JZType"] == "2")
            {
                decimal money = Convert.ToDecimal(Request.Form["PayMoney"]) - Convert.ToDecimal(Request.Form["htotalmoney"]);
                supplier.OverMoney += money;
                BLL.C_Supplier.Update(supplier, MyHs);
            }
            if (Request.Form["JZType"] == "3")
            {
                decimal money = (Convert.ToDecimal(Request.Form["PayMoney"])+blanmoney) - Convert.ToDecimal(Request.Form["htotalmoney"]);
                supplier.OverMoney = money;
                BLL.C_Supplier.Update(supplier, MyHs);
            }

            Model.SubAccount account = new Model.SubAccount();
            account.ACode = Request.Form["hacode"];
            account.PayMoney = Convert.ToDecimal(Request.Form["htotalmoney"]);
            account.SuppID = supplier.ID;
            account.SuppName = supplier.Name;
            account.SuppType = supplier.Type;
            account.Balance = blanmoney;
            account.Spare2 = Request.Form["Remark"];
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