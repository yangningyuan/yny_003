using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace zx270.Web.Member.Handler
{
    /// <summary>
    /// StructureMSH 的摘要说明
    /// </summary>
    public class StructureMSH : BaseHandler
    {
        string tempMysb = string.Empty;
        string tempEmptysb = string.Empty;
        string tempkwsb = string.Empty;

        public override void ProcessRequest(HttpContext context)
        {
            StringBuilder tempsb = new StringBuilder();
            tempsb.Append("<li><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"tablefilter\"><tbody>");
            tempsb.Append("<tr align=\"center\" bgcolor=\"{3}\"><td colspan=\"2\" class=\"tdfilter\"><a href=\"javascript:void(0);\" onclick=\"GetAjaxSHInfo('{0}')\">{1}</a></td></tr>");
            //tempsb.Append("<tr align=\"center\"><td colspan=\"2\" class=\"tdfilter\"><table border=\"0\" cellspacing=\"1\" cellpadding=\"2\" width=\"100%\"><tbody>");
            tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td colspan=\"3\">{2}{4}</td></tr>");
            tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td colspan=\"3\">{5}</td></tr>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td class=\"l\">推荐</td><td class=\"m\"></td><td class=\"r\">{4}</td></tr>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td class=\"l\"></td><td class=\"m\"></td><td class=\"r\">{5}</td></tr>");
            tempsb.Append("</tbody></table></td></tr>");
            tempsb.Append("</tbody></table>");
            tempMysb = tempsb.ToString();
            //tempEmptysb = "<li><table cellspacing=\"0\" cellpadding=\"0\" class=\"tablefilter\"><tbody><tr align=\"center\"><td valign=\"middle\" height=\"100%\"><a href=\"javascript:AddMember('{0}')\">[空位]<br/><br/>注册</a></td></tr></tbody></table>";
            //tempkwsb = "<li><table cellspacing=\"0\" cellpadding=\"0\" class=\"tablefilter\"><tbody><tr align=\"center\"><td valign=\"middle\" height=\"100%\"><br>[空位]</td></tr></tbody></table>";
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            int level = 3;
            string mkey = memberModel.MID;

            if (!string.IsNullOrEmpty(context.Request["level"]))
            {
                level = int.Parse(context.Request["level"]);
            }
            if (!string.IsNullOrEmpty(context.Request["mkey"]))
            {
                mkey = context.Request["mkey"];
            }

            level = GetLevel(level, ref mkey, true);

            if (!TModel.Role.IsAdmin)
            {
                int count = Convert.ToInt32(BLL.CommonBase.GetSingle(string.Format(@"
                            -- 查找所有父节点
                            with tab as
                            (
                             select MID,MSH from member where MID='{0}' --子节点
                             union all
                             select b.MID,b.MSH
                             from
                              tab a,--子节点数据集
                              member b  --父节点数据集
                             where a.MSH=b.MID and b.MID <> '{1}'  --子节点数据集.parendID=父节点数据集.ID
                            )
                            select count(*) from tab where MID = '{2}';
                            ", mkey, BLL.Member.ManageMember.TModel.MID, TModel.MID)));
                //int mcount = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from GetAllSubBDMember('" + TModel.MID + "') where mid='" + mkey + "';"));
                if (count <= 0)
                {
                    mkey = TModel.MID;
                }
            }
            Model.Member tempmodel = BLL.Member.ManageMember.GetModel(mkey);
            string mbd = tempmodel.MSH;

            if (!memberModel.Role.Super && mkey == memberModel.MID)
                mbd = "";
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(tempMysb, mbd, tempmodel.MID, tempmodel.Role.RName, tempmodel.MAgencyType.MColor, BLL.Member.GetOnlineInfo(tempmodel.MID), GetMemberType(tempmodel)));
            GetStructure(tempmodel.MID, level, sb);
            sb.Append("</li>");
            context.Response.Write(Traditionalized(sb));

        }

        private void GetStructure(string mid, int level, StringBuilder sb)
        {
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(string.Format("MSH='{0}' and MID<>'{0}' and RoleCode = 'VIP' order by MCreateDate", mid));
            if (level > 0)
            {
                sb.Append("<ul>");
                for (int i = 0; i < ListMember.Count; i++)
                {
                    string colors = "";
                    if (ListMember[i].MState)
                    {
                        colors = ListMember[i].MAgencyType.MColor;
                    }
                    else
                    {
                        colors = "#FF5151";
                    }
                    sb.AppendFormat(tempMysb, ListMember[i].MID, ListMember[i].MID, ListMember[i].Role.RName, colors, BLL.Member.GetOnlineInfo(ListMember[i].MID), GetMemberType(ListMember[i]));

                    GetStructure(ListMember[i].MID, level - 1, sb);
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
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