<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditObj.aspx.cs" Inherits="yny_003.Web.OJ.EditObj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>经费项目新增修改</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        经费项目名称<input runat="server" id="oID" type="hidden" />
                    </td>
                    <td width="20%" style="height: 40px;">
                        <input id="txtName" class="normal_input" runat="server" style="width: 30%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        项目负责人
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="txtPerson" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        实施单位
                    </td>
                    <td width="75%" style="height: 40px;">
                        <%=impstr %>
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        经费来源
                    </td>
                    <td width="75%" style="height: 40px;">
                      <select id="txtFundID" runat="server">
                            </select>
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        批复文号
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="txtTheNumID" class="normal_input" runat="server" style="width: 50%;" />
                    </td>
                </tr>
                  <tr>
                    <td width="15%" align="right">
                        批复部门
                    </td>
                    <td width="75%" style="height: 40px;">
                      <select id="txtDepartID" runat="server">
                            </select>
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        项目资金
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="txtMoney" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        项目进度
                    </td>
                    <td width="75%" style="height: 40px;">
                         <select id="selState" runat="server">
                             <option value="0">未完成</option>
                             <option value="1">已完成</option>
                            </select>
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
                v5.error('经费项目名称不能为空', '1', 'ture');
            } else {
                ActionModel("OJ/EditObj.aspx?Action=Modify", $('#form1').serialize(), "OJ/ObjList.aspx");
            }
        }
    </script>
</body>
</html>