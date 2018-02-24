using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class VerCar : BasePage
	{
		protected override void SetPowerZone()
		{
			Model.C_Mileage mile= BLL.C_Mileage.GetModelBywhere(" ( SIJI1='"+TModel.MID+ "' or SIJI2='"+TModel.MID+ "' ) AND DATEDIFF(DAY,CreateDate,GETDATE())=0 and type=0; ");//当天确认
			if (mile == null)
			{
				Model.C_CarTast cm = BLL.C_CarTast.GetModelBySJ(TModel.MID);
				if (cm == null)
				{
					btnhtml.InnerHtml = "无任务，无需确认车辆里程";
				}
				else {
					txtSIJI1.Value = cm.CarSJ1;
					txtSIJI2.Value = cm.CarSJ2;
					txtCarCode.Value = cm.Spare2;
				}
			}
			else {
				txtSIJI1.Value = mile.SIJI1;
				txtSIJI2.Value = mile.SIJI2;
				txtCarCode.Value = mile.CarCode;
				txtMileage.Value = mile.Mileage.ToString();
				btnhtml.InnerHtml = "已确认里程";
			}			
		}

		protected override string btnAdd_Click()
		{
			Model.C_CarTast ct = BLL.C_CarTast.GetModelBySJ(TModel.MID);

			Model.C_Mileage mile = BLL.C_Mileage.GetModelBywhere(" ( SIJI1='" + TModel.MID + "' or SIJI2='" + TModel.MID + "' ) AND DATEDIFF(DAY,CreateDate,GETDATE())=0 and type=0; ");//当天确认
			if (mile != null)
				return "已确认里程，请勿重复提交";
			if (ct.TState != 0)
				return "此任务不能确认里程";
			try
			{
				int licheng =Convert.ToInt32( Request.Form["txtMileage"]);
				Model.C_Mileage cm = new Model.C_Mileage();
				cm.CarCode = ct.Spare2;
				cm.SIJI1 = ct.CarSJ1;
				cm.SIJI2 = ct.CarSJ2;
				cm.Mileage = licheng;
				cm.Oid = 0;
				cm.Type = 0;
				cm.CreateDate = DateTime.Now;
				if (BLL.C_Mileage.Add(cm) > 0)
				{
					return "确认里程成功";
				}
				else {
					return "确认里程失败，请重试";
				}
			}
			catch (Exception e)
			{
				return e.Message;
			}


		}
	}
}