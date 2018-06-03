using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class AccountDetailsDown : BasePage
    {
        protected override string btnModify_Click()
        {
            Hashtable MyHs = new Hashtable();
            Model.Account ac = BLL.Account.GetModel(int.Parse(Request.Form["fid"]));
            Model.AccountDetails c = new Model.AccountDetails();
            Model.C_Supplier cs = BLL.C_Supplier.GetModel(ac.SupplierID);
            c.AID = ac.ID;
            c.CName = ac.CName;
            c.TotalMoney = ac.TotalMoney;
            c.ReMoney = ac.ReMoney;
            c.PayMoney = Convert.ToDecimal(Request.Form["PayMoney"]);
            c.Spare = Request.Form["Spare"];

            ac.ReMoney += c.PayMoney;//已付款加上
            cs.OverMoney -= c.PayMoney;//预付款减少
            if (c.PayMoney < 0)
            {
                return "输入金额有误";
            }
            if (ac.ReMoney > ac.TotalMoney)
            {
                return "超出付款总金额";
            }
            if (ac.TotalMoney <= ac.ReMoney)
            {
                ac.comDate = DateTime.Now;
                ac.AStutas = 1;
            }
            if (Request.Form["PayType"] == "1")//如若抵扣
            {
                if (c.PayMoney > cs.OverMoney)
                {
                    return "预付款不足，请重新输入";
                }
                BLL.C_Supplier.Update(cs, MyHs);
            }

            BLL.Account.Update(ac, MyHs);
            BLL.AccountDetails.Update(c, MyHs);

            if (BLL.CommonBase.RunHashtable(MyHs))
            {
                return "结账成功";
            }
            else {
                return "结账失败";
            }

        }

        protected override void SetValue(string id)
        {
            Model.Account c = BLL.Account.GetModel(int.Parse(id));
            CName.Value = c.CName;
            SupplierName.Value = c.SupplierName;
            TotalMoney.Value = c.TotalMoney.ToString();
            ReMoney.Value = c.ReMoney.ToString();

            yue.Value = BLL.C_Supplier.GetModel(c.SupplierID).OverMoney.ToString();

            fid.Value = c.ID.ToString();
        }
    }
}