using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class BXAdd : BasePage
	{
		protected override string btnAdd_Click()
		{
			try
			{
				Model.C_Error apply = new Model.C_Error();
				apply.MID = TModel.MID;
				apply.CarCode= Request.Form["txtPZCode"];
				apply.EType= Request.Form["txtType"];
				apply.EDetails = Request.Form["txtDetails"];
				apply.Address = Request.Form["txtAddress"];
				apply.ImgUrl=Request.Form["uploadurl"];
				apply.CreateDate = DateTime.Now;
				if (BLL.C_Error.Add(apply) > 0)
				{
					return "报修申请已提交";
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