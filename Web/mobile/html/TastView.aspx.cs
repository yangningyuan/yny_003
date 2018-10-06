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