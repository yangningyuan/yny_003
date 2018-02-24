using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class DelCar : BasePage
	{
		protected override void SetPowerZone()
		{
			Model.C_Mileage mile = BLL.C_Mileage.GetModelBywhere(" ( SIJI1='" + TModel.MID + "' or SIJI2='" + TModel.MID + "' ) AND DATEDIFF(DAY,CreateDate,GETDATE())=0 and type=0; ");//当天确认
			if (mile == null)//没有要确认的车辆里程
			{
				btnhtml.InnerHtml = "还未确认车辆里程，无需交车";
			}
			else {
				Model.C_Mileage mile1 = BLL.C_Mileage.GetModelBywhere(" ( SIJI1='" + TModel.MID + "' or SIJI2='" + TModel.MID + "' ) AND DATEDIFF(DAY,CreateDate,GETDATE())=0 and type=1; ");//当天确认
				if (mile1 == null)
				{
					txtSIJI1.Value = mile.SIJI1;
					txtSIJI2.Value = mile.SIJI2;
					txtCarCode.Value = mile.CarCode;
				}
				else { //已交车
					txtSIJI1.Value = mile1.SIJI1;
					txtSIJI2.Value = mile1.SIJI2;
					txtCarCode.Value = mile1.CarCode;
					txtMileage.Value = mile1.Mileage.ToString() ;
					btnhtml.InnerHtml = "已交车，请勿重复提交";

				}
			}
		}

		protected override string btnAdd_Click()
		{
			Model.C_CarTast ct = BLL.C_CarTast.GetModelBySJ(TModel.MID);

			Model.C_Mileage mile0 = BLL.C_Mileage.GetModelBywhere(" ( SIJI1='" + TModel.MID + "' or SIJI2='" + TModel.MID + "' ) AND DATEDIFF(DAY,CreateDate,GETDATE())=0 and type=0; ");//当天确认
			if (mile0 == null)
				return "今日未确认里程，请确认后交车";

			Model.C_Mileage mile = BLL.C_Mileage.GetModelBywhere(" ( SIJI1='" + TModel.MID + "' or SIJI2='" + TModel.MID + "' ) AND DATEDIFF(DAY,CreateDate,GETDATE())=0 and type=1; ");//当天确认
			if (mile != null)
				return "今日已交车，请勿重复提交";
			
			try
			{
				int licheng = Convert.ToInt32(Request.Form["txtMileage"]);
				Model.C_Mileage cm = new Model.C_Mileage();
				cm.CarCode = ct.Spare2;
				cm.SIJI1 = ct.CarSJ1;
				cm.SIJI2 = ct.CarSJ2;
				cm.Mileage = licheng;
				cm.DiffCount =Convert.ToInt32( cm.Mileage - mile0.Mileage);
				cm.Oid = 0;
				cm.Type = 1;
				cm.CreateDate = DateTime.Now;
				if (cm.DiffCount < 0)
					return "里程有误，交车里程不能小于确认里程";
				if (BLL.C_Mileage.Add(cm) > 0)
				{
					return "交车成功";
				}
				else {
					return "交车失败，请重试";
				}
			}
			catch (Exception e)
			{
				return e.Message;
			}


		}
	}
}