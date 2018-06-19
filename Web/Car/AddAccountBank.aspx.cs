using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class AddAccountBank :BasePage
    {
        protected override void SetPowerZone()
        {
          
        }
        protected override string btnModify_Click()
        {
            Model.C_SuppBank c = new Model.C_SuppBank();
            c.AccountName = Request.Form["AccountName"];
            //c.Money =Convert.ToDecimal( Request.Form["Money"]);
            //c.CardName = Request.Form["CardName"];
            //c.BankName = Request.Form["BankName"];

            if (string.IsNullOrEmpty(Request.Form["fid"]))
            {
                if (BLL.C_SuppBank.Add(c) > 0)
                {
                    return "添加成功";
                }
                else {
                    return "添加失败";
                }
            }
            else {
                c.ID = int.Parse(Request.Form["fid"]);
                if (BLL.C_SuppBank.Update(c))
                {
                    return "修改成功";
                }
                else {
                    return "修改失败";
                }
            }
        }

        protected override void SetValue(string id)
        {
            Model.C_SuppBank c = BLL.C_SuppBank.GetModel(int.Parse(id));
            AccountName.Value = c.AccountName;
            //Money.Value = c.Money.ToString();
            //CardName.Value = c.CardName;
            //BankName.Value = c.BankName;
            fid.Value = c.ID.ToString();
        }
    }
}