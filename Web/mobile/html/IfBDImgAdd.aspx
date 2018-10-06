<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IfBDImgAdd.aspx.cs" Inherits="yny_003.Web.mobile.html.IfBDImgAdd" %>

<link rel="stylesheet" type="text/css" href="/mobile/font_icons/iconfont.css">
<link rel="stylesheet" href="/mobile/plugin/font-awesome/css/font-awesome.min.css">
<link rel="stylesheet" href="/mobile/plugin/SUI/css/sm.css">
<link rel="stylesheet" href="/mobile/css/main.css">
<link href="/plugin/layui/css/layui.css" rel="stylesheet" />
<link href="/mobile/conn/iconfont/iconfont.css" rel="stylesheet" />
<script src="/mobile/js/jquery-1.11.3.js"></script>
<script src="/mobile/js/stack.js" type="text/javascript"></script>
<script src="/mobile/conn/laydate/laydate.js"></script>
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
                                <%--  <input type="file" name="upload" capture="camera" class="layui-upload-file">
                                <input type="hidden" id="uploadurl" name="uploadurl" runat="server" />
                                <img id="upimage" height="50px" />--%>

                                <input id="fileOne<%=rdstr %>" type="file" capture="camera" class="" style="background-image: url('/mobile/img/_20180922122730.png');">
                                <input id="btnOne" value="上传到服务器" type="button" style="display: none;" />
                                <canvas id="canvasOne" width="1200" height="1200" style="display: none;"></canvas>
                                <input id="DataUrl" type="text" style="display: none;" />
                                <img id="DataImg" src="/mobile/img/_20180922122730.png" style="width: 100px; height: 100px;" />
                                <input type="hidden" id="uploadurl" name="uploadurl" runat="server" />

                                <input runat="server" id="roam" style="display: none;" />

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

<script src="/mobile/js/linkage.js"></script>
<script src="/mobile/js/mobile_services.js" type="text/javascript"></script>
<script src="/Admin/pop/js/MyValide.js" type="text/javascript"></script>
<script src="/mobile/layer/layer.js" type="text/javascript"></script>
<script src="/mobile/js/mobilebone.js" type="text/javascript"></script>
<%--<script src="/mobile/js/main.js"></script>--%>
<script src="/mobile/js/javascript_main.js" type="text/javascript"></script>
<script type="text/javascript" src="/mobile/js/ajax.js"></script>
<script src="/mobile/js/javascript_pop.js" type="text/javascript"></script>
<script src="/mobile/js/jquery.tmpl.js" type="text/javascript"></script>
<script src="/mobile/js/mob_paging.js" type="text/javascript"></script>
<script src="/mobile/js/MobileSelectAll.js" type="text/javascript"></script>
<script src="/mobile/js/jquery.linq.min.js" type="text/javascript"></script>
<script type="text/javascript" src="/plugin/ztree/js/jquery.ztree.core-3.5.js"></script>
<script type="text/javascript" src="/plugin/ztree/ztreeScript.js"></script>
<script type="text/javascript" src="/plugin/kindeditor/kindeditor-min.js"></script>
<script type="text/javascript">
    $(function () {
        var AllLoad;
        $.ajaxSetup({
            cache: false,
            success: function (data) { },
            error: function (xhr, status, e) { },
            complete: function (xhr, status) { layer.close(AllLoad); },
            beforeSend: function (xhr) {
                AllLoad = layer.load(2, { shade: [0] });
            }
        });
    });

    KindEditor.ready(function (K) {
        window.KKKK = K;
    });
</script>
<script src="/plugin/layui/layui.js"></script>
<script>
    //读取本地文件
    var inputOne = document.getElementById('fileOne<%=rdstr%>');
    inputOne.onchange = function () {
        //1.获取选中的文件列表
        var fileList = inputOne.files;
        var file = fileList[0];
        //读取文件内容
        var reader = new FileReader();
        if (file) {
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
        var cxt = c.getContext("2d");
        c.height = c.height;

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

    //将Canvas图片数据上传到服务器
    /*
    * 图片格式说明，存储图片大小 png > jpg> jpeg
    */
    //$('#btnOne').on({
    //    click: function () {
    //        var data = canvas.toDataURL('image/jpeg', 1);
    //        $("#DataUrl").val(data);
    //        document.getElementById("DataImg").src = data;
    //        $.ajax({
    //            type: "POST", //提交方式 
    //            url: "/Admin/UpLoadPic/upload.ashx",//路径 
    //            data: {
    //                "address": data
    //            },//数据，这里使用的是Json格式进行传输 
    //            success: function (result) {//返回数据根据结果进行相应的处理 
    //                if (result.success) {
    //                    $("#tipMsg").text("删除数据成功");
    //                    tree.deleteItem("${org.id}", true);
    //                } else {
    //                    $("#tipMsg").text("删除数据失败");
    //                }
    //            }
    //        });
    //    }
    //});

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

        $.ajax({
            type: "POST", //提交方式 
            url: "/mobile/html/IfBDImgAdd.aspx?Action=add",//路径 
            data: {
                uploadurl: $("#uploadurl").val(),
                cid: $("#cid").val()
            },//数据，这里使用的是Json格式进行传输 
            success: function (result) {//返回数据根据结果进行相应的处理 
                if (result == "上传成功") {
                    window.parent.StackPop();
                    window.parent.StackPop();
                } else {
                    layer.msg('上传有误，请联系管理员');
                }
                
            }
        });


        //ActionModel("mobile/html/IfBDImgAdd.aspx?Action=add", $('#form1').serialize(), "/mobile/html/TastView.aspx?id=" + $("#cid").val());

        //window.parent.StackPop();
        //window.parent.StackPop();
        //pcallhtml('/mobile/html/TastList.aspx', '我的任务');

    }

</script>
