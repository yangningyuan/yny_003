<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTast.aspx.cs" Inherits="yny_003.Web.Car.AddTast" %>

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
                   
                    <tr id="gysstr">
                        <td width="15%" align="right">供应商
                        </td>
                        <td width="75%" style="height: 40px;">
                            <%--<input id="SupplierName" class="normal_input" runat="server" style="width: 50%;" />--%>
                            <select id="SupplierName" runat="server">
                                
                            </select>
                        </td>
                    </tr>
                    <tr  id="khstr">
                        <td width="15%" align="right">客户
                        </td>
                        <td width="75%" style="height: 40px;">
                            <%--<input id="SupplierName" class="normal_input" runat="server" style="width: 50%;" />--%>
                            <select id="SupplierName2" runat="server">
                                
                            </select>
                        </td>
                    </tr> 
                    <tr  id="kcstr">
                        <td width="15%" align="right">客户或供应商
                        </td>
                        <td width="75%" style="height: 40px;">
                            <%--<input id="SupplierName" class="normal_input" runat="server" style="width: 50%;" />--%>
                            <select id="SupplierName3" runat="server">
                                
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">任务地址
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="SupplierAddress" class="normal_input" runat="server" style="width: 50%;" />

                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td width="15%" align="right">客户联系人
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="SupplierTelName" class="normal_input" runat="server" style="width: 50%;" />
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td width="15%" align="right">客户电话
                        </td>
                        <td width="75%" style="height: 40px;">
                            <input id="SupplierTel" class="normal_input" runat="server" style="width: 10%;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" id="jhstr">调度派遣车辆时间
                        </td>
                        <td style="padding: 15px;">
                            <input type="text" runat="server" name="ComDate" id="ComDate" placeholder=""
                                class="daycash_input" onclick="WdatePicker({ stateDate: '#F{$dp.$D(\'BXDate\')}' })" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">比重（越大越紧急）
                        </td>
                        <td width="75%" style="height: 40px;">
                             <select id="txtProt" runat="server"  name="txtProt">
                                 <option value="1" selected="selected">1</option>
                                 <option value="2" >2</option>
                                 <option value="3" >3</option>
                            </select>
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
                    </tr>
                    <%--<tr>
                        <td colspan="2">
                            <b style="margin-left: 5%;">车辆信息</b>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%" align="right">派遣牵引车辆
                        </td>
                        <td width="75%" style="height: 40px;">
                            
                            <select id="Spare2" runat="server">
                                
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">派遣挂车（可空）
                        </td>
                        <td width="75%" style="height: 40px;">
                            
                             <select id="CSpare2" runat="server">
                                
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">主驾驶
                        </td>
                        <td width="75%" style="height: 40px;">
                            
                            <select id="CarSJ1" runat="server"   onchange="setViewSiJi1(this[selectedIndex].value)">
                            </select>
                            <span id="sjview1"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">副驾驶
                        </td>
                        <td style="padding: 15px;">
                            
                             <select id="CarSJ2" runat="server"   onchange="setViewSiJi2(this[selectedIndex].value)">
                            </select>
                            <span id="sjview2"></span>
                        </td>
                    </tr>--%>
                    <tr style="display:none;">
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

                            <input type="button" class="normal_btnok" value="提交调度处理" onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            if ($("#TType").val() == "1") {
                document.getElementById("jhstr").innerHTML = "装车业务派遣时间";
                document.getElementById("gysstr").style.display = "";
                document.getElementById("khstr").style.display = "none";
                document.getElementById("kcstr").style.display = "none";
                getsudetalis($("#SupplierName").val());
            } else if ($("#TType").val() == "2") {
                document.getElementById("jhstr").innerHTML = "卸车业务派遣时间";
                document.getElementById("gysstr").style.display = "none";
                document.getElementById("khstr").style.display = "";
                document.getElementById("kcstr").style.display = "none";
                getsudetalis($("#SupplierName2").val());
            } else {
                document.getElementById("jhstr").innerHTML = "到达时间";
                document.getElementById("gysstr").style.display = "none";
                document.getElementById("khstr").style.display = "none";
                document.getElementById("kcstr").style.display = "";
                getsudetalis($("#SupplierName3").val());
            }
        });

        $("#SupplierName").click(function () {
            getsudetalis($("#SupplierName").val());
        });
        $("#SupplierName2").click(function () {
            getsudetalis($("#SupplierName2").val());
        });
        $("#SupplierName3").click(function () {
            getsudetalis($("#SupplierName3").val());
        });

            $("#TType").click(function () {
                if ($("#TType").val() == "1") {
                    document.getElementById("jhstr").innerHTML = "装车业务派遣时间";
                    document.getElementById("gysstr").style.display = "";
                    document.getElementById("khstr").style.display = "none";
                    document.getElementById("kcstr").style.display = "none";
                } else if ($("#TType").val() == "2") {
                    document.getElementById("jhstr").innerHTML = "卸车业务派遣时间";
                    document.getElementById("gysstr").style.display = "none";
                    document.getElementById("khstr").style.display = "";
                    document.getElementById("kcstr").style.display = "none";
                } else {
                    document.getElementById("jhstr").innerHTML = "到达时间";
                    document.getElementById("gysstr").style.display = "none";
                    document.getElementById("khstr").style.display = "none";
                    document.getElementById("kcstr").style.display = "";
                }
            });

            function getsudetalis(sid)
            {
                var info = RunAjaxGetKey('getsudetalis', sid);
                $("#SupplierAddress").val(info.split("^")[0]);
                $("#SupplierTelName").val(info.split("^")[1]);
                $("#SupplierTel").val(info.split("^")[2]);
            }

            function getgooddanwei(gid)
            {
                var info = RunAjaxGetKey('getgooddanwei', gid);
                document.getElementById("gooddanwei").innerHTML = info;
                document.getElementById("gooddanwei2").innerHTML = info;
                document.getElementById("gooddanwei3").innerHTML = info;
            }

                function checkChange() {
                    if ($('#SupplierName').val() == '--请选择--') {
                        v5.error('供应商或客户不能为空', '1', 'ture');
                    } else if ($('#txtGood').val() == '--请选择--') {
                        v5.error('货物不能为空', '1', 'ture');
                    } else{
                    ActionModel("Car/AddTast.aspx?Action=Modify", $('#form1').serialize(), "Car/TastList.aspx");
                    }
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
