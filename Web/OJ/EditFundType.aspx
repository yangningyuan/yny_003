<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFundType.aspx.cs" Inherits="yny_003.Web.OJ.EditFundType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>经费来源新增修改</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        经费来源名称<input runat="server" id="lbID" type="hidden" />
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="txtName" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        备注
                    </td>
                    <td style="padding: 15px;">
                        <input id="txtRemark" class="normal_input" runat="server" style="width: 50%;" />
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
            if ($('#txtName').val() == '') {
                v5.error('经费来源不能为空', '1', 'ture');
            } else {
                ActionModel("OJ/EditFundType.aspx?Action=Modify", $('#form1').serialize(), "OJ/FundTypeList.aspx");
            }
        }
    </script>
</body>
</html>
