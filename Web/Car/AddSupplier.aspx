<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSupplier.aspx.cs" Inherits="yny_003.Web.Car.AddSupplier" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>费用新增</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <input type="hidden" id="fid" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        类型<input runat="server" id="lbID" type="hidden" />
                    </td>
                    <td width="20%" style="height: 40px;">
                        <select id="sType" runat="server">
                                <option value="1">供应商资料</option>
                                <option value="2">客户资料</option>
                            </select>
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        名称
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="Name" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        税号
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="SHCode" class="normal_input" runat="server" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        账号
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="UserCode" class="normal_input" runat="server" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        结账周期
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="ZQDate" class="normal_input" runat="server" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        资质
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="ZZValue" class="normal_input" runat="server" value="0" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        联系人
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="TelName" class="normal_input" runat="server" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        联系电话
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="Tel" class="normal_input" runat="server" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        欠款金额
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="QCMoney" class="normal_input" value="0" runat="server" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        期初金额
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="OverMoney" class="normal_input" value="0" runat="server" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        地址
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="Address" class="normal_input" runat="server" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        备注
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="Remark" class="normal_input" runat="server" style="width: 20%;" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                    </td>
                    <td width="75%" align="left">
                        
                        <input type="button" class="normal_btnok" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        
        function checkChange() {
            //if ($('#txtName').val() == '') {
            //    v5.error('经费项目名称不能为空', '1', 'ture');
            //} else {
            ActionModel("Car/AddSupplier.aspx?Action=Modify", $('#form1').serialize(), "Car/SupplierList.aspx");
            //}
        }
    </script>
</body>
</html>