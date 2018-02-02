using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class CostAdd : BasePage
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
                decimal money= Convert.ToDecimal(Request.Form["txtMHB"]);
                Model.C_CostType ct= BLL.C_CostType.GetModel(cartast.CostType);
                decimal totalmoney= listcost.Sum(m=>m.CostMoney);
                if (ct.XEMoney < money + totalmoney)
                {
                    return "此任务最多可以申请费用额为"+(ct.XEMoney-totalmoney);
                }

                Model.C_CostDetalis apply = new Model.C_CostDetalis();
                apply.CID =Convert.ToInt32(Request.Form["cid"]);
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