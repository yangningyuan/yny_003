<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SHMember.aspx.cs" Inherits="zx270.Web.Member.SHMember" %>

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
                        我的<%=zx270.BLL.Reward.List["MJB"].RewardName %>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB.ToFixedString() %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        激活所需费用:
                    </td>
                    <td>
                        <%=zx270.BLL.Configuration.Model.SHMoneyList["002"].Money.ToString("F0")%>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <%
                            if (TModel.MState)
                            {
                        %>
                        您已激活
                        <% 
                            }
                            else
                            {
                        %>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="激活" onclick="checkChange();" />
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
            RunAjaxByListReload('false', 'ShMemberSelf', '<%=TModel.MID %>');
        }
    </script>
</body>
</html>
