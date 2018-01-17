using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.OJ
{
    public partial class ObjSubList : BasePage
    {
        protected string matchid = string.Empty;

        protected string totalmoney = "";
        protected string remoney = "";
        protected string impstr = "";
        protected Model.Obj obj = null;
        
        protected override void SetValue(string id)
        {
            matchid = id;
            //matchid.Value = id;
        }

        protected override void SetPowerZone()
        {
            int oid= Convert.ToInt32(Request.QueryString["id"]);
            obj= BLL.Obj.GetModel(oid);
            totalmoney = obj.Money.ToString();
            remoney= BLL.CommonBase.GetSingle("select ISNULL(SUM(remoney),0) from ObjSub where ObjID in("+Request.QueryString["id"]+") and IsDelete=0;").ToString();
            List<Model.ImpType> implist= BLL.ImpType.GetModelList(" ID IN("+obj.ImpUnit+"); ");
            foreach (Model.ImpType item in implist)
            {
                impstr += item.Name;
            }
        }

        protected override string btnModify_Click()
        {
            decimal money =Convert.ToDecimal(Request.QueryString["money"]);
            int subid =Convert.ToInt32(Request.QueryString["subid"]);


            bool result = false;
            if (!string.IsNullOrEmpty(Request.QueryString["subid"]))
            {
                Model.ObjSub model = BLL.ObjSub.GetModel(Convert.ToInt32(Request.QueryString["subid"]));
                Model.Obj objmodel = BLL.Obj.GetModel(Convert.ToInt32(model.ObjID));

                if ((model.ReMoney+money) > model.Money * (1 + model.CZFloat))
                    return "支出失败，超出超支限额";
                decimal rmoney = Convert.ToDecimal(BLL.CommonBase.GetSingle("SELECT ISNULL(SUM(CASE WHEN ReMoney>[Money] THEN ReMoney ELSE [Money] END),0) FROM dbo.ObjSub WHERE ID<>" + model.ID + " and OBJID=" + objmodel.ID + ";"));
                decimal cc =(model.ReMoney+money) > model.Money ? (model.ReMoney+money) : model.Money;
                if ((rmoney + cc) > objmodel.Money)
                    return "支出失败，超出项目预算";
                model.ReMoney = model.ReMoney + money;
                result = BLL.ObjSub.Update(model);
            }

            if (result)
            {
                return "支出成功";
            }
            return "支出失败";

        }
    }
}