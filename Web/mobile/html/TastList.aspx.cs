using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
	public partial class TastList : BasePage
	{
		protected override string btnOther_Click()
		{
			string where = " ( CarSJ1='" + TModel.MID + "' or  CarSJ2='" + TModel.MID + "' ) ";
			string state = Request.Form["state"];
			if (!string.IsNullOrEmpty(state))
			{
				where += " and TState in(" + state + ") ";
			}

			List<Model.C_CarTast> listchange = null;

			listchange = BLL.C_CarTast.GetList(where, CurrentPage, ItemsPerPage, out totalCount);
            //if (!string.IsNullOrEmpty(state))
            //{
            //    if (state == "0"&&listchange.Count>0)
            //    {
                    
            //        Model.C_CarTast ct= listchange.ToList().OrderByDescending(m => m.Prot).FirstOrDefault();
            //        listchange.Clear();
            //        listchange.Add(ct);
            //    }
            //}
            

            var list = listchange.Select(item => new
			{
				Name = getsupplier(item.SupplierName) + "<span style='color:" + (item.TType == 1 ? "red" : "green") + ";'>【" + item.TType.ToString().Replace("1", "装车").Replace("2", "卸车").Replace("3", "空车") + "】</span>",
                //SupplierName = item.SupplierName,
                SupplierTel = htmlGoodName(item.OCode),
				CreateDate = item.CreateDate.ToString("yyyy-MM-dd HH:mm"),
				dhtml =(item.TState==-2? "<a class=\"button button-fill  background_1\" style='background-color:red;' href=\"javascript:pcallhtml('/mobile/html/TastView.aspx?id=" + item.ID + "','纠错');\">纠错</a>" : "<a class=\"button button-fill button-success\" href=\"javascript:pcallhtml('/mobile/html/TastView.aspx?id=" + item.ID + "','详情');\">详情</a>")

			});
			return jss.Serialize(new { Items = list, TotalCount = totalCount });
		}
        protected static string htmlGoodName(string ordercode)
        {
            if (!string.IsNullOrEmpty(ordercode))
            {
                int goodid = BLL.OrderDetail.GetModelCode(ordercode).GId;
                return BLL.Goods.GetModel(goodid).GName;
            }
            else {
                return "";
            }
        }
        protected string getsupplier(string id)
        {
            Model.C_Supplier supp = BLL.C_Supplier.GetModel(Convert.ToInt32(id));
            if (supp != null)
                return supp.Name;
            else
                return "";
        }
    }
}