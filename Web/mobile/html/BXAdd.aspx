<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BXAdd.aspx.cs" Inherits="yny_003.Web.mobile.html.BXAdd" %>
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
            <input type="hidden" id="bankauto" runat="server" />
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">报修人</div>
                            <div class="item-input">
                                <input type="text" value="<%=TModel.MID%>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">车辆牌照</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtPZCode" id="txtPZCode" placeholder="请输入车辆牌照">
                            </div>
                        </div>
                    </div>
                </li>
               
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">报修类型</div>
                            <div class="item-input">
                                <input type="text" value=""  name="txtType" id="txtType" placeholder="请填写报修类型">
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">报修说明</div>
                            <div class="item-input">
                                <input type="text" value=""  name="txtDetails" id="txtDetails" placeholder="请填写报修说明">
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">报修地址</div>
                            <div class="item-input">
                                <input type="text" value=""  name="txtAddress" id="txtAddress" placeholder="请填写报修地址">
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">拍照</div>
                            <div class="item-input">
                                <%--<input type="file" id="imageUrl" name="imageUrl" accept="image/*" capture="camera">--%> 
                                    <input type="file" name="upload" accept="image/*" multiple class="layui-upload-file">
                                <input type="hidden" id="uploadurl" name="uploadurl" runat="server" />
                                <img id="upimage"  height="50px" />

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
<script type="text/javascript">
    function checkChange() {
        if ($('#txtPZCode').val().trim() == "") {
            layer.msg("车辆牌照不能为空");
            return;
        } else {
            ActionModel("mobile/html/BXAdd.aspx?Action=add", $('#form1').serialize(), "mobile/html/BXList.aspx");
        }
    }
</script>