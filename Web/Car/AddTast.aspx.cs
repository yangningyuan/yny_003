using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
	public partial class AddTast : BasePage
	{
		public object HashTable { get; private set; }

		protected override void SetPowerZone()
		{
			CostType.DataSource = BLL.C_CostType.GetList(" 1 = 1  order by ID");
			CostType.DataTextField = "Name";
			CostType.DataValueField = "ID";
			CostType.DataBind();


			txtGood.DataSource = BLL.Goods.GetList(" IsDeleted = 0 order by GID");
			txtGood.DataTextField = "GName";
			txtGood.DataValueField = "GID";
			txtGood.DataBind();


			if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
			{
				ocode.Value = Request.QueryString["oid"];
				oid.Value = Request.QueryString["oid"];
			}
			//ocode.Disabled = true;
		}
		protected override string btnModify_Click()
		{
			Model.C_CarTast c = new Model.C_CarTast();
			c.Name = Request.Form["Name"];
			c.TType = int.Parse(Request.Form["TType"]);
			c.SupplierName = Request.Form["SupplierName"];
			c.SupplierAddress = Request.Form["SupplierAddress"];
			c.SupplierTelName = Request.Form["SupplierTelName"];
			c.SupplierTel = Request.Form["SupplierTel"];
			c.Spare2 = Request.Form["Spare2"];
			c.CSpare2 = Request.Form["CSpare2"];
			c.CarSJ1 = Request.Form["CarSJ1"];
			c.CarSJ2 = Request.Form["CarSJ2"];
			c.CostType = int.Parse(Request.Form["CostType"]);
			c.BDImg = Request.Form["uploadurl"];
			//c.OCode = Request.Form["ocode"];
			c.Spare1 = Request.Form["Spare1"];
			c.ComDate =DateTime.Parse( Request.Form["ComDate"]);

			#region 司机车辆验证
			Model.C_Car car = BLL.C_Car.GetModelByCode(c.Spare2);
			if (car == null)
				return "此牵引车不存在，请正确输入车辆牌照";
			if (!string.IsNullOrEmpty(car.Spare1))
				return "此牵引车任务未完成，请选择别的车辆";
			if (!string.IsNullOrEmpty(c.CSpare2))
			{
				Model.C_Car car2 = BLL.C_Car.GetModelByCode(c.CSpare2);
				if (car2 == null)
					return "此挂车不存在，请正确输入车辆牌照";
				if (!string.IsNullOrEmpty(car2.Spare1))
					return "此挂车任务未完成，请选择别的车辆";
			}

			Model.Member siji1 = BLL.Member.GetModelByMID(c.CarSJ1);
			if (siji1 != null)
			{
				if (siji1.FMID != "1")
					return "此司机不是主司机";
			}
			else
				return "主司机不存在";
			Model.Member siji2 = BLL.Member.GetModelByMID(c.CarSJ2);
			if (siji2 != null)
			{
				if (siji2.FMID != "2"&& siji2.FMID != "3")
					return "此司机不是副司机";
			}
			else
				return "副司机不存在";
			#endregion

			if (string.IsNullOrEmpty(Request.Form["fid"]))
			{
				//if (string.IsNullOrEmpty(Request.Form["oid"]))
				//{
				//	c.OCode = "";
				//}
				//else {
				//	c.OCode = Request.Form["oid"];
				//}
				Hashtable MyHs = new Hashtable();

				#region 生成商品订单
				string code = "";
				string goodid = Request.Form["txtGood"];
				Model.Goods go = BLL.Goods.GetModel(goodid);
				if (go == null)
					return "此商品找不到";

				if (!string.IsNullOrEmpty(goodid))
				{
					int goodcount = 0;
					decimal goodprice = 0;
					try
					{
						goodcount = Convert.ToInt32(Request.Form["txtGoodCount"]);
						goodprice = Convert.ToDecimal(Request.Form["txtGoodPrice"]);
					}
					catch (Exception e)
					{
						return e.Message;
					}
					//先生成订单主表
					Model.Order order = new Model.Order();
					DateTime dt = DateTime.Now;
					code = dt.ToString("yyyyMMddHHmmssfff");// dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();
					order.Code = code;
					order.ReceiveId = 0;
					order.CreatedBy = TModel.MID;
					order.CreatedTime = DateTime.Now;
					//order.GoodCount
					int count = goodcount; decimal totalMoney = goodcount * goodprice;
					string error = string.Empty;

					//生成订单明细表
					Model.OrderDetail od = new Model.OrderDetail();
					od.BuyPrice = goodprice;
					od.Code = GetGuid();
					od.CreatedBy = TModel.MID;
					od.CreatedTime = DateTime.Now;
					od.GCount = count;
					od.GId = Convert.ToInt32(goodid);
					//查看库存数量是否足够，不够的话暂时不能提交订单

					if (go.SellingCount < od.GCount)
					{
						error += "商品：" + go.GName + "库存不足，请联系管理员";
					}
					//go.SelledCount = go.SelledCount + od.GCount;//完成订单时候加减库存
					//go.SellingCount = go.SellingCount - od.GCount;
					//BLL.Goods.Update(go, hs);

					od.IsDeleted = false;
					od.OrderCode = order.Code;
					od.Status = 1;
					od.TotalMoney = od.GCount * od.BuyPrice;
					totalMoney += od.TotalMoney;
					BLL.OrderDetail.Insert(od, MyHs);

					order.GoodCount = count;
					order.IsDeleted = false;
					order.MID = c.SupplierName;
					order.OrderTime = DateTime.Now;
					order.TotalPrice = totalMoney;
					order.DisCountTotalPrice = order.TotalPrice;// * BLL.Configuration.Model.E_GWDiscount;

					order.ExpressCompany = c.Name;
					order.Status = 2;
					c.OCode = order.Code;
					BLL.Order.Insert(order, MyHs);

					if (!string.IsNullOrEmpty(error))
					{
						return error;
					}
				}

				#endregion

				int tid = BLL.C_CarTast.Add(c);
				if (tid > 0)
				{
					car.Spare1 = tid.ToString();
					BLL.C_Car.Update(car, MyHs);
				}
				else {
					return "任务添加失败";
				}
				if (BLL.CommonBase.RunHashtable(MyHs))
				{
					return "添加成功";
				}
				else {
					return "添加失败";
				}
			}
			else {
				c.ID = int.Parse(Request.Form["fid"]);

				if (BLL.C_CarTast.Update(c))
				{
					return "修改成功";
				}
				else {
					return "修改失败";
				}
			}
		}


		protected override void SetValue(string id)
		{
			Model.C_CarTast c = BLL.C_CarTast.GetModel(int.Parse(id));
			Name.Value = c.Name;
			TType.Value = c.TType.ToString();
			SupplierName.Value = c.SupplierName;
			SupplierAddress.Value = c.SupplierAddress;
			SupplierTelName.Value = c.SupplierTelName;
			SupplierTel.Value = c.SupplierTel;
			Spare2.Value = c.Spare2.ToString();
			CSpare2.Value = c.CSpare2.ToString();
			CarSJ1.Value = c.CarSJ1.ToString();
			CarSJ2.Value = c.CarSJ2.ToString();
			CostType.Value = c.CostType.ToString();
			uploadurl.Value = c.BDImg.ToString();
			Spare1.Value = c.Spare1.ToString();
			ocode.Value = c.OCode;
			fid.Value = c.ID.ToString();
			oid.Value = c.OCode.ToString();
			ComDate.Value = c.ComDate.ToString();

			if (!string.IsNullOrEmpty(Request.QueryString["oid"]))
			{
				ocode.Value = Request.QueryString["oid"];
			}
		}

		protected override string btnAdd_Click()
		{
			 Model.Member mm1= BLL.Member.GetModelByMID(Request.Form["CarSJ1"]);
			if (mm1 == null)
				return "此司机不存在";
			if (mm1.FMID != "1")
				return "此司机不是主司机";
			return string.Format("姓名：{0}，联系电话：{1}",mm1.MName,mm1.Tel);
		}
		protected override string btnOther_Click()
		{
			Model.Member mm1 = BLL.Member.GetModelByMID(Request.Form["CarSJ2"]);
			if (mm1 == null)
				return "此司机不存在";
			if (mm1.FMID != "2"&&mm1.FMID!="3")
				return "此司机不是副司机";
			return string.Format("姓名：{0}，联系电话：{1}", mm1.MName, mm1.Tel);
		}
	}
}