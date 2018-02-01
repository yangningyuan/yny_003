using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class LoadGoods :BasePage
    {
        protected Model.C_CarTast cartast = null;
        protected string strordsel = "";
        protected override void SetValue(string id)
        {
            cartast = BLL.C_CarTast.GetModel(int.Parse(id));
            cid.Value = id;
            Model.Order order = BLL.Order.GetModel(cartast.OCode);
            List<Model.OrderDetail> list= BLL.OrderDetail.GetList(" OrderCode='"+cartast.OCode+"' ");
            foreach (var item in list)
            {
                strordsel += "<option value='"+item.Code+"'>"+BLL.Goods.GetModel(item.GId).GName+"</option>";
            }
        }

        protected override string btnAdd_Click()
        {
            try
            {
                Model.C_CarTast cartast = BLL.C_CarTast.GetModel(int.Parse(Request.Form["cid"]));
                
                decimal money = Convert.ToDecimal(Request.Form["txtMHB"]);
                Model.C_CostType ct = BLL.C_CostType.GetModel(cartast.CostType);
                

                Model.C_CostDetalis apply = new Model.C_CostDetalis();
                apply.CID = Convert.ToInt32(Request.Form["cid"]);
                apply.CostMoney = money;
                apply.CostImgUrl = Request.Form["uploadurl"];
                apply.CareteDate = DateTime.Now;
                apply.IsDelete = 0;
                if (BLL.C_CostDetalis.Add(apply) > 0)
                {
                    return "申请已提交";
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