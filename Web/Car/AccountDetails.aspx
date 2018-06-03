<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="yny_003.Web.Car.AccountDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增付款结账单</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <input type="hidden" id="fid" runat="server" />
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="15%" align="right">付款单编号<input runat="server" id="lbID" type="hidden" />
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="CName" class="normal_input" runat="server" style="width: 30%;" readonly />

                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">供应商
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="SupplierName" class="normal_input" runat="server" style="width: 50%;"  readonly/>

                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">总金额
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="TotalMoney" class="normal_input" runat="server" style="width: 30%;" readonly  />

                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">已付金额
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="ReMoney" class="normal_input" runat="server" style="width: 30%;"  readonly />

                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">付款类型
                        </td>
                        <td width="75%" style="height: 40px;">
                            <select name="PayType" id="PayType">
                                <option selected="selected" value="0">现金</option>
                                <option value="1">账户余额抵扣</option>
                            </select>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%" align="right">供应商账户余额
                        </td>
                        <td width="75%" style="height: 40px;">
                             <input id="yue" class="normal_input" runat="server" style="width: 30%;"  readonly />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">付款金额
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="PayMoney" class="normal_input" runat="server" style="width: 20%; "/>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">付款说明
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="Spare" class="normal_input" runat="server" style="width: 50%;" />

                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right"></td>
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
            if ($('#PayMoney').val() == '') {
                v5.error('付款金额不能为空', '1', 'ture');
            } else {
                ActionModel("Car/AccountDetails.aspx?Action=Modify", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
