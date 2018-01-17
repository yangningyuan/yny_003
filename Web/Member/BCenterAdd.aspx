<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BCenterAdd.aspx.cs" Inherits="zx270.Web.Member.BCenterAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                        <td width="25%" align="right">会员账号:
                        </td>
                        <td width="35%">
                            <input id="txtMID" runat="server" class="normal_input" type="text" maxlength="20"
                                readonly="readonly" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">会员姓名:
                        </td>
                        <td width="35%">
                            <input id="txtMName" runat="server" class="normal_input" type="text" maxlength="20"
                                readonly="readonly" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">申请类型:
                        </td>
                        <td width="35%">
                            <select id="txtRole" name="txtRole" runat="server">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">地区:
                        </td>
                        <td>
                            <%--<select id="ddlRegion" runat="server">
                            </select>--%>
                            <select id="ddlProvince" runat="server">
                            </select>
                            <select id="ddlCity" runat="server">
                            </select>
                            <select id="ddlZone" runat="server">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">备注:
                        </td>
                        <td width="35%">
                            <span style="color: red;">省级代理只需要选择省,市级代理只需要选择省市,多选无效</span>
                        </td>
                    </tr>
                    <%--<tr>
                    <td width="15%" align="right">
                        上传营业执照:
                    </td>
                    <td width="35%">
                        <input type="button" id="GatheringPic" value="上传营业执照" />
                        <div id='uploadLog'>
                        </div>
                        <input type="hidden" id="hduploadPic1" name="hduploadPic1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                        <div style="float: left" id="tablePic">
                        </div>
                    </td>
                </tr>--%>
                    <tr>
                        <td align="center" colspan="2" class="sen_title">
                            <span id="showmessage" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="sen_title">
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交申请"
                                onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        setup();
        function checkChange() {
            if ($('#txtMID').val().Trim() == "") {
                v5.error('会员账号不能为空', '1', 'true');
            } else if ($('#txtMName').val() == "") {
                v5.error('会员姓名不能为空', '1', 'true');
                //} else if ($('[name="uploadPic"]').length == 0) {
                //    v5.error('请上传营业执照', '1', 'true');
            } else {
                $.ajax({
                    type: 'post',
                    url: 'Member/BCenterAdd.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.alert(info, '1', 'true');
                        setTimeout(function () { v5.clearall(); }, 1000);
                    }
                });
            }
        }
    </script>
</body>
</html>
