using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class TastList2 : BasePage
    {
        protected override void SetPowerZone()
        {
            
            tcode.Value= Request.QueryString["tcode"]; 
        }

        protected override string btnModify_Click()
        {
            Hashtable MyHs = new Hashtable();
            Model.C_CarTast cartast = BLL.C_CarTast.GetModel(Convert.ToInt32(Request.Form["tid"]));
            if (cartast.SHInt != 0)
                return "此任务审核状态为已审核状态";

            cartast.SHInt = 1;
            BLL.C_CarTast.Update(cartast,MyHs);

            int acount= Convert.ToInt32(BLL.CommonBase.GetSingle("select count(*) from Account where CName='"+cartast.Name+"';"));
            if (acount == 0)
            {
                if (cartast.TType == 1 || cartast.TType == 2)
                {
                    Model.Member mc1 = BLL.Member.GetModelByMID(cartast.CarSJ1);
                    Model.Member mc2 = BLL.Member.GetModelByMID(cartast.CarSJ2);

                    string SJ1 = "";string SJ2 = "";
                    if (mc1 != null)
                        SJ1 = mc1.MName;
                    if (mc2 != null)
                        SJ2 = mc2.MName;

                    decimal retotalMoney = 0;//实际总额
                    decimal recount = 0;
                    decimal reprice = 0;
                    string gname = "";
                    string unit = "";
                    if (!string.IsNullOrEmpty(cartast.OCode))
                    {
                        Model.OrderDetail od = BLL.OrderDetail.GetModelCode(cartast.OCode);
                        if (od != null)
                        {
                            retotalMoney = od.ReCount * od.BuyPrice;
                            recount = od.ReCount;
                            reprice = od.BuyPrice;

                            Model.Goods mg = BLL.Goods.GetModel(od.GId);
                            if (mg != null)
                            {
                                gname = mg.GName;
                                unit = mg.Unit;
                            }
                        }
                    }

                    Model.Account acc = new Model.Account();
                    acc.CID = cartast.ID;
                    acc.CName = cartast.Name;
                    acc.AType = cartast.TType == 1 ? 0 : 1;
                    acc.SupplierID = Convert.ToInt32(cartast.SupplierName);
                    var supplier = BLL.C_Supplier.GetModel(int.Parse(cartast.SupplierName));
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
            }

            if (BLL.CommonBase.RunHashtable(MyHs))
                return "审核成功";
            else
                return "审核失败";
        }
    }
}