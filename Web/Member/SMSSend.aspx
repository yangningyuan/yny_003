<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMSSend.aspx.cs" Inherits="zx270.Web.Member.SMSSend" %>

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
                    <td width="15%" align="right">
                        会员账号:
                    </td>
                    <td width="35%">
                        <input id="txtMID" runat="server" class="normal_input" type="text" readonly="readonly" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        会员姓名:
                    </td>
                    <td width="35%">
                        <input id="txtMName" maxlength="20" runat="server" class="normal_input" type="text"
                            readonly="readonly" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        手机号码:
                    </td>
                    <td>
                        <input id="txtTel" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        短信内容:
                    </td>
                    <td>
                        <textarea id="txtContent" runat="server" rows="20" cols="20" style="width: 400px;
                            height: 100px;"></textarea>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="发送" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtTel').val().TryTel() == '') {
                v5.error('手机号码格式不正确', '1', 'true');
            } else if ($('#txtContent').val() == '') {
                v5.error('短信内容不能为空', '1', 'true');
            } else {
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: "/Member/SMSSend.aspx?Action=Add",
                        data: { tel: $('#txtTel').val(), contents: $("#txtContent").val() },
                        success: function (info) {
                            setTimeout(function () { v5.clearall(); }, 1000);
                        }
                    });
                });
            }
        }
    </script>
</body>
</html>
