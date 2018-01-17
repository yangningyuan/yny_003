using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.Message
{
    public partial class TaskAddComplain : BasePage
    {
        protected override void SetValue(string id)
        {
            List<Model.Task> task = BLL.Task.GetTaskList(1, "ID=" + id);
            if (task.Count > 0)
            {
                //txtMID.Value = task[0].TFromMID;
                //hdMID.Value = txtMID.Value;
            }
        }

        protected override void SetPowerZone()
        {
            //foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.CMessage && emp.IsAdmin))
            //{
            //    List<Model.Member> list = BLL.Member.ManageMember.GetMemberEntityList("RoleCode='" + item.RType + "' and IsClose<>'1' and MState='1'");
            //    foreach (Model.Member model in list.Where(emp => BLL.Member.IfOnLine(emp.MID)))
            //    {
            //        ddlAdmin.Items.Add(new ListItem(item.RName + " [" + model.MName + "][在线]", model.MID));
            //    }
            //    foreach (Model.Member model in list.Where(emp => !BLL.Member.IfOnLine(emp.MID)))
            //    {
            //        ddlAdmin.Items.Add(new ListItem(item.RName + " [" + model.MName + "][离线]", model.MID));
            //    }
            //}
            //ddlAdmin.Items.Insert(0, new ListItem("请选择", ""));
            //if (!BllModel.TModel.Role.Super)
            //{
            //    txtMID.Attributes["type"] = "hidden";
            //    txtMID.Value = BLL.Member.ManageMember.TModel.MID;
            //}
        }

        public Model.Task TaskModel
        {
            get
            {
                Model.Task model = new Model.Task();
                Model.Member FMember = BllModel.TModel;

                model.TContent = Request.Form["txtMessage"];
                model.TDateTime = DateTime.Now;
                model.TFromMID = FMember.MID;
                model.TFromMName = FMember.MName;
                model.TToMID = BLL.Member.ManageMember.TModel.MID;
                model.TToMName = BLL.Member.ManageMember.TModel.MName;
                model.TType = "008";
                return model;
            }
        }

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            if (!string.IsNullOrEmpty(Request.Form["txtMID"]))
            {
                if (BllModel.GetModel(Request.Form["txtMID"]) == null)
                    return "会员不存在";
            }
            return BLL.Task.Add(TaskModel);
        }
    }
}