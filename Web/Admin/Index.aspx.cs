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

        protected override void SetPowerZone()
        {
            车辆里程 = Convert.ToDecimal(BLL.CommonBase.GetSingle("select ISNULL( SUM(DiffCount),0) from C_Mileage where DATEDIFF(MONTH,CreateDate,GETDATE())=0"));
            本月费用 = Convert.ToDecimal(BLL.CommonBase.GetSingle("select ISNULL( SUM(CostMoney),0) from C_CostDetalis where DATEDIFF(MONTH,CareteDate,GETDATE())=0"));

            非空车数量= Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_Car where CType='牵引车' and PZCode in(select Spare2 from C_CarTast where TState!=1 and TState!=2)"))+ Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_Car where CType='挂车' and PZCode in(select CSpare2 from C_CarTast where (TState!=1 and TState!=2))"));

            int 总车辆数量 = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from C_Car where IsDelete=0;"));

            空车数量 = 总车辆数量 - 非空车数量;

            listPowers = TModel.Role.PowersList.Where(emp => emp.Content.VState).ToList();
           
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