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
        protected List<Model.Account> listacc = null;
        protected override void SetPowerZone()
        {
             cid= Request.QueryString["cid"];
            listacc = BLL.Account.GetModelList(" id in("+cid+"); ");
            hcid.Value = cid;
            
            decimal money = listacc.Sum(a=>a.TotalMoney);
            htotalmoney.Value = money.ToString();
            totalmoney = money;
            Random rd = new Random();
            string xx= rd.Next(10000, 99999).ToString();
            acode = DateTime.Now.ToString("yyyyMMddHHmmss") + xx;
            Model.C_Supplier supplier = BLL.C_Supplier.GetModel(Convert.ToInt32(Request.QueryString["suppid"]));
            suppname = supplier.Name;
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
                if (Convert.ToDecimal(Request.Form["htotalmoney"])> supplier.OverMoney)
                {
                    return "预付款不足，不能结账";
                }
                supplier.OverMoney -= Convert.ToDecimal(Request.Form["htotalmoney"]);
                BLL.C_Supplier.Update(supplier, MyHs);
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
                c.PayMoney =ac.TotalMoney;
                c.Spare = "";
                c.Spare1 = Request.Form["hacode"];
                

                ac.comDate = DateTime.Now;
                ac.AStutas = 1;
                ac.ReMoney += c.PayMoney;//已付款加上
                BLL.Account.Update(ac, MyHs);
                BLL.AccountDetails.Add(c, MyHs);
            }
            Model.SubAccount account = new Model.SubAccount();
            account.ACode = Request.Form["hacode"];
            account.PayMoney = Convert.ToDecimal(Request.Form["htotalmoney"]);
            account.SuppID = supplier.ID;
            account.SuppName = supplier.Name;
            account.SuppType = supplier.Type;
            account.JZType =Convert.ToInt32( Request.Form["JZType"]);
            account.UserName = Request.Form["UserName"];
            BLL.SubAccount.Add(account,MyHs);

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