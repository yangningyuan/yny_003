﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTast.aspx.cs" Inherits="yny_003.Web.Car.AddTast" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>任务新增</title>
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
                        <td width="15%" align="right">任务名称<input runat="server" id="lbID" type="hidden" />
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="Name" class="normal_input" runat="server" style="width: 30%;" />
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
                        <td width="15%" align="right">派遣牵引车辆
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="Spare2" class="normal_input" runat="server" style="width: 10%;" />

                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">派遣挂车（可空）
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="CSpare2" class="normal_input" runat="server" style="width: 10%;" />

                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">供应商或客户
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="SupplierName" class="normal_input" runat="server" style="width: 50%;" />

                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">任务地址
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="SupplierAddress" class="normal_input" runat="server" style="width: 50%;" />

                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">客户联系人
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="SupplierTelName" class="normal_input" runat="server" style="width: 50%;" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">客户电话
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="SupplierTel" class="normal_input" runat="server" style="width: 10%;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">交货时间
                        </td>
                        <td style="padding: 15px;">
                            <input type="text" runat="server" name="ComDate" id="ComDate" placeholder="交货时间"
                                class="daycash_input" onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'BXDate\')}' })" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <b style="margin-left: 5%;">商品信息</b>
                        </td>
                    </tr>

                    <tr>
                        <td width="15%" align="right">选择货物商品
                        </td>
                        <td width="75%" style="height: 40px;">
                            <select id="txtGood" runat="server">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">填写数量
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="txtGoodCount" class="normal_input" runat="server" style="width: 10%;" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">填写价格
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="txtGoodPrice" class="normal_input" runat="server" style="width: 10%;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <b style="margin-left: 5%;">车辆信息</b>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">主驾驶
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="CarSJ1" class="normal_input" runat="server" style="width: 10%;"  oninput="setViewSiJi1($('#CarSJ1').val());" />
                            <span id="sjview1"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">副驾驶
                        </td>
                        <td style="padding: 15px;">
                            <input id="CarSJ2" class="normal_input" runat="server" style="width: 10%;"  onblur="setViewSiJi2($('#CarSJ2').val());"  />
                            <span id="sjview2"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">费用类型
                        </td>
                        <td style="padding: 15px;">
                            <select id="CostType" runat="server">
                            </select>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">磅单图片:
                        </td>
                        <td>
                            <input type="file" name="upload" class="layui-upload-file">
                            <input type="hidden" id="uploadurl" name="uploadurl" runat="server" />
                            <img id="upimage" width="100px;" height="100px" />
                        </td>
                    </tr>

                    <tr>
                        <td width="15%" align="right">备注
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="Spare1" class="normal_input" runat="server" style="width: 50%;" />

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
            //if ($('#txtName').val() == '') {
            //    v5.error('经费项目名称不能为空', '1', 'ture');
            //} else {
            ActionModel("Car/AddTast.aspx?Action=Modify", $('#form1').serialize(), "Car/TastList.aspx");
            //}
        }
        function setViewSiJi1(realobj) {
            $.ajax({
                type: 'post',
                url: 'Car/AddTast.aspx?Action=Add',
                data: $('#form1').serialize(),
                success: function (info) {
                    document.getElementById("sjview1").innerHTML = info;
                }
            });
            
        }
        function setViewSiJi2(realobj) {
            $.ajax({
                type: 'post',
                url: 'Car/AddTast.aspx?Action=Other',
                data: $('#form1').serialize(),
                success: function (info) {
                    document.getElementById("sjview2").innerHTML = info;
                }
            });

        }
    </script>
</body>
</html>
