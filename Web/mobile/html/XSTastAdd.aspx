<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XSTastAdd.aspx.cs" Inherits="yny_003.Web.mobile.html.XSTastAdd" %>

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
<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="fid" runat="server" />
            <input type="hidden" id="oid" runat="server" />
            <input type="hidden" id="sid" runat="server" />
            <div style="display: none;">
                <td width="15%" align="right">商品订单号<input runat="server" id="Hidden1" type="hidden" />
                </td>
                <td width="20%" style="height: 40px;">
                    <input id="ocode" class="normal_input" runat="server" readonly="readonly" style="width: 30%;" />
                </td>
            </div>
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">任务订单号</div>
                            <input runat="server" id="lbID" type="hidden" />
                            <div class="item-input">
                                <input type="text" id="Name" runat="server">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">任务类型</div>
                            <div class="item-input">
                                <select id="TType" runat="server">
                                    <option value="1">装车</option>
                                    <option value="2">卸车</option>
                                    <%--<option value="3">空车</option>--%>
                                </select>
                            </div>
                        </div>
                    </div>
                </li>

                <li id="gysstr">
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">供应商</div>
                            <div class="item-input">
                                <select id="SupplierName" runat="server">
                                </select>
                            </div>
                        </div>
                    </div>
                </li>
                <li id="khstr">
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">客户</div>
                            <div class="item-input">
                                <select id="SupplierName2" runat="server">
                                </select>
                            </div>
                        </div>
                    </div>
                </li>
                <li id="kcstr">
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">客户或供应商</div>
                            <div class="item-input">
                                <select id="SupplierName3" runat="server">
                                </select>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">任务地址</div>
                            <div class="item-input">
                                <input type="text" id="SupplierAddress" runat="server">
                            </div>
                        </div>
                    </div>
                </li>
                <li style="display: none;">
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">客户联系人</div>
                            <div class="item-input">
                                <input type="text" id="SupplierTelName" runat="server">
                            </div>
                        </div>
                    </div>
                </li>
                <li style="display: none;">
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">客户电话</div>
                            <div class="item-input">
                                <input type="text" id="SupplierTel" runat="server">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label" id="jhstr">调度派遣车辆时间</div>
                            <div class="item-input">
                                <input type="text" id="ComDate" name="ComDate" class="laydate-icon"  onclick="laydate({istime: true, format: 'YYYY-MM-DD hh:mm:ss'})" runat="server">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">比重</div>
                            <div class="item-input">
                                <select id="txtProt" runat="server" name="txtProt">
                                    <option value="1" selected="selected">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                </select>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">选择货物商品</div>
                            <div class="item-input">
                                <select id="txtGood" runat="server" onchange="getgooddanwei(this[selectedIndex].value)" style="width: 80px; float: left;">
                                </select><span id="gooddanwei" style="font-size: 10px; float: right; margin: 6% 0;"></span>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">填写数量</div>
                            <div class="item-input">
                                <input type="text" id="txtGoodCount" runat="server" style="width: 80px; float: left;">
                                <span id="gooddanwei2" style="font-size: 10px; float: right; margin: 6% 0;"></span>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">填写价格</div>
                            <div class="item-input">
                                <input type="text" id="txtGoodPrice" runat="server" style="width: 80px; float: left;"><span id="gooddanwei3" style="font-size: 10px; float: right; margin: 6% 0;"></span>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">备注</div>
                            <div class="item-input">
                                <input type="text" id="Spare1" runat="server">
                            </div>
                        </div>
                    </div>
                </li>
                <li style="display: none;">
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">拍照</div>
                            <div class="item-input">
                                <%--<input type="file" id="imageUrl" name="imageUrl" accept="image/*" capture="camera">--%>
                                <input type="file" name="upload" accept="image/*" multiple class="layui-upload-file">
                                <input type="hidden" id="uploadurl" name="uploadurl" runat="server" />
                                <img id="upimage" height="50px" />

                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </form>
    </div>
    <div class="content-block">
        <div class="row">
            <div class="col-100">
                <a href="javascript:checkChange();" class="button button-big button-fill button-success">提交</a>
            </div>
        </div>
    </div>
</div>
<script>
    //laydate({
    //    elem: '#ComDate',
    //    event: 'focus'
    //});
    
  
</script>
<script type="text/javascript">
    //setTimeout(function () {
        
    //    if ($("#sid").val() != '') {
    //        var info = RunAjaxGetKey('getsudetalis', $("#sid").val());
    //        alert(info.split("^")[0]);
    //        $("#SupplierAddress").val(info.split("^")[0]);
    //        $("#SupplierTelName").val(info.split("^")[1]);
    //        $("#SupplierTel").val(info.split("^")[2]);
    //    }

    //}, 300);
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

    $("#SupplierName").change(function () {
        getsudetalis($("#SupplierName").val());
    });
    $("#SupplierName2").change(function () {
        getsudetalis($("#SupplierName2").val());
    });
    $("#SupplierName3").change(function () {
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

    function getsudetalis(sid) {
        var info = RunAjaxGetKey('getsudetalis', sid);
        $("#SupplierAddress").val(info.split("^")[0]);
        $("#SupplierTelName").val(info.split("^")[1]);
        $("#SupplierTel").val(info.split("^")[2]);
    }

    function getgooddanwei(gid) {
        var info = RunAjaxGetKey('getgooddanwei', gid);
        document.getElementById("gooddanwei").innerHTML = info;
        document.getElementById("gooddanwei2").innerHTML = info;
        document.getElementById("gooddanwei3").innerHTML = "元";
    }

    function checkChange() {
        if ($("#TType").val() == '1')
        {
            if ($('#SupplierName').val() == '--请选择--') {
                layer.msg('供应商或客户不能为空');
                return;
            } 
        } else if ($("#TType").val() == '2') {
            if ($('#SupplierName2').val() == '--请选择--') {
                layer.msg('供应商或客户不能为空');
                return;
            }
        } else {
            if ($('#SupplierName3').val() == '--请选择--') {
                layer.msg('供应商或客户不能为空');
                return;
            }
        }
        
        if ($('#txtGood').val() == '--请选择--') {
            layer.msg('货物不能为空');
        } else {
            ActionModel("Car/AddTast.aspx?Action=Modify", $('#form1').serialize(), "mobile/html/XSTastList.aspx");
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
