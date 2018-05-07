<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyMember.aspx.cs" Inherits="yny_003.Web.Member.ModifyMember"
    EnableEventValidation="false" %>

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
                        <td width="15%" align="right">员工账号:
                        </td>
                        <td width="35%">
                            <input id="txtMID" runat="server" class="normal_input" type="text" readonly="readonly"
                                maxlength="20" />
                        </td>
                        <td width="15%" align="right">员工姓名:
                        </td>
                        <td width="35%">
                            <input id="txtMName" runat="server" class="normal_input" type="text" maxlength="30" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">角色:
                        </td>
                        <td>
                            <select id="ddlMemberType" runat="server">
                            </select>
                        </td>
                        <td align="right">手机号码:
                        </td>
                        <td>
                            <input id="txtTel" runat="server" class="normal_input" type="text" maxlength="15" />
                        </td>
                    </tr>
                    <tr>

                        <td align="right">身份证号码:
                        </td>
                        <td>
                            <input id="txtNumID" runat="server" class="normal_input" type="text" maxlength="18" />
                        </td>
                        <td align="right">司机类型:
                        </td>
                        <td>
                            <select id="ZWType" name="ZWType" runat="server">
                                <option value="" selected="selected">未知职位</option>
                                <option value="1">主司机</option>
                                <option value="2">副司机</option>
                                <option value="3">押运员</option>
                            </select>
                        </td>
                    </tr>
                       <tr>

                        <td align="right">从业证书:
                        </td>
                        <td>
                            <input id="txtAddress" runat="server" class="normal_input" type="text" maxlength="18" />
                        </td>
                        <td align="right">
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                    <tr style="display: none;">


                        <td align="right">推荐人:
                        </td>
                        <td>
                            <input id="txtMTJ" runat="server" class="normal_input" type="text" maxlength="20"
                                readonly="readonly" />
                        </td>

                    </tr>

                    <tr>
                        <td align="right">密保问题:
                        </td>
                        <td>
                            <select id="ddlQuestion" name="ddlQuestion" runat="server">
                            </select>
                        </td>
                        <td align="right">密保答案:
                        </td>
                        <td>
                            <input id="txtAnswer" name="txtAnswer" runat="server" type="text" /><span class="dotted">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">登录密码:
                        </td>
                        <td>
                            <input id="txtPassword" runat="server" class="normal_input" type="text" maxlength="32" />
                        </td>
                        <td align="right">锁定状态:
                        </td>
                        <td>
                            <input id="chkIsClose" runat="server" type="checkbox" />禁止登录
                        </td>
                        <%--   <td align="right">资金密码:
                        </td>
                        <td>
                            <input id="txtSecPsd" runat="server" class="normal_input" type="text" maxlength="32" />
                        </td>--%>
                    </tr>

                    <tr style="height: 50px;">
                        <td colspan="2" style="text-align: right;"></td>
                        <td colspan="2" align="left">
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        //setup();

        function checkChange() {
            if ($('#txtMName').val().Trim() == '') {
                v5.error('员工姓名不能为空', '1', 'true');
                //} else if (RunAjaxGetKey('getMName', $('#txtMTJ').val()) == '') {
                //    v5.error('推荐人不存在', '1', 'true');
                //} else if ($('#ddlZone').val() == '县市') {
                //    v5.error('请选择地区', '1', 'true');
            } else {
                ActionModel("Member/ModifyMember.aspx?Action=Modify", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
