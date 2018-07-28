using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class ModifyAccount : BasePage
    {
        protected override void SetValue(string id)
        {
            Model.Account c = BLL.Account.GetModel(int.Parse(id));
            CName.Value = c.CName;
            SuppName.Value = c.SupplierName;
            type.Value = c.AType.ToString();

            Model.C_CarTast tast = BLL.C_CarTast.GetModel(c.CID);
            if (!string.IsNullOrEmpty(tast.OCode))
            {
                Model.OrderDetail od = BLL.OrderDetail.GetModelCode(tast.OCode);
                Model.Goods goods = BLL.Goods.GetModel(od.GId);
                GoodName.Value = goods.GName;
                txtGoodCount.Value = od.ReCount.ToString();
                txtGoodPrice.Value = od.BuyPrice.ToString();
            }
            Remark.Value = c.Spare2.ToString();

            fid.Value = c.ID.ToString();
        }


        protected override string btnModify_Click()
        {
            Hashtable MyHs = new Hashtable();
            Model.Account acc= BLL.Account.GetModel(Convert.ToInt32(Request.Form["fid"]));
            try
            {
                decimal count = Convert.ToDecimal(Request.Form["txtGoodCount"]);
                decimal price = Convert.ToDecimal(Request.Form["txtGoodPrice"]);
                string remark = Request.Form["Remark"];

                Model.C_CarTast tast = BLL.C_CarTast.GetModel(acc.CID);
                if (!string.IsNullOrEmpty(tast.OCode))
                {
                    Model.OrderDetail od = BLL.OrderDetail.GetModelCode(tast.OCode);
                    Model.Goods goods = BLL.Goods.GetModel(od.GId);
                    od.ReCount = count;
                    od.BuyPrice = price;
                    BLL.OrderDetail.Update(od,MyHs);
                }
                acc.TotalMoney = count * price;
                acc.Spare2 = remark;
                BLL.Account.Update(acc, MyHs);
                if (BLL.CommonBase.RunHashtable(MyHs))
                {
                    return "修改成功";
                }
                else {
                    return "修改失败";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}