using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class TastView : BasePage
	{
		protected Model.Order order = null;
		protected Model.C_CarTast cartast = null;
		protected List<Model.OrderDetail> listord = null;
		protected List<Model.C_CostDetalis> listcost = null;
		protected override void SetValue(string id)
		{
			cartast = BLL.C_CarTast.GetModel(int.Parse(id));
			cid.Value = id;
			if (!string.IsNullOrEmpty(cartast.OCode))
			{
				order = BLL.Order.GetModel(cartast.OCode);
				listord = order.OrderDetail;
			}
			listcost = BLL.C_CostDetalis.GetModelList(" CID="+order.Id);
			if (cartast.TState == 1) 
			{
				anbtn.Visible = false;
			 }
		}

		protected override string btnAdd_Click()
		{
			Model.C_CarTast cartast= BLL.C_CarTast.GetModel(int.Parse(Request.Form["cid"]));
			if (cartast.TState == 1)
				return "状态已改变,请勿重复提交";
			cartast.TState = 1;
			if (BLL.C_CarTast.Update(cartast))
			{
				return "此任务已结束";
			}
			else {
				return "数据有误，结束任务失败";
			}
		}
	}
}