using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class TastList : BasePage
    {
		protected override string btnAdd_Click()
		{
			Model.C_CarTast cartast= BLL.C_CarTast.GetModel(Convert.ToInt32(Request.Form["tid"]));
			if (cartast.TState != 0)
				return "此任务状态已改变，请刷新重试";

			cartast.TState = 2;
			if (BLL.C_CarTast.Update(cartast))
				return "取消成功";
			else
				return "取消失败";
		}
	}
}