<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="yny_003.Web.Member.Add"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        //var K = window.KKKK;
        //var uploadbutton = K.uploadbutton({
        //    button: K('#GatheringPic')[0],
        //    fieldName: 'imgFile',
        //    url: 'plugin/kindeditor/asp.net/upload_json.ashx?dir=image',
        //    afterUpload: function (data) {
        //        if (data.error === 0) {
        //            var url = K.formatUrl(data.url, 'absolute');
        //            K('#hduploadPic1').val(url);
        //            K('#uploadLog').html("上传成功");
        //            uploadSuccess("上传成功|" + url);
        //        } else {
        //            $('#uploadLog').html(data.message);
        //        }
        //    },
        //    afterError: function (str) {
        //        alert('自定义错误信息: ' + str);
        //    }
        //});
        //uploadbutton.fileBox.change(function (e) {
        //    uploadbutton.submit();
        //});

        //function deletePic(obj) {
        //    if (confirm("确定要删除吗？")) {
        //        var fileName = $(obj).parent().find(".hidPicurl").val();
        //        var hidId = $(obj).parent().find(".hidId").val();
        //        var hidDelIds = $("#hidDelIds").val();
        //        if (typeof (fileName) != "undefined" && fileName != "") {
        //            if (typeof (hidId) != "undefined" && hidId != "") {
        //                hidDelIds += hidId + ",";
        //                $("#hidDelIds").val(hidDelIds);
        //            }
        //            //如果是把首页图片删除了，就要重新设定首页图片
        //            if ($(obj).parent().hasClass("mainDiv")) {
        //                $(obj).parent().remove();
        //                $(".appDiv").first().addClass("mainDiv");
        //                //给首页图片的隐藏控件重新赋值
        //                $("#hidMainPic").val($(".appDiv").first().find(".hidPicurl").val());
        //            }
        //            else {
        //                $(obj).parent().remove();
        //            }
        //        }
        //    }
        //}

        //function uploadSuccess(msg) {
        //    if (msg.split('|').length > 1) {//成功
        //        $("#uploadLog").html("上传成功...");
        //        $('#hduploadPic1').val(msg.split('|')[1]);
        //        var appendHtml = "<div class='appDiv'><img class='appImg' src='" + msg.split('|')[1] + "'/><img class='xClose' onclick='deletePic(this)'  title='删除' src='/Admin/pop/images/uploadify-cancel.png'/><input type='hidden' name='uploadPic' class='hidPicurl' value='" + msg.split('|')[1] + "'/></div>";
        //        $("#tablePic").append(appendHtml);
        //    } else {
        //        $('#uploadLog').html(msg);
        //    }
        //}
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <table cellpadding="0" cellspacing="0">
                   
                     <tr>
                        <td width="30%" align="right">员工账号:
                        </td>
                        <td>
                            <input id="txtMID" name="txtMID" runat="server" class="normal_input" type="text" maxlength="20" /><span
                                class="dotted">*</span>
                        </td>
                    </tr>
                         <tr>
                        <td align="right">员工姓名:
                        </td>
                        <td>
                            <input id="txtMName" name="txtMName" class="normal_input" type="text" maxlength="30" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">手机号码:
                        </td>
                        <td>
                            <input id="txtTel" name="txtTel" class="normal_input" type="text" maxlength="11" />
                            <input type="text" id="txtTelCode" name="txtTelCode" placeholder="请输入验证码" value="" style="width: 80px; display:none;" />
                            <input type="button" value="获取验证码" onclick="sendTelCode()" class="btn btn-success"  style="display:none;"/>
                        </td>
                    </tr>
                   <tr>
                        <td align="right">身份证号码:
                        </td>
                        <td>
                            <input id="txtNumID" name="txtNumID" class="normal_input" type="text" maxlength="18" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">性别:
                        </td>
                        <td>
                            <input type="radio" name="radioSex" checked="checked" value="1">男<input type="radio" name="radioSex" value="0">女
                        </td>
                    </tr>
                      <tr>
                        <td align="right">职务:
                        </td>
                        <td>
                          <select id="txtRole" name="txtRole"  onchange="gradeChange()">
                                <option value="">职务类型</option>
                                <%=RoleListStr %>
                            </select>
                        </td>
                    </tr>
                      
                    <tr style="display:none;" id="strzwtype">
                        <td align="right">职务类型:
                        </td>
                        <td>
                            <input type="radio" name="ZWType" value="1">主司机<input type="radio" name="ZWType" value="2">副司机<input type="radio" name="ZWType" value="3">押运员
                        </td>
                    </tr>
                      <tr style="display:none;" id="strzwadd">
                        <td align="right">从业资格证书:
                        </td>
                        <td>
                            <input id="txtAddress" name="txtAddress" class="normal_input" type="text" maxlength="18" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">登录密码:
                        </td>
                        <td>
                            <input id="txtPassword" name="txtPassword" class="normal_input" type="password" maxlength="20" /><span class="redWord dotted">*(6-20个字母或数字组合)</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">确认登录密码:
                        </td>
                        <td>
                            <input id="txtPassword2" name="txtPassword2" class="normal_input" type="password"
                                maxlength="20" /><span class="dotted">*</span>
                        </td>
                    </tr>
              
               
                    <tr style="display:none;">
                        <td align="right">密保问题:
                        </td>
                        <td>
                            <select id="ddlQuestion" name="ddlQuestion" runat="server">
                            </select>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right">密保答案:
                        </td>
                        <td>
                            <input id="txtAnswer" name="txtAnswer" value="" type="text" /><span class="dotted">*</span>
                        </td>
                    </tr>
                    <tr style="height: 50px;">
                        <td align="right">
                            <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                        </td>
                        <td align="left">
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        //setup();
        //setTimeout(function () {
        //    $('#ddlProvince')[0].selectedIndex = 1;
        //    $('#ddlProvince').change();
        //    $('#ddlCity')[0].selectedIndex = 1;
        //    $('#ddlCity').change();
        //    $('#ddlZone')[0].selectedIndex = 1;
        //}, 50);
        function gradeChange() {
            var objS = document.getElementById("txtRole");
            var index = objS.selectedIndex;

            if (objS.options[index].value == "SiJi") {
                document.getElementById("strzwtype").style.display = ""; 
                document.getElementById("strzwadd").style.display = "";
            } else {
                document.getElementById("strzwtype").style.display = "none";
                document.getElementById("strzwadd").style.display = "none";
            }
        }
        
        function sendTelCode() {
            var tel = $.trim($("#txtTel").val());
            if (tel == "") {
                v5.error('手机号码不能为空', '1', 'true');
                return false;
            }
            if (!tel.TryTel()) {
                v5.error('手机号格式不正确', '1', 'true');
                return false;
            }
            var relVal = GetAjaxString('SendCode', tel);
            v5.error(relVal, '1', 'true');
        }
        function checkChange() {
            if ($('#txtMID').val()=="") {
                v5.error('员工账号不能为空', '1', 'true');
            //} else if (!$('#txtMName').val().TryEN()) {
            //    v5.error('员工姓名只能输入两位以上的中文字符', '1', 'true');
            } else if (!$('#txtTel').val().TryTel()) {
                v5.error('手机号码格式不正确', '1', 'true');
            } else if ($('#txtRole').val() == "") {
                v5.error('职务不能为空', '1', 'true');
                //} else if ($('#txtMTJ').val() == '') {
                //    v5.error('推荐员工帐号不能为空', '1', 'true');
                //} else if ($('#txtMBD').val() == '') {
                //    v5.error('接点员工不能为空', '1', 'true');
            } else if (!$('#txtPassword').val().TryPassword()) {
                v5.error('登录密码不能为空，且必须为6-20位字母或数字组合', '1', 'true');
          
            //} else if ($('#txtAnswer').val() == "") {
            //    v5.error('密保答案用于找回密码，不能为空', '1', 'true');
            //} else if ($('#txtSecPsd').val() != $('#txtSecPsd2').val()) {
            //    v5.error('资金密码与确认资金密码不一样', '1', 'true');
            //} else if ($('#txtPassword').val() == $('#txtSecPsd').val()) {
            //    v5.error('资金密码与登录密码不能相同', '1', 'true');
           
            //} else if ($('#txtTelCode').val() == "") {
            //    v5.error("手机验证码不能为空", '1', 'true');
                //} else if ($('#ddlCity').val() == '地市') {
                //    v5.error('请选择开户地区', '1', 'true');
                //} else if ($('#txtBranch').val() == '') {
                //    v5.error('请输入开户支行', '1', 'true');
                //} else if (!$('#txtBankCardName').val().TryEN()) {
                //    v5.error('员工姓名只能输入两位以上的中文字符', '1', 'true');
                //} else if ($('#txtBankCardName').val() != $('#txtMName').val()) {
                //    v5.error('开户姓名必须与员工姓名一直', '1', 'true');
                //} else if (!$('#txtBankNumber').val().TryBankCard()) {
                //    v5.error('银行卡号只能是16或19位数字', '1', 'true');
                //} else if ($('#txtAnswer').val() == '') {
                //    v5.error('密保答案不能为空', '1', 'true');
            } else {
                if (checkForm()) {
                    $.ajax({
                        type: 'post',
                        url: 'AjaxM/Regedit.ashx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            v5.alert(info, '1', 'true');
                            setTimeout(function () {
                                v5.clearall();
                                //if (info == '注册成功') {
                                //callhtml('Member/UpMemberSJ.aspx?id=' + $("#txtMID").val(), '升级员工');
                                //}
                            }, 1000);
                        }
                    });
                }
            }
        }
    </script>
</body>
</html>
