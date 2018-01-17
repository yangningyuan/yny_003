<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpMemberSJ.aspx.cs" Inherits="zx270.Web.Member.UpMemberSJ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        我的帐号:
                    </td>
                    <td>
                        <%=TModel.MID %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        我的姓名:
                    </td>
                    <td>
                        <%=TModel.MName %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        我的报单币:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB %>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" align="right">
                        升级会员账号:
                    </td>
                    <td>
                        <%=sjmodel.MID%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        升级会员姓名:
                    </td>
                    <td>
                        <%=sjmodel.MName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        升级当前级别:
                    </td>
                    <td style="font-weight: bold; color: Red;">
                        <%=sjmodel.MAgencyType.MAgencyName%>
                        <input id="hdmid" type="hidden" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        级别:
                    </td>
                    <td>
                        <table style="width: 700px;">
                            <tr>
                                <%=MAgencyTypeColor%>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        升级:
                    </td>
                    <td>
                        <%=MyMAgencyTypeRdo%>
                    </td>
                </tr>
                <%--<%
                    if (isNew)
                    {
                %>
                <tr>
                    <td align="right">
                        接点人:
                    </td>
                    <td>
                        <input type="text" id="txtMBD" name="txtMBD" />
                    </td>
                </tr>
                <%
                    }
                %>--%>
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
        function ActionModelAndRefreathPage(acturl, actdata, fun) {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: acturl,
                    data: actdata,
                    success: function (info) {
                        v5.error(info, '2', 'true');
                        if (info.indexOf('*') <= 0) {
                            setTimeout(function () {
                                v5.clearall();
                                window.location.reload();
                            }, 2000);
                        }
                    }
                });
            }, fun);
        }

        function upAgency() {
            var roleCode = '<%=TModel.RoleCode %>';
            if (roleCode == "Notactive") {
                ActionModelAndRefreathPage("Member/UpMemberSJ.aspx?Action=modify", $('#form1').serialize(), null);
            }
            else {
                ActionModelBackWithTitle("Member/UpMemberSJ.aspx?Action=modify", $('#form1').serialize(), "<%=url %>",
                function () {
                    $("#btnOK").removeAttr("onclick");
                    $("#btnOK").val("请等待...");
                }, '升级管理');
            }
        }

        function checkChange() {
            if ($("input[name='AgencyTypeList']:checked").length > 0) {
                if (checkForm()) {
                    v5.confirm("确定要升级吗？", upAgency, 'true');
                }
            } else {
                v5.error("请先选择升级的等级", '2', 'true');
            }

            //            if (checkForm()) {
            //                var isNew = '<%=isNew %>';
            //                if (isNew) {
            //                    if ($("#txtMBD").val() == "") {
            //                        v5.error("接点人不能为空", '2', 'true');
            //                        return;
            //                    }
            //                }
            //                v5.confirm("确定要追加投资进行升级吗？", upAgency, 'true');
            //            }
        }
    </script>
</body>
</html>
