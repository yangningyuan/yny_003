<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAccountBank.aspx.cs" Inherits="yny_003.Web.Car.AddAccountBank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>账户管理</title>
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
                        账户名称：<input runat="server" id="lbID" type="hidden" />
                    </td>
                    <td width="20%" style="height: 40px;">
                        <input id="AccountName" class="normal_input" runat="server" style="width: 30%;" />
                        
                    </td>
                </tr>
               
              <%--   <tr>
                    <td width="15%" align="right">
                        账户余额
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="Money" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        开户名
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CardName" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        开户行
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="BankName" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>--%>
                 
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
            ActionModel("Car/AddAccountBank.aspx?Action=Modify", $('#form1').serialize(), "Car/BankAccountList.aspx","账户列表");
            //}
        }
    </script>
</body>
</html>