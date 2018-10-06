using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class LoadGoods : BasePage
	{
		protected Model.C_CarTast cartast = null;
		protected string strordsel = "";
		protected override void SetValue(string id)
		{
			cartast = BLL.C_CarTast.GetModel(int.Parse(id));
			cid.Value = id;
			Model.Order order = BLL.Order.GetModel(cartast.OCode);
			List<Model.OrderDetail> list = BLL.OrderDetail.GetList(" OrderCode='" + cartast.OCode + "' ");
			foreach (var item in list)
			{
				strordsel += "<option value='" + item.Code + "'>" + BLL.Goods.GetModel(item.GId).GName + "_可调度【" + (item.GCount - item.ReCount) + "】</option>";
			}
		}

		protected override string btnAdd_Click()
		{
			try 
			{
				Model.C_CarTast cartast = BLL.C_CarTast.GetModel(int.Parse(Request.Form["cid"]));
				if (cartast.TState == 1)
					return "非法操作，此任务已结束";
				decimal money =Convert.ToDecimal( Request.Form["txtGCount"]);
				Model.OrderDetail ord = BLL.OrderDetail.GetList(" ordercode='" + cartast.OCode + "' and  code='" + Request.Form["txtGoodList"] + "' ").FirstOrDefault();
				if (ord != null)
				{
					if (money <= 0)
					{
						return "输入数量有误或此商品已不可调度";
					}
					ord.ReCount = money;
					if (BLL.OrderDetail.Update(ord))
					{
						return "调度成功";
					}
					else {
						return "调度失败";
					}

				}
				else {
					return "数据有误，请重试";
				}
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}
	}
}