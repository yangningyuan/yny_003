<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCost.aspx.cs" Inherits="yny_003.Web.Car.AddCost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>客户新增</title>
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
                        <input id="Name" class="normal_input" runat="server" style="width: 30%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        费用说明
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="Details" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        限额
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="XEMoney" class="normal_input" runat="server" style="width: 20%;" />
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
                ActionModel("Car/AddCost.aspx?Action=Modify", $('#form1').serialize(), "Car/CostList.aspx");
            //}
        }
    </script>
</body>
</html>