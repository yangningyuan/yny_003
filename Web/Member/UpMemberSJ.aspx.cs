using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zx270.Web.Member
{
    public partial class UpMemberSJ : BasePage
    {
        protected string MyMAgencyTypeRdo;
        protected string MAgencyTypeColor;
        protected decimal maxUpMAgency;
        protected Model.Member sjmodel;
        protected bool isNew = false;
        protected string url = "member/UpMemberSJ.aspx";

        protected override void SetValue(string id)
        {
            url = "Member/SHListSJ.aspx";
            sjmodel = BllModel.GetModel(id);
            hdmid.Value = sjmodel.MID;
            if (TModel.Role.IsAdmin && !sjmodel.MState)
            {
                //填写接点人
                isNew = false;
            }
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.Where(emp => emp.MAgencyType != "001"))
            {
                MAgencyTypeColor += "<td style='width:60px;color:#00CCFF;'>" + item.MAgencyName + "<br />[" + item.Money + "]</td>";
                if (item.Money <= sjmodel.MAgencyType.Money || !BLL.ChangeMoney.EnoughChange(TModel.MID, item.Money - sjmodel.MAgencyType.Money, "MJB"))
                    continue;
                else
                    MyMAgencyTypeRdo += "<input name='AgencyTypeList' id='" + item.MAgencyType + "' value='" + item.MAgencyType + "' type='radio' />" + item.MAgencyName + "[" + (item.Money - sjmodel.MAgencyType.Money) + "]&nbsp;";
            }
            if (string.IsNullOrEmpty(MyMAgencyTypeRdo))
                MyMAgencyTypeRdo += "暂不可升级";
        }

        protected override void SetValue()
        {
            sjmodel = TModel;
            hdmid.Value = sjmodel.MID;
            Model.SHMoney shmoney = null;
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.Where(emp => emp.MAgencyType != "001"))
            {
                MAgencyTypeColor += "<td style='width:60px;color:#00CCFF;'>" + item.MAgencyName + "<br />[" + item.Money + "]</td>";
                if (shmoney == null && item.Money > sjmodel.MAgencyType.Money)
                {
                    shmoney = item;
                }
            }
            //获取次数
            int count = BLL.LuckyMoney.GetModelList(" FHTimes = " + Convert.ToInt32(sjmodel.AgencyCode) + " and MID = '" + sjmodel.MID + "' ").Count;
            if (shmoney != null && count >= sjmodel.MAgencyType.TeamCount)
            {
                //可以升级下一级
                MyMAgencyTypeRdo += "<input name='AgencyTypeList' id='" + shmoney.MAgencyType + "' value='" + shmoney.MAgencyType + "' type='radio' />" + shmoney.MAgencyName + "[" + (shmoney.Money - sjmodel.MAgencyType.Money) + "]&nbsp;";
            }
            if (string.IsNullOrEmpty(MyMAgencyTypeRdo))
                MyMAgencyTypeRdo += "暂不可升级";
        }

        protected override void SetPowerZone()
        {
        }

        protected override string btnModify_Click()
        {
            //if (Check_SQ_Answer())
            //{

            sjmodel = TModel;
            if (!string.IsNullOrEmpty(Request.Form["hdmid"]))
                sjmodel = BllModel.GetModel(Request.Form["hdmid"]);

            //if (!sjmodel.MState)
            //{
            //    if (string.IsNullOrWhiteSpace(Request.Form["txtMBD"]))
            //    {
            //        return "接点人不能为空";
            //    }
            //}

            if (BLL.Configuration.Model.SHMoneyList.ContainsKey(Request.Form["AgencyTypeList"]))
            {
                Model.SHMoney shmoney = BLL.Configuration.Model.SHMoneyList[Request.Form["AgencyTypeList"]];
                if (BLL.ChangeMoney.EnoughChange(TModel.MID, shmoney.Money - sjmodel.MAgencyType.Money, "MJB"))
                {
                    try
                    {
                        if (BLL.Member.upmidlist.Contains(sjmodel.MID))
                            return "升级处理中，请等待！";
                        else
                            BLL.Member.upmidlist.Add(sjmodel.MID);
                        var result = BllModel.UpMAgencyType(shmoney, Request.Form["hdmid"], "MJB", TModel, shmoney.Money - sjmodel.MConfig.SHMoney, Request.Form["txtMBD"]);
                        if (TModel.Role.IsAdmin)
                        {
                            BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_SJHY, "升级会员");
                        }
                        return result;
                    }
                    finally
                    {
                        if (BLL.Member.upmidlist.Contains(sjmodel.MID))
                            BLL.Member.upmidlist.Remove(sjmodel.MID);
                    }
                }
                else
                {
                    return "您的" + BLL.Reward.List["MJB"].RewardName + "账户余额不足";
                }
            }
            else
            {
                return "未知会员级别";
            }
            //}
            //else
            //    return "密保问题错误*";
        }
    }
}