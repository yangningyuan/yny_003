<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddObjSub.aspx.cs" Inherits="yny_003.Web.OJ.AddObjSub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>经费项目子项新增</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr style="display:none;">
                    <td width="15%" align="right">
                        项目子项名称
                        <input runat="server" id="objid" type="hidden" />
                    </td>
                    <td width="20%" style="height: 40px;">
                        <input id="txtName" class="normal_input" runat="server" style="width: 30%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        子项负责人
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="txtPerson" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
               
                 <tr>
                    <td width="15%" align="right">
                        子项类型
                    </td>
                    <td width="75%" style="height: 40px;">
                      <select id="txtSubType" runat="server">
                            </select>
                    </td>
                </tr>
               
                 <tr>
                    <td width="15%" align="right">
                        项目子项资金
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="txtMoney" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        项目已用子项资金
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="txtReMoney" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        项目超支比例
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="txtCZFloat" class="normal_input" runat="server" style="width: 50%;" />
                        
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
            //if ($('#txtName').val() == '') {
            //    v5.error('经费项目子项名称不能为空', '1', 'ture');
            //} else
            {
                ActionModel("OJ/AddObjSub.aspx?Action=Modify", $('#form1').serialize(), "OJ/ObjList.aspx");
            }
        }
    </script>
</body>
</html>