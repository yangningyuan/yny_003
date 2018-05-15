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
                        车辆类型
                    </td>
                    <td width="75%" style="height: 40px;">
                        <select id="CType" runat="server">
                            <option value="牵引车" selected="selected">牵引车</option>
                            <option value="挂车">挂车</option>
                        </select>
                        
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
                 <tr id="gc1">
                    <td width="15%" align="right">
                        发动机号
                    </td>
                    <td width="75%" style="height: 40px;">
                      <input id="CarEngine" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr id="gc2">
                    <td width="15%" align="right">
                        车架号
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarCJCode" class="normal_input" runat="server" style="width: 50%;" />
                    </td>
                </tr>
                  <tr  id="gc3">
                    <td width="15%" align="right">
                        行驶证号
                    </td>
                    <td width="75%" style="height: 40px;">
                    <input id="CarXSZCode" class="normal_input" runat="server" style="width: 50%;" />
                    </td>
                </tr>
                
                 <tr>
                    <td width="15%" align="right">
                        营运证号
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarYYZCode" class="normal_input" runat="server" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        罐体容积
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarGTRJ" class="normal_input" runat="server" value="0" style="width: 50%;" />
                        
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        吨位
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarDW" class="normal_input" value="0" runat="server" style="width: 50%;" />*小数
                        
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        运输介质
                    </td>
                    <td width="75%" style="height: 40px;">
                         <select id="selYSJZ" runat="server">
                             <option value="液氧">液氧</option>
                             <option value="液氮">液氮</option>
                             <option value="液氩">液氩</option>
                             <option value="二氧化碳">二氧化碳</option>
                             <option value="无缝钢瓶">无缝钢瓶</option>
                             <option value="杜瓦瓶">杜瓦瓶</option>
                             <option value="氧气">氧气</option>
                             <option value="氩气">氩气</option>
                             <option value="氮气">氮气</option>
                             <option value="食用级二氧化碳">食用级二氧化碳</option>
                             <option value="混合气">混合气</option>
                            </select>
                    </td>
                </tr>
                 <tr>
                    <td width="15%" align="right">
                        燃油类型
                    </td>
                    <td width="75%" style="height: 40px;">
                         <select id="RYType" runat="server">
                             <option value="燃油类型">燃油类型</option>
                             <option value="#93">#93</option>
                             <option value="#95">#95</option>
                             <option value="#97">#97</option>
                             <option value="柴油">柴油</option>
                             <option value="天然气">天然气</option>
                            </select>
                    </td>
                </tr>
              
                  <tr>
                    <td align="right">
                        营运证办理时间或年检时间
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="YYZDate"  id="YYZDate" placeholder="营运证号到期时间"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'YYZDate\')}' })" />
                    </td>
                </tr>
                 <tr  id="gc4">
                    <td align="right">
                        保养到期时间
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="BYDate"  id="BYDate" placeholder="保养到期时间"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'BYDate\')}' })" />
                    </td>
                </tr>
                 <tr id="qyc1">
                    <td align="right">
                        罐检验到期时间
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="GJYDate"  id="GJYDate" placeholder="罐检验到期时间"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'GJYDate\')}' })" />
                    </td>
                </tr>
                   <tr  id="qyc2">
                    <td align="right">
                        安全阀检验到期日期
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="AQFDate"  id="AQFDate" placeholder="安全阀检验到期日期"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'AQFDate\')}' })" />
                    </td>
                </tr>  <tr  id="qyc3">
                    <td align="right">
                        压力表检验到期日期
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server" name="BXDate"  id="BXDate" placeholder="压力表检验到期日期"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'BXDate\')}' })" />
                    </td>
                </tr>
                <hr />


                  <tr  id="gc5">
                    <td align="right">
                        交强险到期日期
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="JQXDate"  id="JQXDate" placeholder="交强险到期日期"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'JQXDate\')}' })" />
                    </td>
                </tr>
                  <tr id="gc6">
                    <td align="right">
                        三责险到期日期
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="SZXDate"  id="SZXDate" placeholder="三责险到期日期"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'SZXDate\')}' })" />
                    </td>
                </tr>
                  <tr id="gc7">
                    <td align="right">
                        承运险到期日期
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="CYXDate"  id="CYXDate" placeholder="承运险到期日期"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'CYXDate\')}' })" />
                    </td>
                </tr>
                  <tr id="qyc6">
                    <td align="right">
                        罐（压力容器购置日期）
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="CLRHDate"  id="CLRHDate" placeholder="车辆入户时间日期"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'CLRHDate\')}' })" />
                    </td>
                </tr>
                  <tr  id="gc8">
                    <td align="right">
                        车辆技术等级评定时间
                    </td>
                    <td style="padding: 15px;">
                        <input type="text" runat="server"  name="CLJJPDDate"  id="CLJJPDDate" placeholder="车辆技术等级评定时间"
                 class="daycash_input"   onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'CLJJPDDate\')}' })" />
                    </td>
                </tr>


                  <tr  id="gc9">
                    <td width="15%" align="right">
                        总里程
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="CarZLC" class="normal_input" runat="server" value="0" style="width: 50%;" />*整数
                        
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

        $("#CType").click(function () {
            if ($("#CType").val() == "挂车") {
                document.getElementById("gc1").style.display = "none";
                document.getElementById("gc2").style.display = "none";
                document.getElementById("gc3").style.display = "none";
                document.getElementById("gc4").style.display = "none";
                document.getElementById("gc5").style.display = "none";
                document.getElementById("gc6").style.display = "none";
                document.getElementById("gc7").style.display = "none";
                document.getElementById("gc8").style.display = "none";
                document.getElementById("gc9").style.display = "none";

                document.getElementById("qyc1").style.display = "";
                document.getElementById("qyc2").style.display = "";
                document.getElementById("qyc3").style.display = "";
                document.getElementById("qyc6").style.display = "";
            } else if ($("#CType").val() == "牵引车") {
                document.getElementById("qyc1").style.display = "none";
                document.getElementById("qyc2").style.display = "none";
                document.getElementById("qyc3").style.display = "none";
                document.getElementById("qyc6").style.display = "none";

                document.getElementById("gc1").style.display = "";
                document.getElementById("gc2").style.display = "";
                document.getElementById("gc3").style.display = "";
                document.getElementById("gc4").style.display = "";
                document.getElementById("gc5").style.display = "";
                document.getElementById("gc6").style.display = "";
                document.getElementById("gc7").style.display = "";
                document.getElementById("gc8").style.display = "";
                document.getElementById("gc9").style.display = "";
            } 
        });

        $(function () {
            if ($("#CType").val() == "挂车") {
                document.getElementById("gc1").style.display = "none";
                document.getElementById("gc2").style.display = "none";
                document.getElementById("gc3").style.display = "none";
                document.getElementById("gc4").style.display = "none";
                document.getElementById("gc5").style.display = "none";
                document.getElementById("gc6").style.display = "none";
                document.getElementById("gc7").style.display = "none";
                document.getElementById("gc8").style.display = "none";
                document.getElementById("gc9").style.display = "none";

                document.getElementById("qyc1").style.display = "";
                document.getElementById("qyc2").style.display = "";
                document.getElementById("qyc3").style.display = "";
                document.getElementById("qyc6").style.display = "";
                
            } else if ($("#CType").val() == "牵引车") {
                document.getElementById("qyc1").style.display = "none";
                document.getElementById("qyc2").style.display = "none";
                document.getElementById("qyc3").style.display = "none";
                document.getElementById("qyc6").style.display = "none";

                document.getElementById("gc1").style.display = "";
                document.getElementById("gc2").style.display = "";
                document.getElementById("gc3").style.display = "";
                document.getElementById("gc4").style.display = "";
                document.getElementById("gc5").style.display = "";
                document.getElementById("gc6").style.display = "";
                document.getElementById("gc7").style.display = "";
                document.getElementById("gc8").style.display = "";
                document.getElementById("gc9").style.display = "";
               
            }
        });
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