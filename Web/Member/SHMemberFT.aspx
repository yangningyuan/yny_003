<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SHMemberFT.aspx.cs" Inherits="zx270.Web.Member.SHMemberFT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 30%" align="right">
                        会员账号:
                    </td>
                    <td>
                        <%=TModel.MID%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员姓名:
                    </td>
                    <td>
                        <%=TModel.MName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        当前级别:
                    </td>
                    <td style="font-weight: bold; color: Red;">
                        <%=TModel.MAgencyType.MAgencyName%>
                        <input id="hdmid" type="hidden" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        我的<%=zx270.BLL.Reward.List["MJB"].RewardName %>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        复投所需费用:
                    </td>
                    <td>
                        <%=zx270.BLL.Configuration.Model.BCenterMoney.ToString("F2")%>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <%
                            if (TModel.MState && !TModel.FHState)
                            {
                        %>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="复投" onclick="checkChange();" />
                        <% 
                            }
                            else
                            {
                        %>
                        您当前无需复投
                        <%
                            }
                        %>
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            RunAjaxByList11('false', 'ShFTMember', '<%=TModel.MID %>');
        }
    </script>
</body>
</html>
