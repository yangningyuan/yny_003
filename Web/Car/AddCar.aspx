<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="yny_003.Web.Car.AddCar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>车辆新增</title>
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
                        牌照<input runat="server" id="lbID" type="hidden" />
                    </td>
                    <td width="20%" style="height: 40px;">
                        <input id="PZCode" class="normal_input" runat="server" style="width: 30%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        车型
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarType" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        品牌
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarBrand" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        发动机号
                    </td>
                    <td width="75%" style="height: 40px;">
                      <input id="CarEngine" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        车架号
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarCJCode" class="normal_input" runat="server" style="width: 50%;" />
                    </td>
                </tr>
                  <tr>
                    <td width="15%" align="right">
                        行驶证号
                    </td>
                    <td width="75%" style="height: 40px;">
                    <input id="CarXSZCode" class="normal_input" runat="server" style="width: 50%;" />
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        吨位
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarDW" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        燃油类型
                    </td>
                    <td width="75%" style="height: 40px;">
                         <select id="RYType" runat="server">
                             <option value="#93">#93</option>
                             <option value="#95">#95</option>
                             <option value="#97">#97</option>
                            </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        保险到期时间
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server" name="BXDate"  id="BXDate" placeholder="保险到期时间"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'BXDate\')}' })" />
                    </td>
                </tr>
                  <tr>
                    <td align="right">
                        营运证号到期时间
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="YYZDate"  id="YYZDate" placeholder="营运证号到期时间"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'YYZDate\')}' })" />
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        保养到期时间
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="BYDate"  id="BYDate" placeholder="保养到期时间"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'BYDate\')}' })" />
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        罐检验到期时间
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="GJYDate"  id="GJYDate" placeholder="罐检验到期时间"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'GJYDate\')}' })" />
                    </td>
                </tr>
                   <tr>
                    <td align="right">
                        安全阀检验到期日期
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="AQFDate"  id="AQFDate" placeholder="安全阀检验到期日期"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'AQFDate\')}' })" />
                    </td>
                </tr>
                  <tr>
                    <td width="15%" align="right">
                        总里程
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarZLC" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                  <tr>
                    <td width="15%" align="right">
                        备注
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="Remark" class="normal_input" runat="server" style="width: 50%;" />
                        
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
                ActionModel("Car/AddCar.aspx?Action=Modify", $('#form1').serialize(), "Car/CarList.aspx");
            //}
        }
    </script>
</body>
</html>