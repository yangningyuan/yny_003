using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.Member
{
    public partial class BCenterAdd : BasePage
    {
        protected override void SetPowerZone()
        {
            txtRole.DataSource = BLL.Roles.GetList(" CanSH = 1 and IsAdmin = 0 and KeFu = 0 ");
            txtRole.DataTextField = "RName";
            txtRole.DataValueField = "RType";
            txtRole.DataBind();

            txtMID.Value = TModel.MID;
            txtMName.Value = TModel.MName;

            if (TModel.Role.CanSH && !TModel.Role.KeFu)
            {
                showmessage.InnerHtml = "您已经是代理，不能再次申请！";
                btnOK.Visible = false;
            }
            else
            {
                if (BLL.Agents.GetModelList(string.Format(" MID='{0}' and IsValid=0 ", TModel.MID)).Count > 0)
                {
                    showmessage.InnerHtml = "您已经提交过申请，请等待管理员审批！";
                    btnOK.Visible = false;
                }
                else
                {
                    //if (TModel.AgencyCode != "003")
                    //{
                    //    showmessage.InnerHtml = "您还未投资,不能申请合伙公司！";
                    //    btnOK.Visible = false;
                    //}
                    //else
                    {
                        showmessage.InnerHtml = "您当前未申请过代理！";
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            string role = Request.Form["txtRole"];
            if (BLL.Roles.RolsList.ContainsKey(role))
            {
                if (TModel.Role.CanSH && !TModel.Role.KeFu)
                {
                    return "您已经是代理，不能再次申请！";
                }
                else
                {
                    if (BLL.Agents.GetModelList(string.Format(" MID='{0}' and IsValid=0 ", TModel.MID)).Count > 0)
                    {
                        return "您已经提交过申请，请等待管理员审批！";
                    }
                    //else
                    //{
                    //    if (TModel.AgencyCode != "003")
                    //    {
                    //        return "您还未投资,不能申请合伙公司！";
                    //    }
                    //}
                }

                Model.Agents agent = new Model.Agents();
                agent.MID = TModel.MID;
                agent.Province = Request.Form["ddlProvince"];
                if (agent.Province == "省名")
                {
                    agent.Province = "";
                }
                agent.City = Request.Form["ddlCity"];
                if (agent.City == "地市")
                {
                    agent.City = "";
                }
                agent.Zone = Request.Form["ddlZone"];
                if (agent.Zone == "县市")
                {
                    agent.Zone = "";
                }
                agent.Type = role;
                agent.CreateTime = DateTime.Now;
                agent.IsValid = Model.AgentValidEnum.Pending;
                agent.Remarks = "";

                string result = BLL.Agents.AddApply(agent);
                if (string.IsNullOrEmpty(result))
                {
                    BLL.Task.SendManage(TModel, "001", TModel.MName + "申请成为" + BLL.Roles.RolsList[role].RName + "!");//给管理员发消息
                    return "申请提交成功";
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return "非法操作";
            }
        }
    }
}