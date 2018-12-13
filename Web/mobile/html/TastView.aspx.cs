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
        protected Model.C_Supplier supplier = null;
		protected List<Model.OrderDetail> listord = null;
		protected List<Model.C_CostDetalis> listcost = null;
        protected string zhusiji = "";
        protected string fusiji = "";

        //装车信息
        protected string tcode = "";
        protected Model.C_CarTast CTModel = new Model.C_CarTast();
        protected Model.C_Supplier SuppModel = new Model.C_Supplier();
        protected Model.OrderDetail OdModel = new Model.OrderDetail();
        protected Model.Goods Good = new Model.Goods();
        protected List<CarTast> XCList = new List<CarTast>();

        

        protected override void SetValue(string id)
		{
			cartast = BLL.C_CarTast.GetModel(int.Parse(id));
            supplier = BLL.C_Supplier.GetModel(int.Parse(cartast.SupplierName));

            cid.Value = id;
			if (!string.IsNullOrEmpty(cartast.OCode))
			{
				order = BLL.Order.GetModel(cartast.OCode);
				listord = order.OrderDetail;
			}
            if (order != null)
            {
                listcost = BLL.C_CostDetalis.GetModelList(" CID=" + order.Id);
            }
			if (cartast.TState == 1||!TModel.Role.SiJi) 
			{
				anbtn.Visible = false;
			 }

            Model.Member zm = BLL.Member.GetModelByMID(cartast.CarSJ1);
            if (zm != null)
                zhusiji = zm.MName;
            Model.Member fm = BLL.Member.GetModelByMID(cartast.CarSJ2);
            if (fm != null)
                fusiji = fm.MName;

            //装车信息
            if (cartast.TType != 1)
            {
                xcView.Visible = false;
                tcode = cartast.TCode;
                CTModel = BLL.C_CarTast.GetModelname(tcode);
                if (CTModel != null)
                {
                    SuppModel = BLL.C_Supplier.GetModel(Convert.ToInt32(CTModel.SupplierName));
                    if (!string.IsNullOrEmpty(CTModel.OCode))
                    {
                        OdModel = BLL.OrderDetail.GetList(" ordercode='" + CTModel.OCode + "'; ").FirstOrDefault();
                        Good = BLL.Goods.GetModel(OdModel.GId);
                    }
                }
            }
            else {
                zcView.Visible = false;
                List<Model.C_CarTast> carList = BLL.C_CarTast.GetModelList(" TCode='"+ cartast.Name+ "' ");
                foreach (var item in carList)
                {
                    CarTast cModel = new CarTast();
                    cModel.Code = item.Name;
                    cModel.Supp = BLL.C_Supplier.GetModel(Convert.ToInt32(item.SupplierName)).Name;
                    Model.OrderDetail XCod = BLL.OrderDetail.GetModelCode(item.OCode);
                    if (XCod != null)
                    {
                        cModel.Count = XCod.GCount;
                        cModel.ReCount = XCod.ReCount;
                        cModel.GoodName = BLL.Goods.GetModel(Convert.ToInt32(XCod.GId)).GName;
                    }
                    cModel.CreateTime = item.CreateDate;
                    XCList.Add(cModel);
                }
            }
        }

        protected object obj = new object();
		protected override string btnAdd_Click()
		{
            lock (obj)
            {
                Model.C_CarTast cartast = BLL.C_CarTast.GetModel(int.Parse(Request.Form["cid"]));
                decimal retotalMoney = 0;//实际总额
                if (cartast.TState == 1)
                    return "状态已改变,请勿重复提交";
                cartast.TState = 1;

                decimal recount = 0;
                decimal reprice = 0;
                string SJ1 = "";
                string SJ2 = "";
                string gname = "";
                string unit = "";
                if (cartast.TType == 1 || cartast.TType == 2)
                {
                    if (string.IsNullOrEmpty(cartast.BDImg))
                        return "请上传磅单图片";


                    List<Model.OrderDetail> listord2 = null;
                    if (!string.IsNullOrEmpty(cartast.OCode))
                    {
                        order = BLL.Order.GetModel(cartast.OCode);
                        listord2 = order.OrderDetail;
                        Model.OrderDetail od = BLL.OrderDetail.GetModelCode(cartast.OCode);
                        if (od != null)
                        {
                            retotalMoney = od.ReCount * od.BuyPrice;
                            recount = od.ReCount;
                            reprice = od.BuyPrice;

                            Model.Goods mg= BLL.Goods.GetModel(od.GId);
                            if (mg != null)
                            {
                                gname = mg.GName;
                                unit = mg.Unit;
                            }
                            
                        }
                    }
                    if (listord2.Sum(m => m.ReCount) <= 0)
                        return "未查询到实际装车/卸车数量，不能完成";
                }
                Hashtable MyHs = new Hashtable();
                Model.C_Car c1 = BLL.C_Car.GetModelByCode(cartast.Spare2);
                c1.Spare1 = "";
                BLL.C_Car.Update(c1, MyHs);
                Model.C_Car c2 = BLL.C_Car.GetModelByCode(cartast.CSpare2);
                if (c2 != null)
                {
                    c2.Spare1 = "";
                    BLL.C_Car.Update(c2, MyHs);
                }
                BLL.C_CarTast.Update(cartast, MyHs);

                if (cartast.TType == 1 || cartast.TType == 2)
                {
                    Model.Member mc1 = BLL.Member.GetModelByMID(cartast.CarSJ1);
                    Model.Member mc2 = BLL.Member.GetModelByMID(cartast.CarSJ2);
                    if (mc1 != null)
                        SJ1 = mc1.MName;
                    if (mc2 != null)
                        SJ2= mc2.MName;

                    Model.Account acc = new Model.Account();
                    acc.CID = cartast.ID;
                    acc.CName = cartast.Name;
                    acc.AType = cartast.TType == 1 ? 0 : 1;
                    acc.SupplierID = Convert.ToInt32(cartast.SupplierName);
                    supplier = BLL.C_Supplier.GetModel(int.Parse(cartast.SupplierName));
                    acc.SupplierName = supplier.Name;
                    acc.TotalMoney = retotalMoney;
                    acc.ReMoney = 0;
                    acc.CreateDate = DateTime.Now;
                    acc.AStutas = 0;
                    acc.comDate = DateTime.MaxValue;
                    acc.OrderCount = recount;
                    acc.OrderPrice = reprice;
                    acc.SJ1 = SJ1;
                    acc.SJ2 = SJ2;
                    acc.GName = gname;
                    acc.Unit = unit;
                    BLL.Account.Add(acc, MyHs);
                }


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
}