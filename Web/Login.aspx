<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="yny_003.Web.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Page title -->
    <title><%=WebModel.WebTitle %></title>
    <link rel="stylesheet" href="/Admin/login/css/bootstrap.css">
    <link rel="stylesheet" href="/Admin/login/css/style1.css">
    <script type="text/javascript" src="/Admin/login/js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="login/js/bootstrap.min.js"></script>
    <link href="plugin/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="plugin/layer/layer.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Admin/pop/css/V5-UI.css" />
    
    
    <script type="text/javascript" src="Admin/pop/js/javascript_main.js"></script>
    <script type="text/javascript" src="Admin/pop/js/ajax.js"></script>
    <script type="text/javascript" src="Admin/pop/js/javascript_pop.js"></script>
    <script type="text/javascript" src="Admin/pop/js/V5-UI.js"></script>
    <script type="text/javascript" src="Admin/pop/js/uaredirect.js"></script>
    <script type="text/javascript">        uaredirect("/mobile/html/Login.aspx");</script>
    <script>
        $(function () {
            window.location.href = "/mobile/html/login.aspx";
        });
    </script>
    <!--<script type="text/javascript">
        var defaultKye = "";
        var GB2312Str = "<%=zhNames %>";
        var BIG5Str = "<%=enNames %>";
        var GBStr = GB2312Str.split('*');
        var BIGStr = BIG5Str.split('*');
    </script>
    <script src="Admin/pop/js/LanguageConvert.js" type="text/javascript"></script>-->
    <script type="text/javascript">
        function Login() {
            if ($("#txtname").val() == "") {
                v5.error('用户名不能为空', '1', 'true');
            } else if (pwd = $("#txtpwd").val() == "") {
                v5.error('密码不能为空', '1', 'true');
            } else {
                $.ajax({
                    type: "post",
                    url: "Login.aspx?type=login",
                    data: {
                        txtname: $("#txtname").val(), txtpwd: $("#txtpwd").val(), checkCode: $("#checkCode").val(), href: window.location.href
                    },
                    async: true,
                    success: function (data) {
                        switch (data) {
                            case "1":
                                v5.error('用户名不存在', '1', 'true');
                                break;
                            case "2":
                                v5.error('密码不正确', '1', 'true');
                                break;
                            case "3":
                                v5.error('验证码错误', '1', 'true');
                                $("#imgcode").click();
                                break;
                            case "-1":
                                v5.error('限制登录', '1', 'true');
                                break;
                            case "0":
                                window.location.href = "/Default.aspx?type=pc";
                                break;
                            default:
                                if (data)
                                    v5.error(data, '1', 'true');
                                break;
                        }
                    }
                })
            }
            return false;
        }
        function keyLogin() {
            if (event.keyCode == 13)   //回车键的键值为13   
                Login();
        }
        function reset() {
            $("#txtname").val("");
            $("#txtpwd").val("");
        }
        $(function () {
            if (!placeholderSupport()) {   // 判断浏览器是否支持 placeholder
                $('[placeholder]').focus(function () {
                    var input = $(this);
                    if (input.val() == input.attr('placeholder')) {
                        input.val('');
                        input.removeClass('placeholder');
                    }
                }).blur(function () {
                    var input = $(this);
                    if (input.val() == '' || input.val() == input.attr('placeholder')) {
                        input.addClass('placeholder');
                        input.val(input.attr('placeholder'));
                    }
                }).blur();
            };
        })
        function placeholderSupport() {
            return 'placeholder' in document.createElement('input');
        }
    </script>

    <style>
        html,
        body {
            width: 100%;
            height: 100%;
            /*background: url(/Admin/login/images/background.jpg) no-repeat;*/
            background-size: cover;
        }
    </style>
</head>
<body onkeydown="keyLogin();">

<a  key ="5983ea8f2548be1170d3695c"  logo_size="124x47"  logo_type="business"  href="http://www.anquan.org 

 

" ><script src="//static.anquan.org/static/outer/js/aq_auth.js 

 

"></script></a>
    <div class="login-container">
        <div class="row">
            <div class="col-md-12">
                <div class="text-center m-b-md">
                </div>
                <div class="hpanel" style="opacity: 0.96;">
                    <span class="welcome"><img src="Admin/login/images/logo.png"> </span><br>
                    <div class="panel-body">
                        <form method="post" name="login" id="form1">
                            <div class="form-group">
                                <label class="control-label" for="username">用户名</label>
                                <input type="text" placeholder="请输入用户名"  id="txtname" name="username"  class="form-control">
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="password">密码</label>
                                <input type="password" placeholder="请输入密码"  id="txtpwd" name="password"  class="form-control">
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="password">验证码</label>
                                <div style="overflow:hidden;">
                                    <input type="text" placeholder="请输入验证码"  id="checkCode" name="checkCode" class="form-control" style=" width:50%; float left;">
                                    <img src="CheckCode.aspx" onclick="this.src='CheckCode.aspx?'+Math.random()" style=" float:left; margin-left:5%; width:86; height:34px;">
                                </div>
                            </div>
                            <button class="btn btn-success btn-block loginbg" type="button"  onclick="Login()">登录</button>
                            <a href="SecurityCenter/FindPwd.aspx" style=" display:block; float:left;margin-left:20px; margin-top:18px;">忘记密码？</a>
                            <!--	<a style=" display:block; float:left; margin-top:18px; margin-left:20px;" href="#">没有帐号？立即注册</a>-->
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center" style="color:#EDEDED;"> <strong><%=WebModel.WebTitle %></strong> All Right Reserved </div>
        </div>
    </div>
</body>
</html>