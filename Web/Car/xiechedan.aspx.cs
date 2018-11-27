using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Car
{
    public partial class xiechedan : BasePage
    {
        protected static List<Model.C_CarTast> listacc = null;
        protected override void SetPowerZone()
        {
            string tid =Request.QueryString["tid"];
            tidv.Value = tid;

            listacc = BLL.C_CarTast.GetModelList(" TCode ='" + tid + "'; ");

        }
    }
}