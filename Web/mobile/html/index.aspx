<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="yny_003.Web.mobile.html.index" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title><%=WebModel.WebTitle %></title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <%--   <link rel="shortcut icon"  href="../../Admin/images/fac.ico">--%>
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="stylesheet" type="text/css" href="/mobile/font_icons/iconfont.css">
    <link rel="stylesheet" href="/mobile/plugin/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="/mobile/plugin/SUI/css/sm.css">
    <link rel="stylesheet" href="/mobile/css/main.css">
    <link href="/plugin/layui/css/layui.css" rel="stylesheet" />
    <link href="/mobile/conn/iconfont/iconfont.css" rel="stylesheet" />
    <script src="/mobile/js/jquery-1.11.3.js"></script>
    <script src="/mobile/js/stack.js" type="text/javascript"></script>
    <script src="/mobile/conn/laydate/laydate.js"></script>

</head>

<body>
    <div class="page-group">
        <div class="page page-current" id="index">
            <header class="bar bar-nav">
                <a class="icon icon-left pull-left back" href="javascript:StackPop()"></a>
                <a class="icon icon-home pull-right" href="javascript:window.location.reload();"></a>

                <h1 class="title"><%=WebModel.WebTitle %></h1>
            </header>
            <nav class="bar bar-tab">
                <a class="tab-item active" href="javascript:window.location.reload();">
                    <span class="icon icon-home"></span>
                    <span class="tab-label">首页</span>
                </a>
                <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/TastList.aspx','我的任务');">
                    <span class="icon icon-app"></span>
                    <span class="tab-label">我的任务</span>
                </a>
                <%--     <a class="tab-item user-img-btn external" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/Code.aspx','二维码注册');">
                    <img src="/mobile/img/userbtn.png" />
                </a>--%>
                <%-- <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/TJTree.aspx','推荐图谱');">
                    <span class="icon icon-share"></span>
                    <span class="tab-label">图谱</span>
                </a>--%>
                <%--  <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/TastList.aspx','我的任务');">
                    <span class="icon icon-gift"></span>
                    <span class="tab-label">我的任务</span>
                </a>--%>
                <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/geren.aspx','个人中心');">
                    <span class="icon icon-me"></span>
                    <span class="tab-label">个人中心</span>
                </a>
            </nav>
            <div class="content native-scroll" id="pageHome">
                <%--<div class="qicon"><span>关于我们</span></div>--%>
                <div class="row margin-top-buttom aboutus">
                    <div class="atcion content-padded">
                        <img src="/mobile/img/aboutus.png">
                    </div>

                </div>
                <%--<div class="row">
                    <div>
                        <img src="/mobile/img/banner.png" />
                    </div>
                </div>--%>
               <%-- <div class="notice_content">
                    <div class="news_panel">
                        <img src="/mobile/img/newsicon.png">
                    </div>
                    <div class="news">
                        <marquee behavior="scroll" direction="left" scrolldelay="150"><%=noticecontent %></marquee>
                    </div>
                </div>--%>
                <div class="qicon"><span>快捷图标</span></div>
                <div class="row margin-top-buttom">

                    <%
                        if (TModel.Role.SiJi)
                        {
                    %>
                      <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/TastList.aspx','我的任务');">
                            <i class="iconfont">&#xe653;</i>
                            我的任务
                        </a>
                    </div>
                    <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/JKList.aspx','借款管理');">
                            <i class="iconfont">&#xe61e;</i>
                            借款管理
                        </a>
                    </div>

                   
                    <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="javascript:pcallhtml('/mobile/html/WZList.aspx','违章查询');">
                            <i class="iconfont">&#xe662;</i>
                            违章查询
                        </a>
                    </div>
                    <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="javascript:pcallhtml('/mobile/html/CostList.aspx','费用列表');">
                            <i class="iconfont">&#xe65e;</i>
                            费用列表
                        </a>
                    </div>

                    <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="javascript:pcallhtml('/mobile/html/VerCar.aspx','确认车辆');">
                            <i class="iconfont">&#xe653;</i>
                            确认车辆
                        </a>
                    </div>
                    <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="javascript:pcallhtml('/mobile/html/DelCar.aspx','我要交车');">
                            <i class="iconfont">&#xe61e;</i>
                            我要交车
                        </a>
                    </div>
                    <%
                        }
                        else if (TModel.Role.XiaoShou)
                        {
                    %>
                     <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/XSTastList.aspx','我的待办');">
                            <i class="iconfont">&#xe653;</i>
                            我的待办
                        </a>
                    </div>
                  <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/XSTastAdd.aspx','添加任务');">
                            <i class="iconfont">&#xe61f;</i>
                            添加任务
                        </a>
                    </div>
                    <%
                        }
                        else {
                            %>
                                <div class="col-25 row-tab">
                                    <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/DDTastList.aspx','待调度');">
                                        <i class="iconfont">&#xe653;</i>
                                        待调度
                                    </a>
                                </div>
                     <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/DDTastAdd.aspx','添加任务');">
                            <i class="iconfont">&#xe61f;</i>
                            添加任务
                        </a>
                    </div>
                      <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/CarList.aspx','查看车辆');">
                            <i class="iconfont">&#xe625;</i>
                            查看车辆
                        </a>
                    </div>
                     <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/CarYJ.aspx','车辆预警');">
                            <i class="iconfont">&#xe605;</i>
                            车辆预警
                        </a>
                    </div>
                            <%
                        }
                    %>
                   <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="javascript:pcallhtml('/mobile/html/GGTZ.aspx','公告通知');">
                            <i class="iconfont">&#xe600;</i>
                            公告查询
                        </a>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <input type="hidden" id="isnotice2" runat="server" />
    <input type="hidden" id="noticeid3" runat="server" />
    <%--<script src="/mobile/plugin/SUI/js/zepto.js"></script>--%>
    <%--<script type='text/javascript' src='/mobile/plugin/SUI/js/sm.js' charset='utf-8'></script>--%>
    <%--<script type='text/javascript' src='/mobile/plugin/SUI/js/sm-city-picker.js' charset='utf-8'></script>--%>
    <%--<script type='text/javascript' src='/mobile/js/main.js' charset='utf-8'></script>--%>



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
    <%--<script src="/Admin/js/jquery.qrcode.min.js"></script>--%>

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
        setTimeout(function(){
            var isnotice2= $("#isnotice2").val().trim();
          
            if(isnotice2=="1")
            {
                var isnotice= <%=isnotice%>;
                layer.confirm('是否要进入安全教育栏目学习？', {
                    btn : [ '是', '否' ]//按钮
                }, function(index) {
                    layer.close(index);
                    pcallhtml('/mobile/html/NoticeView.aspx?id='+$("#noticeid3").val(),'查看公告');
                }); 
            }
        },500);
     
    </script>
</body>

</html>
