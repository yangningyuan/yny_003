using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.mobile.html
{
    public partial class XSTastList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = " ( XSMID='" + TModel.MID + "') ";
            string state = Request.Form["state"];
            if (!string.IsNullOrEmpty(state))
            {
                where += " and TState=" + state + " ";
            }
            if (!string.IsNullOrEmpty(Request["begin_time"]))
            {
                where += " and CreateDate>'" + Request["begin_time"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(Request["end_time"]))
            {
                where += " and CreateDate<'" + Request["end_time"] + " 23:59:59' ";
            }

            List<Model.C_CarTast> listchange = null;

            listchange = BLL.C_CarTast.GetList(where, CurrentPage, ItemsPerPage, out totalCount);
            //if (!string.IsNullOrEmpty(state))
            //{
            //    if (state == "0" && listchange.Count > 0)
            //    {

            //        Model.C_CarTast ct = listchange.ToList().OrderByDescending(m => m.Prot).FirstOrDefault();
            //        listchange.Clear();
            //        listchange.Add(ct);
            //    }
            //}
            var list = listchange.Select(item => new
            {
                Name = getsupplier(item.SupplierName),
                //SupplierName = item.SupplierName,
                SupplierTel = item.SupplierTel,
                CreateDate = item.CreateDate.ToString("yyyy-MM-dd HH:ss"),
                dhtml =( item.TState == -1 ? "<a class=\"button button-fill button-success\" href=\"javascript:pcallhtml('/mobile/html/XSTastAdd.aspx?id=" + item.ID + "','修改');\">修改</a><a class=\"button button-fill button-success\" href=\"Javascript:XSTastCel('" + item.ID + "');\">取消</a>" : "")+("<a class=\"button button-fill button-success\" href=\"javascript:pcallhtml('/mobile/html/TastView.aspx?id=" + item.ID + "','详情');\">详情</a>")

            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }
        protected string getsupplier(string id)
        {
            Model.C_Supplier supp= BLL.C_Supplier.GetModel(Convert.ToInt32(id));
            if (supp != null)
                return supp.Name;
            else
                return "";
        }
        

        protected override string btnAdd_Click()
        {
            Model.C_CarTast cd = BLL.C_CarTast.GetModel(Convert.ToInt32(Request.Form["cid"]));
            if (cd.TState != -1)
                return "状态已改变，请刷新重试";
            cd.TState = 2;
            
            if (BLL.C_CarTast.Update(cd))
                return "取消成功";
            else
                return "取消失败";
        }
    }
}