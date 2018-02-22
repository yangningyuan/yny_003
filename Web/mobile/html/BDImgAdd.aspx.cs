using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class BDImgAdd : BasePage
	{
		protected Model.C_CarTast cartast = null;
		protected List<Model.C_CostDetalis> listcost = null;
		protected override void SetValue(string id)
		{
			cartast = BLL.C_CarTast.GetModel(int.Parse(id));
			listcost = BLL.C_CostDetalis.GetModelList(" CID=" + cartast.ID);
			cid.Value = id;
		}

		protected override string btnAdd_Click()
		{
			try
			{
				Model.C_CarTast cartast = BLL.C_CarTast.GetModel(int.Parse(Request.Form["cid"]));
				List<Model.C_CostDetalis> listcost = BLL.C_CostDetalis.GetModelList(" CID=" + cartast.ID);
				if (cartast.TState == 1)
					return "非法操作，此任务已结束";

				cartast.BDImg = Request.Form["uploadurl"];
				
				if (BLL.C_CarTast.Update(cartast))
				{
					return "上传成功";
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