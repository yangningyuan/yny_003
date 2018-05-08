<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Publish.aspx.cs" Inherits="yny_003.Web.Shop.Publish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var K = window.KKKK;
        var uploadbutton = K.uploadbutton({
            button: K('#GatheringPic')[0],
            fieldName: 'imgFile',
            url: 'plugin/kindeditor/asp.net/upload_json.ashx?dir=image',
            afterUpload: function (data) {
                if (data.error === 0) {
                    var url = K.formatUrl(data.url, 'absolute');
                    K('#hduploadPic1').val(url);
                    K('#uploadLog').html("上传成功");
                    uploadSuccess("上传成功|" + url);
                } else {
                    $('#uploadLog').html(data.message);
                }
            },
            afterError: function (str) {
                alert('自定义错误信息: ' + str);
            }
        });
        uploadbutton.fileBox.change(function (e) {
            uploadbutton.submit();
        });
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1" method="post" action="/Admin/UpLoadPic/IbeaconHandler.ashx" target='frameFile'
            enctype="multipart/form-data">
            <input type="hidden" id="hidDelIds" runat="server" />
            <input type="hidden" id="hidMainPic" runat="server" />
            <input type="hidden" id="hidId" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="8%" align="right">
                        商品分类:
                    </td>
                    <td width="35%">
                        <select id="ddlCategory" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td width="8%" align="right">
                        商品名称:
                    </td>
                    <td width="35%">
                        <input id="txtName" runat="server" class="normal_input" type="text" require-type="require"
                            style="width: 50%" require-msg="商品名称" />
                        <span class="spRed">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        库存
                    </td>
                    <td>
                        <input id="txtPrice" runat="server" class="normal_input" type="text" value="0" require-type="decimal" style="display:none;"
                            require-msg="进价" />
                        <span class="spRed">*</span> &emsp;单位：<input id="txtUnit" runat="server" class="normal_input"
                            type="text" style="width: 50px" require-type="require" require-msg="单位" />
                        <span class="spRed">*</span> &emsp; 库存:
                        <input id="txtStock" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="库存" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        商品描述:
                    </td>
                    <td>
                        <textarea id="txtRemark" runat="server" style="width: 60%; height: 80px"></textarea>&emsp;
                        <input type="button" id="GatheringPic" value="上传图片" />
                        <div id='uploadLog'>
                        </div>
                        <input type="hidden" id="Hidden1" name="hduploadPic1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        图标说明:
                    </td>
                    <td>
                        <img class="xClose" title="删除" src="Admin/pop/images/uploadify-cancel.png" />删除图片;&emsp;
                        <img class="xMain " title="首页图片" src="Admin/pop/images/home_main.png" />列表显示主图片
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <div style="float: left" id="tablePic">
                            <asp:Repeater ID="rep_PicList" runat="server">
                                <ItemTemplate>
                                    <div class="appDiv <%#Eval("IsMain").ToString()=="True"?"mainDiv":"" %>">
                                        <img class="appImg" src="<%#Eval("PicURL") %>" />
                                        <img class="xClose" onclick="deletePic(this)" title="删除" src="Admin/pop/images/uploadify-cancel.png" />
                                        <img class="xMain " onclick="setMain(this)" title="首页图片" src="Admin/pop/images/home_main.png" />
                                        <input type="hidden" name="uploadPic" class="hidPicurl" value="<%#Eval("PicURL") %>" />
                                        <input type="hidden" class='hidId' value="<%#Eval("Id") %>" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td style="text-align: right;">
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

        function deletePic(obj) {
            if (confirm("确定要删除吗？")) {
                var fileName = $(obj).parent().find(".hidPicurl").val();
                var hidId = $(obj).parent().find(".hidId").val();
                var hidDelIds = $("#hidDelIds").val();
                if (typeof (fileName) != "undefined" && fileName != "") {
                    if (typeof (hidId) != "undefined" && hidId != "") {
                        hidDelIds += hidId + ",";
                        $("#hidDelIds").val(hidDelIds);
                    }
                    //如果是把首页图片删除了，就要重新设定首页图片
                    if ($(obj).parent().hasClass("mainDiv")) {
                        $(obj).parent().remove();
                        $(".appDiv").first().addClass("mainDiv");
                        //给首页图片的隐藏控件重新赋值
                        $("#hidMainPic").val($(".appDiv").first().find(".hidPicurl").val());
                    }
                    else {
                        $(obj).parent().remove();
                    }
                }
            }
        }

        function setMain(obj) {
            $(".appDiv").removeClass("mainDiv");
            $(obj).parent().addClass("mainDiv");
            $("#hidMainPic").val($(obj).parent().find(".hidPicurl").val());
        }

        function checkChange() {
            if (checkForm()) {
                if ($("#ddlCategory").val() == "") {
                    v5.alert("请选择商品分类", '1', 'true');
                }
                ActionModel("Shop/Publish.aspx?Action=Modify", $('#form1').serialize());
            }
        }

        function UpLoadPic() {
            $("#fileUp").click();
        }

        function changeform() {
            $("#uploadLog").html("上传中...");
            $('#form1').submit();
        }

        function uploadSuccess(msg) {
            if (msg.split('|').length > 1) {//成功
                $("#uploadLog").html("上传成功...");
                $('#hduploadPic1').val(msg.split('|')[1]);
                var appendHtml = "<div class='appDiv'><img class='appImg' src='" + msg.split('|')[1] + "'/><img class='xClose' onclick='deletePic(this)'  title='删除' src='/Admin/pop/images/uploadify-cancel.png'/><img class='xMain' onclick='setMain(this)'  title='首页展示' src='/Admin/pop/images/home_main.png'/><input type='hidden' name='uploadPic' class='hidPicurl' value='" + msg.split('|')[1] + "'/></div>";
                $("#tablePic").append(appendHtml);

            } else {
                $('#uploadLog').html(msg);
            }
        }
    </script>
</body>
</html>
