using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class JKChange : BasePage
	{
		protected override string btnAdd_Click()
		{
			try
			{
				int money = Convert.ToInt32(Request.Form["txtMHB"]);
				if (money > 0) 
				{
					Model.C_LoanApply apply = new Model.C_LoanApply();
					apply.ApplyMID = TModel.MID;
					apply.Money = money;
					apply.RealMoney = 0;
					apply.CareteDate = DateTime.Now;
					apply.RealDate = DateTime.MaxValue;
					apply.FFType = Request.Form["txtFFType"];
					if (BLL.C_LoanApply.Add(apply) > 0)
					{
						return "借款申请已提交";
					}else {
						return "数据有误，请重试";
					}
				 }else {
					return "请输入正确的金额";
				 }
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}
	}
}