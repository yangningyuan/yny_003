using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_003.Web.Admin
{
    public partial class Index : BasePage
    {
        private List<Model.RolePowers> listPowers;
        protected decimal 车辆里程 = 0;
        protected decimal 本月费用 = 0;
        protected int 空车数量 = 0;
        protected int 非空车数量 = 0;


        protected string goodsList = "";
        protected string goodspic = "";

        protected override void SetPowerZone()
        {
            车辆里程 = Convert.ToDecimal(BLL.CommonBase.GetSingle("select ISNULL( SUM(DiffCount),0) from C_Mileage where DATEDIFF(MONTH,CreateDate,GETDATE())=0"));
            本月费用 = Convert.ToDecimal(BLL.CommonBase.GetSingle("select ISNULL( SUM(CostMoney),0) from C_CostDetalis where DATEDIFF(MONTH,CareteDate,GETDATE())=0"));

            非空车数量 = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_Car where CType='牵引车' and PZCode in(select Spare2 from C_CarTast where TState!=1 and TState!=2)")) + Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_Car where CType='挂车' and PZCode in(select CSpare2 from C_CarTast where (TState!=1 and TState!=2))"));

            int 总车辆数量 = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_Car where IsDelete=0;"));

            空车数量 = 总车辆数量 - 非空车数量;

            listPowers = TModel.Role.PowersList.Where(emp => emp.Content.VState).ToList();

            List<Model.Goods> list = BLL.Goods.GetList(" isdeleted=0 ");
            foreach (var item in list)
            {
                DataTable dt = BLL.CommonBase.GetTable("select CONVERT(varchar(7),DATEADD(month,-1,CreatedTime),120) dt,ISNULL(sum(ReCount),0) my  from OrderDetail where  gid="+item.GID+" and OrderCode in(select OCode from C_CarTast where TState=1) group by CONVERT(varchar(7),DATEADD(month,-1,CreatedTime),120);");


                if (dt.Rows.Count > 0)
                {
                    
                    Model.Goods g = BLL.Goods.GetModel(item.GID);
                    goodsList += "{name:'" + g.GName + "',data:[";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DateTime dt2 = Convert.ToDateTime(dt.Rows[i]["dt"]);
                        goodsList += "[Date.UTC("+ dt2.ToString("yyyy") + ",  "+ dt2.ToString("MM")+ ")," + dt.Rows[i]["my"].ToString() + "],";
                    }
                    goodsList += "]},";
                }
            }

            goodsList = goodsList.Length > 0 ? goodsList.Substring(0, goodsList.Length - 1) : "";
            decimal zctotal = Convert.ToDecimal(BLL.CommonBase.GetSingle(" select ISNULL(SUM(recount),0) from OrderDetail where  OrderCode in(select OCode from C_CarTast where ttype=1 and TState=1) "));
            if (zctotal > 0)
            {
                foreach (var item in list)
                {
                    Model.Goods g = BLL.Goods.GetModel(item.GID);
                    decimal zcgoodstotal = Convert.ToDecimal(BLL.CommonBase.GetSingle(" select ISNULL(SUM(recount),0) from OrderDetail where gid="+item.GID+" and OrderCode in(select OCode from C_CarTast where ttype=1 and TState=1) "));
                    goodspic += "['" + g.GName + "', "+ zcgoodstotal/zctotal*100+ "],";
                }
            }

            goodspic = goodspic.Length > 0 ? goodspic.Substring(0, goodspic.Length - 1) : goodspic;
        }

        protected List<Model.RolePowers> GetPowers(string cfid)
        {
            return listPowers.Where(emp => emp.Content.CFID == cfid).ToList();
        }

        protected List<Model.RolePowers> GetQuickMenu()
        {
            List<Model.RolePowers> list = listPowers.Where(emp => emp.Content.IsQuickMenu).ToList();
            return list;
        }
    }
}