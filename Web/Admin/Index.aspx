<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="yny_003.Web.Admin.Index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!--	<link rel="Shortcut Icon" href="images/fac.ico" />-->
    <title><%=WebModel.WebTitle %></title>
    <link href="/Admin/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Admin/css/font-awesome.min.css" rel="stylesheet" />
    <link href="/Admin/css/style.css" rel="stylesheet" />
    <link href="/Admin/css/style-responsive.css" rel="stylesheet" />
    <link href="/Admin/css/reset.css" rel="stylesheet" />
    <link href="/Admin/css/main.css" rel="stylesheet" />
    <link href="/Admin/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <%--<script src="/Admin/js/jquery-1.8.3.min.js"></script>--%>
    <script type="text/javascript" src="/Admin/js/jquery-1.11.1.min.js"></script>
    <%--<script src="/Admin/js/jquery-1.9.1.min.js"></script>--%>
    <script src="/Admin/js/jquery-scroll.js"></script>
    <!--pop-->
    <script type="text/javascript" src="/Admin/pop/js/MyValide.js"></script>
   
</head>
<body>
    <div id="container">
        <div class="header white-bg">
            <div class="sidebar-toggle-box">
                <div data-original-title="Toggle Navigation" data-placement="right" class="icon-reorder tooltips"></div>
            </div>
            <a href="#" class="logo">
                <%--<img src="/Admin/images/logo.png" alt="" style="">--%></a>
            <div class="top-nav">
                <ul class="nav pull-right top-menu">
                 
                  
                    <li class="dropdown">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="#"><i class="fa fa-user"></i><span class="username"><%=TModel.MID %></span> <b class="caret"></b></a>
                        <ul class="dropdown-menu extended logout">
                            <%-- <div class="log-arrow-up"></div>--%>
                            <%--<li>
                                <a href="javascript:void(0)" onclick="callhtml('/Member/View.aspx','个人资料');onclickMenu()"><i class=" icon-suitcase"></i>个人信息</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)" onclick="callhtml('/SecurityCenter/ModifyPwd.aspx','登录密码修改');onclickMenu()"><i class="icon-cog"></i>修改密码</a>
                            </li>--%>
                         <%--   <li>
                                <a href="javascript:void(0)" onclick="callhtml('/Member/Structure.aspx','团队图谱');onclickMenu()"><i class="icon-bell-alt"></i>团队管理</a>
                            </li>--%>
                            <li>
                                <a href="/SysManage/out.aspx"><i class="icon-key"></i>安全退出</a>
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="/SysManage/out.aspx" class="username"><i class="fa fa-sign-out"></i>退出</a>
                    </li>
                </ul>
            </div>
        </div>
        <aside>
            <div id="sidebar" class="nav-collapse ">
                <ul class="sidebar-menu">
                    <li class="active">
                        <a data-ripple href="javascript:window.location.reload()" class=""><i class="icon-dashboard"></i><span>首页</span> </a>
                    </li>
                    <%foreach (yny_003.Model.RolePowers item in GetPowers("0"))
                        { %>
                    <li class="sub-menu">
                        <a data-ripple href="javascript:void(0);" class=""><i class="<%=item.Content.CImage %>"></i><span><%=item.Content.CTitle %></span> <span class="arrow"></span></a>
                        <ul class="sub">
                            <%foreach (yny_003.Model.RolePowers item2 in GetPowers(item.CID))
                                { %>
                            <li>
                                <a data-ripple class="" href="javascript:void(0)" onclick="callhtml('<%=item2.Content.CAddress %>','<%=item2.Content.CTitle %>');onclickMenu()"><%=item2.Content.CTitle %></a>
                            </li>
                            <%} %>
                        </ul>

                    </li>
                    <%} %>
                </ul>
            </div>
        </aside>
        <div id="main-content">
            <div class="w1000 min_height row" id="mainContent">
                <div class="col-md-12">
                    <div class="row">
                        <div class="row-fluid">

                            <div class="col-md-2">
                                <a class="info-box blue-bg" >
                                    <div class="leftb"><i class="fa fa-shopping-cart"></i></div>
                                    <div class="rightb">
                                         <div class="count">空车数量</div>
                                    <div class="title">100</div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-2">
                                <a class="info-box green-bg">
                                    <div class="leftb"><i class="fa fa-user"></i></div>
                                    <div class="rightb">
                                         <div class="count">非空车数量</div>
                                    <div class="title">100</div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <a class="info-box jj">
                                <div class="leftb"><i class="icon icon-lightbulb"></i></div>
                                <div class="rightb">
                                     <div class="count">本月违章</div>
                                    <div class="title">100起</div>
                                </div>
                            </a>
                        </div>
                      
                         <div class="col-md-2">
                            <a class="info-box magenta-bg">
                                <div class="leftb"><i class="fa fa-refresh"></i></div>
                                <div class="rightb">
                                    <div class="count">本月总里程</div>
                                    <div class="title">100KM</div>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-2">
                            <a class="info-box jh">
                                <div class="leftb"><i class="fa fa-refresh"></i></div>
                                <div class="rightb">
                                    <div class="count">本月费用</div>
                                    <div class="title">145400</div>
                                </div>
                            </a>
                        </div>

                    <%--    <div class="col-md-2">
                            <a class="info-box jh">
                                <div class="leftb"><i class="icon icon-lightbulb"></i></div>
                                <div class="rightb">
                                    <div class="count">本月总里程</div>
                                    <div class="title">600000KM</div>
                                </div>
                            </a>
                        </div>--%>
                    </div>
                </div>
                <div class="box1 col-md-8">
                    <table width="100%" cellpadding="0" cellspacing="0" class="personinfo">
                        <thead>
                            <tr>
                                <th colspan="2">月份商品销售变化曲线</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <div id="container1" style="height: 353px;" ></div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="box2 col-md-4">
                    <table width="100%" cellpadding="0" cellspacing="0" class="personinfo">
                        <thead>
                            <tr>
                                <th>本月商品各项进货</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <div id="container2" style="height: 353px;"></div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="box1 col-md-8">
                    <table width="100%" cellpadding="0" cellspacing="0" class="personinfo">
                        <thead>
                            <tr>
                                <th colspan="2">我的账户</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>您好，
										<font style="color: #e98001; font-weight: bold;">尊贵的<%=TModel.Role.RName %></font>
                                </td>
                                <td>账号状态：<%=TModel.MState?"正常":"未激活" %></td>

                            </tr>
                         
                        
                        </tbody>
                    </table>
                </div>
                <div class="box2 col-md-4">
                    <table width="100%" cellpadding="0" cellspacing="0" class="personinfo">
                        <thead>
                            <tr>
                                <th colspan="2">系统公告</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <ul class="recent-posts">
                                        <li>
                                      <%--      <p style="color:white;"><%=notice!=null?notice.NContent:"" %></p>--%>
                                        </li>
                                    </ul>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script src="/Admin/js/bootstrap.min.js"></script>
    <script src="/Admin/js/jquery.scrollTo.min.js"></script>
    <script src="/Admin/js/jquery.nicescroll.js"></script>
    <script src="/Admin/js/common-scripts.js"></script>

      <script src="/Admin/js/EPjs.js" type="text/javascript"></script>
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

    <script type="text/javascript" src="Shop/js/shopJs.js"></script>
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
   
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            window.KKKK = K;
        });
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
    <iframe id='frameFile' name='frameFile' style='display: none;'></iframe>
    <script type="text/javascript" src="/admin/js/ajaxForm.js"></script>
    <script type="text/javascript" src="/admin/js/paginationHelper.js"></script>
    <script type="text/javascript" src="/admin/js/jquery.tmpl.js"></script>
    <script type="text/javascript" src="/admin/js/pagination/jquery.twbsPagination.js"></script>
    <script type="text/javascript" src="/admin/pop/js/FileUploader.js"></script>


    <script type="text/javascript" src="https://img.hcharts.cn/highcharts/highcharts.js"></script>
    <script type="text/javascript" src="https://img.hcharts.cn/highcharts/modules/exporting.js"></script>
    <script type="text/javascript" src="https://img.hcharts.cn/highcharts/modules/series-label.js"></script>
    <script type="text/javascript" src="https://img.hcharts.cn/highcharts/modules/oldie.js"></script>
    <script type="text/javascript" src="https://img.hcharts.cn/highcharts-plugins/highcharts-zh_CN.js"></script>
    <script>

        var chart = Highcharts.chart('container1', {
            title: {
                text: ''
            },
            subtitle: {
                text: ''
            },
            yAxis: {
                title: {
                    text: '销售数量'
                }
            },
            
            plotOptions: {
                series: {
                    label: {
                        connectorAllowed: false
                    },
                    pointStart: 2010
                }
            },
            series: [{
                name: '食品',
                data: [43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175]
            }, {
                name: '包装',
                data: [24916, 24064, 29742, 29851, 32490, 30282, 38121, 40434]
            }, {
                name: '水产',
                data: [11744, 17722, 16005, 19771, 20185, 24377, 32147, 39387]
            }, {
                name: '家具',
                data: [null, null, 7988, 12169, 15112, 22452, 34400, 34227]
            }, {
                name: '电子产品',
                data: [12908, 5948, 8105, 11248, 8989, 11816, 18274, 18111]
            }],
            responsive: {
                rules: [{
                    condition: {
                        maxWidth: 500
                    },
                    chartOptions: {
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
                            verticalAlign: 'bottom'
                        }
                    }
                }]
            }
        });
    </script>


    <script>
        $(function () {
            $('#container2').highcharts({
                chart: {
                    type: 'pie',
                    options3d: {
                        enabled: true,
                        alpha: 45,
                        beta: 0
                    }
                },
                title: {
                    text: '本月商品各项进货'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        depth: 35,
                        dataLabels: {
                            enabled: true,
                            format: '{point.name}'
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: '进货占比',
                    data: [
                        ['食品', 45.0],
                        ['包装', 26.8],
                        {
                            name: '水产',
                            y: 12.8,
                            sliced: true,
                            selected: true
                        },
                        ['家具', 8.5],
                        ['电子产品', 6.9]
                    ]
                }]
            });
        });

    </script>
</body>
</html>
