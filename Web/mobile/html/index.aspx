﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="yny_003.Web.mobile.html.index" %>

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

    <script src="/mobile/js/jquery-1.11.3.js"></script>
    <script src="/mobile/js/stack.js" type="text/javascript"></script>
    <script src="/mobile/conn/laydate/laydate.js"></script>
		<%--<script language="JavaScript" src="http://code.54kefu.net/kefu/js/b38/1031638.js" type="text/javascript" charset="utf-8"></script>--%>
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
                  <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/ShopMenu.aspx','购物区');">
                    <span class="icon icon-gift"></span>
                    <span class="tab-label">购物区</span>
                </a>
                <a class="tab-item"  href="javascript:void(0)" onclick="pcallhtml('/mobile/html/TastList.aspx','我的任务');">
                    <span class="icon icon-me"></span>
                    <span class="tab-label">我的任务</span>
                </a>
            </nav>
            <div class="content native-scroll" id="pageHome">
                <div class="row">
                    <div>
                        <img src="/mobile/img/banner.png" />
                    </div>
                </div>
                <div class="notice_content">
                    <div class="news_panel">
                        <img src="/mobile/img/newsicon.png"></div>
                    <div class="news">
                        <marquee behavior="scroll" direction="left" scrolldelay="150"><%=noticecontent %></marquee>
                    </div>
                </div>
                <div class="qicon"><span>快捷图标</span></div>
                <div class="row margin-top-buttom">
                      <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/TastList.aspx','我的任务');">
                            我的任务
                        </a>
                    </div>
                    <div class="col-25 row-tab">
                        <a class="tab-item" href="javascript:void(0)" onclick="pcallhtml('/mobile/html/JKList.aspx','借款管理');">
                            借款管理
                        </a>
                    </div>
                  
                    <div class="col-25 row-tab">
                        <a class="tab-item"  href="javascript:void(0)" onclick="javascript:pcallhtml('/mobile/html/GGTZ.aspx','公告通知');">
                           公告查询
                        </a>
                    </div>
                   <div class="col-25 row-tab">
                        <a class="tab-item"  href="javascript:void(0)" onclick="javascript:pcallhtml('/mobile/html/WZList.aspx','违章查询');">
                           违章查询
                        </a>
                    </div>
                    <div class="col-25 row-tab">
                        <a class="tab-item"  href="javascript:void(0)" onclick="javascript:pcallhtml('/mobile/html/BXList.aspx','报修查询');">
                           报修查询
                        </a>
                    </div>
                </div>
                <div class="qicon"><span>关于我们</span></div>
                <div class="row margin-top-buttom aboutus">
                    <div class="atcion content-padded">
                        <img src="/mobile/img/aboutus.png"></div>
                   <%-- <div class="aboutustxt">
                        <p class=" content-padded">
                            云数贸集团公司它是一个互联网企业。目标是2-8亿会员！ 云数贸是中国第一个以股份制形式加入互联网.并分享互联网 利益的混合体经济企业。
								 目前在短短两年的时间里，已经有了几千万会员，而且市 场已经开拓到了东南亚的缅甸（目前已经成立分公司）、马 来西亚、新加坡，最近又把市场拓展到了小日本！ 
						
                        </p>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
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
        $(function(){
            var isnotice= <%=isnotice%>;
            if(isnotice=="1")
            {
                layer.confirm('是否要进入安全教育栏目学习？', {
                    btn : [ '是', '否' ]//按钮
                }, function(index) {
                    layer.close(index);
                    //此处请求后台程序，下方是成功后的前台处理……
                    //var index = layer.load(0,{shade: [0.7, '#393D49']}, {shadeClose: true}); //0代表加载的风格，支持0-2
                    pcallhtml('/mobile/html/NoticeView.aspx?id=<%=notice.ID%>','查看公告');
                }); 
            }
        });
        
            
    </script>
</body>

</html>
