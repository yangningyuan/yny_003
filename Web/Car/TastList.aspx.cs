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
			if (cartast.TState != 0&& cartast.TState != -1 && cartast.TState != 1)
				return "此任务状态不能取消";
			cartast.TState = 2;

            if (cartast.TType == 1)
            {
                int count = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_CarTast where TCode='" + cartast.Name + "';"));
                if (count > 0)
                    return "有卸车关联任务，不能取消";
            }

			if (BLL.C_CarTast.Update(cartast))
				return "取消成功";
			else
				return "取消失败";
		}

        protected override string btnModify_Click()
        {
            Model.C_CarTast cartast = BLL.C_CarTast.GetModel(Convert.ToInt32(Request.Form["tid"]));
            if (cartast.TState != 1 )
                return "此任务状态不能设为错误标记";

            cartast.TState = -2;
            if (BLL.C_CarTast.Update(cartast))
                return "设置成功，司机端可以修改后提交";
            else
                return "设置失败";
        }

        protected override string btnOther_Click()
        {
            Model.C_CarTast cartast = BLL.C_CarTast.GetModel(Convert.ToInt32(Request.Form["tid"]));
            if (cartast.TState != -2)
                return "此任务状态不能取消错误标记";

            cartast.TState = 1;
            if (BLL.C_CarTast.Update(cartast))
                return "取消成功";
            else
                return "取消失败";
        }
    }
}