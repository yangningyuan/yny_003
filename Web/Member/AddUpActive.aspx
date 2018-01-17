<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUpActive.aspx.cs" Inherits="zx270.Web.Member.AddUpActive" %>

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
                        会员帐号:
                    </td>
                    <td>
                        <%=TModel.MID%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" align="right">
                        已投资股权:
                    </td>
                    <td>
                        <%=TModel.MConfig.SHMoney.ToString("F2")%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" align="right">
                        剩余<%=zx270.BLL.Reward.List["MHB"].RewardName %>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJJ.ToFixedString()%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" align="right">
                        剩余<%=zx270.BLL.Reward.List["MJB"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB.ToFixedString()%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" align="right">
                        剩余<%=zx270.BLL.Reward.List["MCW"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MCW.ToFixedString()%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" align="right">
                        股权投资范围:
                    </td>
                    <td>
                        <%=zx270.BLL.Configuration.Model.ActivateMinMoney%>-<%=zx270.BLL.Configuration.Model.ActivateMaxMoney%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" align="right">
                        投资币种:
                    </td>
                    <td>
                        <select id="ddlmoneyType" name="ddlmoneyType">
                            <option value="MHB">
                                <%=zx270.BLL.Reward.List["MHB"].RewardName%></option>
                            <option value="MJB">
                                <%=zx270.BLL.Reward.List["MJB"].RewardName%></option>
                            <option value="MCW">
                                <%=zx270.BLL.Reward.List["MCW"].RewardName%></option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        追加投资:
                    </td>
                    <td>
                        <input id="txtAddCount" runat="server" name="txtAddCount" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: "/Member/AddUpActive.aspx?Action=modify",
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.alert(info, '2', 'true');
                        setTimeout(function () {
                            v5.clearall();
                            location.reload();
                        }, 2000);
                        PageLoad();
                    }
                });
            });
        }
    </script>
</body>
</html>
