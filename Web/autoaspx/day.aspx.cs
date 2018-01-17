using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.autoaspx
{
    public partial class day : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["day"]) || Request.QueryString["day"] != "zx270")
                    return;
                if (zx270.BLL.Configuration.Model.B_AutoJS)
                {
                    string error = "";
                    try
                    {
                        //if (BLL.ChangeMoney.R_RFH())
                        //{
                        //    error += "日分红发放成功！";
                        //}
                        //else
                        //{
                        //    error += "日分红发放失败！";
                        //}
                        //BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "每天", error);
                    }
                    catch (Exception ex)
                    {
                        BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "每天", ex.ToString());
                    }
                    Response.Write(error);
                }
            }
        }
    }
}