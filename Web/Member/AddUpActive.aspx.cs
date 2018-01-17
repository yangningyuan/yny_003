using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.Member
{
    public partial class AddUpActive : BasePage
    {
        private static object obj = new object();
        protected override string btnModify_Click()
        {
            lock (obj)
            {
                decimal count = 0;
                string moneyType = "MHB";
                if (Request.Form["ddlmoneyType"] == "MJB")
                {
                    moneyType = "MJB";
                }
                else if (Request.Form["ddlmoneyType"] == "MCW")
                {
                    moneyType = "MCW";
                }
                try
                {
                    //count = decimal.Parse(Request.Form["txtAddCount"]);
                    //if (count < BLL.Configuration.Model.ActivateMinMoney || count > BLL.Configuration.Model.ActivateMaxMoney)
                    //{
                    //    return "投资金额必须在" + BLL.Configuration.Model.ActivateMinMoney + "-" + BLL.Configuration.Model.ActivateMaxMoney + "之间";
                    //}
                    //if (count + TModel.MConfig.SHMoney > BLL.Configuration.Model.ActivateMaxMoney)
                    //{
                    //    return "累计投资金额不能超过" + BLL.Configuration.Model.ActivateMaxMoney;
                    //}
                }
                catch
                {
                    throw new Exception("投资金额必须为整数大于0的数");
                }

                if (BLL.ChangeMoney.EnoughChange(TModel.MID, count, moneyType))
                {
                    return BllModel.UpMAgencyType(BLL.Configuration.Model.SHMoneyList["002"], TModel.MID, moneyType, TModel, count);
                }
                else
                {
                    return "您的股权不足，无法追加投资";
                }
            }
        }
    }
}