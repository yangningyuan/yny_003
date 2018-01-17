using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;

namespace zx270.Web.Handler
{
    /// <summary>
    /// Structure 的摘要说明
    /// </summary>
    public class StructureB : BaseHandler
    {
        string tempMysb = string.Empty;
        string tempEmptysb = string.Empty;
        string tempkwsb = string.Empty;

        public override void ProcessRequest(HttpContext context)
        {
            //TModel = (TModel == null ? BllModel.TModel : TModel);
            #region 双轨
            StringBuilder tempsb = new StringBuilder();
            tempsb.Append("<li><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"tablefilter\"><tbody>");
            if (TModel.Role.Super)
                tempsb.Append("<tr align=\"center\" bgcolor=\"{7}\"><td colspan=\"2\" class=\"tdfilter\"><a href=\"javascript:void(0);\" onclick=\"GetAjaxInfoB('{0}')\">ID:{1}</a></td></tr>");
            else
                tempsb.Append("<tr align=\"center\" bgcolor=\"{7}\"><td colspan=\"2\" class=\"tdfilter\"><a href=\"javascript:void(0);\">ID:{1}</a></td></tr>");
            tempsb.Append("<tr align=\"center\"><td colspan=\"2\" class=\"tdfilter\"><table border=\"0\" cellspacing=\"1\" cellpadding=\"2\" width=\"100%\"><tbody>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\" style=\"display: none;\"><td colspan=\"3\">{2}</td></tr>");
            tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td colspan=\"3\">主帐号：{9}</td></tr>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\" style=\"display: none;\"><td class=\"l\">{3}人</td><td class=\"m\">市场</td><td class=\"r\">{4}人</td></tr>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\" style=\"display: none;\"><td class=\"l\">{5}</td><td class=\"m\">业绩</td><td class=\"r\">{6}</td></tr>");
            tempsb.Append("</tbody></table></td></tr></tbody></table>");
            tempMysb = tempsb.ToString();
            #endregion

            int level = 3;
            string mkey = "admin_0";
            string color = "Agency";
            if (!string.IsNullOrEmpty(context.Request["level"]))
            {
                level = int.Parse(context.Request["level"]);
            }
            if (!string.IsNullOrEmpty(context.Request["mkey"]))
            {
                mkey = context.Request["mkey"];
            }
            if (!string.IsNullOrEmpty(context.Request["color"]))
            {
                color = context.Request["color"];
            }

            //level = GetLevel(level, ref mkey, true);

            Model.BMember tempmodel = BLL.BMember.GetModel(mkey);
            string mbd = tempmodel.BMBD;
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super && mkey == memberModel.MID)
                mbd = "";

            StringBuilder sb = new StringBuilder();
            #region 双轨
            List<Model.BMember> MyListMember = new List<Model.BMember>();
            List<Model.BMember> AllListMember = new List<Model.BMember>();
            string chileStr = GetStructure(tempmodel.BMID, level, color, ref MyListMember);
            for (int i = 0; i < BLL.Configuration.Model.B_BDCount; i++)
            {
                if (MyListMember.Count > i)
                    AllListMember.Add(MyListMember[i]);
                else
                    AllListMember.Add(new Model.BMember { YJMoney = 0, YJCount = 0 });
            };
            sb.Append(string.Format(tempMysb, mbd, tempmodel.BMID, GetName(tempmodel.AMember, color),
                AllListMember[0].YJCount, AllListMember[1].YJCount,
                AllListMember[0].YJMoney, AllListMember[1].YJMoney,
               GetColor(tempmodel.AMember, color), tempmodel.AMID, tempmodel.AMID));
            sb.Append(chileStr);
            #endregion


            sb.Append("</li>");
            context.Response.Write(Traditionalized(sb));
        }
        #region 双轨
        private string GetStructure(string mid, int level, string color, ref List<Model.BMember> ListMember)
        {
            StringBuilder sb = new StringBuilder();
            if (level >= 0)
            {
                if (mid != "")
                {
                    ListMember = BLL.BMember.GetList(string.Format("BMBD='{0}' and BMID<>'{0}' order by BMDate asc", mid));
                }
                if (level == 0)
                    return "";

                int sumcount = BLL.Configuration.Model.B_BDCount > ListMember.Count ? BLL.Configuration.Model.B_BDCount : ListMember.Count;

                sb.Append("<ul>");
                for (int i = 0; i < sumcount; i++)
                {
                    if (i < ListMember.Count)
                    {
                        List<Model.BMember> MyListMember = new List<Model.BMember>();
                        List<Model.BMember> AllListMember = new List<Model.BMember>();

                        string colors = BLL.Roles.RolsList["Nomal"].RColor;

                        string chileStr = GetStructure(ListMember[i].BMID, level - 1, color, ref MyListMember);
                        for (int j = 0; j < BLL.Configuration.Model.B_BDCount; j++)
                        {
                            if (MyListMember.Count > j)
                                AllListMember.Add(MyListMember[j]);
                            else
                                AllListMember.Add(new Model.BMember { YJMoney = 0, YJCount = 0 });
                        }
                        sb.Append(string.Format(tempMysb, ListMember[i].BMID, ListMember[i].BMID, GetName(ListMember[i].AMember, color),
                            AllListMember[0].YJCount, AllListMember[1].YJCount,
                            AllListMember[0].YJMoney, AllListMember[1].YJMoney,
                            colors, BLL.Member.GetOnlineInfo(ListMember[i].AMember.MID), ListMember[i].AMID));
                        sb.Append(chileStr);
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append(string.Format(tempEmptysb, mid));
                        sb.Append("</li>");
                    }
                }
                sb.Append("</ul>");
            }
            return Traditionalized(sb);
        }
        #endregion
        private string GetName(Model.Member model, string colorType)
        {
            switch (colorType)
            {
                case "Agency":
                    return model.MAgencyType.MAgencyName;
                case "Role":
                    return model.Role.RName;
                default:
                    return "";
            }
        }

        private string GetColor(Model.Member model, string colorType)
        {
            switch (colorType)
            {
                case "Agency":
                    return model.MAgencyType.MColor;
                case "Role":
                    return model.Role.RColor;
                default:
                    return "";
            }
        }
        private int GetLevel(int level, ref string mkey, bool IsMBD)
        {
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super)
            {
                if (mkey == memberModel.MID)
                {
                    if (level > memberModel.MAgencyType.ViewLevel)
                        level = memberModel.MAgencyType.ViewLevel;
                }
                else
                {
                    int levelCount = BllModel.GetLevelForView(mkey, IsMBD);
                    if (levelCount > 0)
                    {
                        if (level + levelCount > memberModel.MAgencyType.ViewLevel)
                            level = memberModel.MAgencyType.ViewLevel - levelCount > level ? level : memberModel.MAgencyType.ViewLevel - levelCount;
                    }
                    else
                    {
                        mkey = memberModel.MID;
                    }
                }
            }
            return level;
        }
    }
}