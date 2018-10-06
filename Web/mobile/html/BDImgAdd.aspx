<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BDImgAdd.aspx.cs" Inherits="yny_003.Web.mobile.html.BDImgAdd" %>

<iframe  style="width:100%;height:100%;" src="/mobile/html/IfBDImgAdd.aspx?id=<%=cartast.ID %>"></iframe>

<%--<script>
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
                              
                                
                                <input id="fileOne<%=rdstr %>" type="file" capture="camera" class="layui-upload-file" />
                                <input id="btnOne" value="上传到服务器" type="button" style="display: none;" />
                                <canvas id="canvasOne" width="1200" height="1200" style="display: none;"></canvas>
                                <input id="DataUrl" type="text" style="display: none;" />
                                <img id="DataImg" src="" style="width: 100px; height: 100px;" />
                                <input type="hidden" id="uploadurl" name="uploadurl" runat="server" />

                                <input runat="server" id="roam" />

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
<script>
    //读取本地文件
    var inputOne = document.getElementById('fileOne<%=rdstr%>');
    inputOne.onchange = function () {
        //1.获取选中的文件列表
        var fileList = inputOne.files;
        var file = fileList[0];
        //读取文件内容
        var reader = new FileReader();
        if (file)
        {
            reader.readAsDataURL(file);
        }
        reader.onload = function (e) {
            //将结果显示到canvas
            showCanvas(reader.result);
        }
    }
    var canvas = document.getElementById('canvasOne');
    var ctx = canvas.getContext('2d');
    //指定图片内容显示
    function showCanvas(dataUrl) {
        //$("#DataUrl").val(dataUrl);

        var c = document.getElementById("canvasOne");
        var cxt=c.getContext("2d");  
        c.height=c.height;  

        //加载图片
        var img = new Image();
        img.onload = function () {
            //缩小图片
            ctx.scale(0.4, 0.4);
            ctx.drawImage(img, 0, 0, img.width, img.height);
        }
        img.src = dataUrl;
        setTimeout(function () {
            upLoad();
        }, 300);

    }

    function upLoad() {
        var data = canvas.toDataURL('image/jpeg', 1);
        $("#DataUrl").val(data);
        document.getElementById("DataImg").src = data;
        $.ajax({
            type: "POST", //提交方式 
            url: "/Admin/UpLoadPic/upload.ashx",//路径 
            data: {
                "address": data
            },//数据，这里使用的是Json格式进行传输 
            success: function (result) {//返回数据根据结果进行相应的处理 
                $("#uploadurl").val(result);
            }
        });
    }
</script>

<script type="text/javascript">
    function checkChange() {
       
        {
            ActionModel("mobile/html/BDImgAdd.aspx?Action=add", $('#form1').serialize(), "/mobile/html/TastView.aspx?id=" + $("#cid").val());
        }
    }
</script>--%>
