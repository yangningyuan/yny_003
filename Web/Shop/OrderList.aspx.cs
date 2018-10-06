using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Shop
{
    public partial class OrderList : BasePage
    {
        protected string status = "";
        protected override void SetValue(string id)
        {
            status = id;
        }

        protected override void SetPowerZone()
        {
            //if (TModel.Role.Super)
            //{
            divOperator.InnerHtml = "";
            //}

            mKey.DataSource = BLL.C_Supplier.GetList(" IsDelete = 0  order by ID");
            mKey.DataTextField = "Name";
            mKey.DataValueField = "ID";
            mKey.DataBind();
            mKey.Items.Insert(0, "--请选择--");
        }
    }
}