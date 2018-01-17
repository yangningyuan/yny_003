using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.SysManage
{
	public partial class OperationRecord : BasePage
	{
		protected IEnumerable<Model.Roles> Roles;

		protected override void SetPowerZone()
		{
			Roles = BLL.Roles.RolsList.Values;
		}

		public string Opt_GetList()
		{
			Model.QueryOperationRecord query = new Model.QueryOperationRecord();
			query.MID = Request.GetData("MID");
			query.RoleCode = Request.GetData("RoleCode");
			query.LevelCode = Request.GetData("LevelCode");
			query.TypeCode = Request.GetData("TypeCode");

			var time = Request.GetData("StartTime");
			if (!string.IsNullOrEmpty(time))
			{
				query.StartTime = DateTime.ParseExact(time, "yyyy-MM-dd", null);
			}

			time = Request.GetData("EndTime");
			if (!string.IsNullOrEmpty(time))
			{
				query.EndTime = DateTime.ParseExact(time, "yyyy-MM-dd", null);
			}

			var idx = 0;
			var list = BLL.OperationRecordBLL.QueryByPage(query, PageIndex, PageSize, out totalCount).Select(item => new
			{
				ID = ++idx,
				MID = item.MID,
				Level = Config.SHMoneyList[item.LevelCode]._MAgencyName,
				Role = BLL.Roles.RolsList[item.RoleCode].RName,
				Time = item.Time.ToString("yyyy-MM-dd HH:mm:ss"),
				OperationType = item.Type.Name(),
				Operation = item.Operation
			});
			return jss.Serialize(new { PageData = list, TotalPage = TotalPage(PageSize) });
		}
	}
}