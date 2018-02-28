using System;
using System.Collections;
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

			if (cartast.TType == 1 || cartast.TType == 2)
			{
				if (string.IsNullOrEmpty(cartast.BDImg))
					return "请上传磅单图片";

				
				List<Model.OrderDetail> listord2 = null;
				if (!string.IsNullOrEmpty(cartast.OCode))
				{
					order = BLL.Order.GetModel(cartast.OCode);
					listord2 = order.OrderDetail;
				}
				if (listord2.Sum(m => m.ReCount) <= 0)
					return "未查询到实际装车/卸车数量，不能完成";
			}
            Hashtable MyHs = new Hashtable();
            Model.C_Car c1= BLL.C_Car.GetModelByCode(cartast.Spare2);
            c1.Spare1 = "";
            BLL.C_Car.Update(c1, MyHs);
            Model.C_Car c2 = BLL.C_Car.GetModelByCode(cartast.CSpare2);
            if (c2 != null)
            {
                c2.Spare1 = "";
                BLL.C_Car.Update(c2, MyHs);
            }
            BLL.C_CarTast.Update(cartast, MyHs);
            if (BLL.CommonBase.RunHashtable(MyHs))
			{
				return "结束任务成功";
			}
			else {
				return "数据有误，结束任务失败";
			}
		}
	}
}