<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DDTast.aspx.cs" Inherits="yny_003.Web.Car.DDTast" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>任务调度</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script>
        layui.use("upload", function () {
            layui.upload({
                url: '/Admin/UpLoadPic/UploadImage.ashx',
                success: function (res) {
                    console.log(res); //上传成功返回值，必须为json格式
                    if (res.isSuccess) {
                        $("#upimage").attr("src", res.msg);
                        $("#uploadurl").val(res.msg);
                    } else {
                        v5.alert(res.msg, '1', 'true')
                    }
                }
            });
        });

    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <input type="hidden" id="fid" runat="server" />
                <input type="hidden" id="oid" runat="server" />
                <table cellpadding="0" cellspacing="0">
                    <tr style="display: none;">
                        <td width="15%" align="right">商品订单号<input runat="server" id="Hidden1" type="hidden" />
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="ocode" class="normal_input" runat="server" readonly="readonly" style="width: 30%;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <b style="margin-left: 5%;">任务信息</b>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">任务订单号<input runat="server" id="lbID" type="hidden" />
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="Name" class="normal_input" readonly="readonly" runat="server" style="width: 30%;" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">任务类型
                        </td>
                        <td width="75%" style="height: 40px;">
                            <select id="TType" runat="server">
                                <option value="1">装车</option>
                                <option value="2">卸车</option>
                                <option value="3">空车</option>
                            </select>
                        </td>
                    </tr>
                   
                   
                    <tr>
                        <td align="right" id="jhstr">交货时间
                        </td>
                        <td style="padding: 15px;">
                            <input type="text" runat="server" name="ComDate" id="ComDate" placeholder=""
                                class="daycash_input" onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'BXDate\')}' })" />
                        </td>
                    </tr>
                   <%-- <tr>
                        <td colspan="2">
                            <b style="margin-left: 5%;">商品信息</b>
                        </td>
                    </tr>

                    <tr>
                        <td width="15%" align="right">选择货物商品
                        </td>
                        <td width="75%" style="height: 40px;">
                            <select id="txtGood" runat="server"  onchange="getgooddanwei(this[selectedIndex].value)">
                            </select><span id="gooddanwei"></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">填写数量
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="txtGoodCount" class="normal_input" runat="server" style="width: 10%;" />
                            <span id="gooddanwei2"></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">填写价格
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="txtGoodPrice" class="normal_input" runat="server" style="width: 10%;" />
                            <span id="gooddanwei3"></span>
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="2">
                            <b style="margin-left: 5%;">车辆信息</b>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%" align="right">派遣牵引车辆
                        </td>
                        <td width="75%" style="height: 40px;">
                            <%--<input id="Spare2" class="normal_input" runat="server" style="width: 10%;" />--%>
                            <select id="Spare2" runat="server">
                                
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">派遣挂车（可空）
                        </td>
                        <td width="75%" style="height: 40px;">
                            <%--<input id="CSpare2" class="normal_input" runat="server" style="width: 10%;" />--%>
                             <select id="CSpare2" runat="server">
                              
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">主驾驶
                        </td>
                        <td width="75%" style="height: 40px;">
                            <%--<input id="CarSJ1" class="normal_input" runat="server" style="width: 10%;"  oninput="setViewSiJi1($('#CarSJ1').val());" />--%>
                            <select id="CarSJ1" runat="server"   onchange="setViewSiJi1(this[selectedIndex].value)">
                            </select>
                            <span id="sjview1"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">押运员
                        </td>
                        <td style="padding: 15px;">
                            <%--<input id="CarSJ2" class="normal_input" runat="server" style="width: 10%;"  onblur="setViewSiJi2($('#CarSJ2').val());"  />--%>
                             <select id="CarSJ2" runat="server"   onchange="setViewSiJi2(this[selectedIndex].value)">
                            </select>
                            <span id="sjview2"></span>
                        </td>
                    </tr>
                
                    <tr>
                        <td width="15%" align="right"></td>
                        <td width="75%" align="left">

                            <input type="button" class="normal_btnok" value="提交" runat="server" id="subview" onclick="checkChange();" />
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
                    ActionModel("Car/DDTast.aspx?Action=Modify", $('#form1').serialize(), "Car/TastList.aspx");
                    //}
                }
                function setViewSiJi1(realobj) {
                    //$.ajax({
                    //    type: 'post',
                    //    url: 'Car/AddTast.aspx?Action=Add',
                    //    data: $('#form1').serialize(),
                    //    success: function (info) {
                    document.getElementById("sjview1").innerHTML = RunAjaxGetKey('GetCarSJ1', $('#CarSJ1').val());
                    //    }
                    //});
            
                }
                function setViewSiJi2(realobj) {
                    //$.ajax({
                    //    type: 'post',
                    //    url: 'Car/AddTast.aspx?Action=Other',
                    //    data: $('#form1').serialize(),
                    //    success: function (info) {
                    document.getElementById("sjview2").innerHTML = RunAjaxGetKey('GetCarSJ2', $('#CarSJ2').val());
                    //    }
                    //});

                }
    </script>
</body>
</html>
