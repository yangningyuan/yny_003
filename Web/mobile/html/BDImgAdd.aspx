<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BDImgAdd.aspx.cs" Inherits="yny_003.Web.mobile.html.BDImgAdd" %>

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
            <input type="hidden" id="cid" runat="server" />
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content" style="background-color: powderblue">
                        <div class="item-inner">
                            <div class="item-title label">任务详情</div>
                            <div class="item-input">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">任务名称</div>
                            <div class="item-input">
                                <%=cartast.Name%>【<%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","空车") %>】
                            </div>
                        </div>
                    </div>
                </li>

               
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">上传磅单图片</div>
                            <div class="item-input">
                                <input type="file" name="upload" capture="camera" class="layui-upload-file">
                                <input type="hidden" id="uploadurl" name="uploadurl" runat="server" />
                                <img id="upimage" height="50px" />
                            </div>
                        </div>
                    </div>
                </li>
                <div class="content-block">
                    <div class="row">
                        <div class="col-100">
                            <a href="javascript:checkChange();" class="button button-big button-fill button-success">提交</a>
                        </div>
                    </div>
                </div>
            </ul>
        </form>
    </div>

</div>
<script type="text/javascript">
    function checkChange() {
        //if ($('#txtMHB').val().trim() == "") {
        //    layer.msg("费用金额不能为空");
        //    return;
        //} else
        {
            ActionModel("mobile/html/BDImgAdd.aspx?Action=add", $('#form1').serialize(), "/mobile/html/TastView.aspx?id=" + $("#cid").val());
        }
    }
</script>
