<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="yny_003.Web.Admin.Index" %>

<!DOCTYPE html>
<html>
<head>
    <title><%=WebModel.WebTitle %></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no" />
    <link rel="shortcut icon" href="/Admin/images/favicon.ico" type="image/x-icon" />
    <link href="/Admin/css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="/Admin/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="/Admin/css/flexy-menu.css" rel="stylesheet" type="text/css" media="all" />
    <!-- js -->
    <script src="/Admin/js/jquery-1.11.1.min.js"></script>
    <script src="/Admin/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="/Admin/js/flexy-menu.js"></script>
	
    <script type="text/javascript">
        $(document).ready(function () {
            $(".flexy-menu").flexymenu({
                speed: 400,
                type: "horizontal",
                align: "right"
            });
        });
        function onclickMenu() {
        	var width = $(window).width();
        	if (width <= 768) {
        		var className = document.getElementById("container").style.display;
        		if (className == "block") {
        			$(".showhide").click();
        		}
        	}
        }
    </script>
</head>
<body>
		
    <!-- header -->
    <div class="head1">
        <div class="banner-nav">
            <div class="topleft">
                
            </div>
            <div class="topR">
				<%--<a href="https://tb.53kf.com/code/client/10150595/1 " target="_blank"><img src="Admin/images/online.png" /></a>--%>
               <%=DateTime.Now.ToString("yyyy年MM月dd日") %> <%=System.DateTime.Today.ToString("dddd", new System.Globalization.CultureInfo("zh-CN")) %>
            </div>
        </div>
    </div>
    <div class="header">
        <div class="banner-navigation">
            <div class="banner-nav">
                <div class="logo">
                    <%--<img src="/Admin/images/logo.png">--%>
                </div>
                <ul class="flexy-menu orange nav1">
                    <li class="hvr-sweep-to-bottom">
                        <a href="javascript:location.reload()">首页</a><em>&nbsp;|</em>
                    </li>

                    <%
                        foreach (yny_003.Model.RolePowers item in GetPowers("0"))
                        {
                    %>
                    <li class="hvr-sweep-to-bottom">
                        <a href="javascript:void(0)"><%=item.Content.CTitle %>
                        </a><em>&nbsp;|</em>
                        <ul>
                            <%foreach (yny_003.Model.RolePowers item2 in GetPowers(item.CID))
                                {
                                    if (item2.Content.IsOuterLink)
                                    {
                            %>
                            <li><a href="<%=item2.Content.CAddress %>" target="_blank"><%=item2.Content.CTitle%></a></li>
                            <%
                                }
                                else
                                {
                            %>
                            <li><a href="javascript:callhtml('<%=item2.Content.CAddress %>','<%=item2.Content.CTitle %>');"onclick="onclickMenu()"><%=item2.Content.CTitle%></a></li>
                            <%
                                    }
                                } %>
                        </ul>
                    </li>
                    <%} %>


                    <li class="hvr-sweep-to-bottom">
                        <a href="/SysManage/Out.aspx">安全退出</a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <div class="gao">
        <div class="notice">
            <div class="news" style="margin-left: 40px;">
                <marquee direction="top" scrollamount="6" behavior="scroll" onmouseover="this.stop()" onmouseout="this.start()">
                    <%=notice==null?"":notice.NContent %>
                </marquee>
            </div>
        </div>
    </div>
    <div>
        <div class="banner">
            <%--<img src="/Admin/images/banner03.jpg">--%>
            <!--<div class="imgsilder">
                <div class="banner_Carousel">
                    <div class="carousel slide" data-ride="carousel" id="carousel3">
                        <ol class="carousel-indicators">
                            <li data-target="#carousel3" data-slide-to="0" class="active"></li>
                            <li data-target="#carousel3" data-slide-to="1"></li>
                            <li data-target="#carousel3" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner">
                            <div class="item active">
                                <img src="images/banner02.jpg">
                            </div>
                            <div class="item">
                                <img src="images/banner.jpg">
                            </div>
                            <div class="item">
                                <img src="images/banner03.jpg">
                            </div>
                        </div>
                    </div>
                </div>
            </div>-->
        </div>
			
        <div class="banner-bottom">
            <div class="container"  id="main-content">
                <div class="w1000">
				
                    <div class="row-fluid">
                        <div class="col-md-3">
                            <a class="info-box red-bg" href="javascript:callhtml('/OJ/ObjList.aspx','项目管理');onclickMenu()">
                                <i class="gold">
                                    <img src="/Admin/images/jf.png"></i>
                                <!--<div class="count">0.00</div>-->
                                <div class="title">项目管理 </div>
                            </a>
                        </div>
                        <div class="col-md-3">
                            <a class="info-box green-bg" href="javascript:callhtml('/OJ/ObjSubTypeList.aspx','子类类别管理');onclickMenu()">
                                <i class="gold">
                                    <img src="/Admin/images/hl.png"></i>
                                <!--<div class="count">0.00</div>-->
                                <div class="title">子类类别管理 </div>
                            </a>
                        </div>
                        <div class="col-md-3">
                            <a class="info-box blue-bg" href="javascript:callhtml('/OJ/FundTypeList.aspx','费用支出维护');onclickMenu()">
                                <i class="gold">
                                    <img src="/Admin/images/xj.png"></i>
                                <!--<div class="count">0.00</div>-->
                                <div class="title">费用支出维护 </div>
                            </a>
                        </div>
                        <div class="col-md-3">
                            <a class="info-box magenta-bg" href="javascript:callhtml('/OJ/DepartTypeList.aspx','批复部门管理');onclickMenu()">
                                <i class="gold">
                                    <img src="/Admin/images/wjb.png"></i>
                                <!--<div class="count">0.00</div>-->
                                <div class="title">批复部门管理</div>
                            </a>
                        </div>
                    </div>
                </div>
             
                
            </div>
        </div>
    </div>
    <div class="footer"><%=WebModel.WebTitle %>系统-版权所有京ICP备09047137号 </div>


    <link rel="stylesheet" type="text/css" href="Admin/pop/css/pop.css" />
    <link rel="stylesheet" type="text/css" href="Admin/pop/css/V5-UI.css" />
    <link rel="stylesheet" type="text/css" href="Admin/pop/css/next_page_search.css" />
    <link rel="stylesheet" type="text/css" href="plugin/layer/skin/layer.css" />
    <link rel="stylesheet" type="text/css" href="plugin/kindeditor/themes/default/default.css" />
    <script type="text/javascript" src="plugin/layer/layer.js"></script>
    <script type="text/javascript" src="Admin/pop/js/MyValide.js"></script>
    <script type="text/javascript" src="Admin/pop/js/TableToExcel.js"></script>
    <script type="text/javascript" src="Admin/pop/js/linkage.js"></script>

    <link href="/plugin/layui/css/layui.css" rel="stylesheet" />
        <script src="/plugin/layui/layui.js"></script>

    <%--<script type="text/javascript" src="Shop/js/shopJs.js"></script>--%>
    <%--<script type="text/javascript" src="Module/Investment/js/invest.js"></script>--%>
    <script type="text/javascript" src="Admin/pop/js/javascript_main.js"></script>
    <script type="text/javascript" src="Admin/pop/js/ajax.js"></script>
    <script type="text/javascript" src="Admin/pop/js/javascript_pop.js"></script>
    <script type="text/javascript" src="Admin/pop/js/V5-UI.js"></script>
    <script type="text/javascript" src="Admin/pop/js/jquery.pagination.js" charset="gbk"></script>
    <script type="text/javascript" src="plugin/date/WdatePicker.js"></script>
    <script type="text/javascript" src="plugin/ZeroClipboard/ZeroClipboard.js"></script>
    <script type="text/javascript" src="plugin/kindeditor/kindeditor-min.js"></script>
    <script src="/Admin/pop/js/jquery.qrcode.min.js"></script>
    <!-- 数据库定时备份 -->
    <%-- <script src="admin/js/ajaxForm.js" type="text/javascript"></script>
    <script src="admin/js/paginationHelper.js" type="text/javascript"></script>
    <script src="admin/js/jquery.tmpl.js" type="text/javascript"></script>
    <script src="admin/js/pagination/jquery.twbsPagination.js" type="text/javascript"></script>--%>
    <!-- 数据库定时备份 -->
    <script type="text/javascript">
        //二维码
        function toUtf8(str) {
            var out, i, len, c;
            out = "";
            len = str.length;
            for (i = 0; i < len; i++) {
                c = str.charCodeAt(i);
                if ((c >= 0x0001) && (c <= 0x007F)) {
                    out += str.charAt(i);
                } else if (c > 0x07FF) {
                    out += String.fromCharCode(0xE0 | ((c >> 12) & 0x0F));
                    out += String.fromCharCode(0x80 | ((c >> 6) & 0x3F));
                    out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
                } else {
                    out += String.fromCharCode(0xC0 | ((c >> 6) & 0x1F));
                    out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
                }
            }
            return out;
        }

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

            var clip = new ZeroClipboard(document.getElementById("fenxian"), {
                moviePath: "plugin/ZeroClipboard/ZeroClipboard.swf"
            });
            // 复制内容到剪贴板成功后的操作 
            clip.on('complete', function (client, args) {
                layer.alert('复制成功！', {
                    skin: 'layer-ext-moon',
                    btn: '确定',
                    yes: function (index, layero) {
                        layer.close(index);
                    }
                });
            });
        });

        KindEditor.ready(function (K) {
            window.KKKK = K;
        });
    </script>
    <script type="text/javascript">
        function onclickMenu() {
            var width = $(window).width();
            if (width <= 768) {
                var className = document.getElementById("container").className;
                if (className == "") {
                    $(".tooltips").click();
                }
            }
        }
    </script>

</body>
</html>
