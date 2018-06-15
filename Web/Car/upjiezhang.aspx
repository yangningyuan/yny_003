<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upjiezhang.aspx.cs" Inherits="yny_003.Web.Car.upjiezhang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
     <link href="/Admin/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Admin/css/font-awesome.min.css" rel="stylesheet" />
    <link href="/Admin/css/style.css" rel="stylesheet" />
    <link href="/Admin/css/style-responsive.css" rel="stylesheet" />
    <link href="/Admin/css/reset.css" rel="stylesheet" />
    <link href="/Admin/css/main.css" rel="stylesheet" />
    <link href="/Admin/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <%--<script src="/Admin/js/jquery-1.8.3.min.js"></script>--%>
    <script type="text/javascript" src="/Admin/js/jquery-1.11.1.min.js"></script>
</head>
<body  style="background:url();">
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" class="tabcolor table table-bordered table-hover" id="Result" style="background-color: rgb(252, 252, 252);">
                <tbody>
                    <tr>
                     
                        <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">序号
                        </th>

                        <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">任务编号
                        </th>
                        <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">供应商名称
                        </th>
                        <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">应付总金额
                        </th>
                        <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">已付金额
                        </th>
                        <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">状态
                        </th>
                        <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">发票状态
                        </th>
                        <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">任务时间
                        </th>
                        <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">结账时间
                        </th>
                       
                    </tr>
                    <tr onclick="trClick(this)">
                       
                        <td>1&nbsp;</td>
                        <td>20180603223718912&nbsp;</td>
                        <td>新乡天冠二氧化碳有限公司&nbsp;</td>
                        <td>44000.00&nbsp;</td>
                        <td>44000.00&nbsp;</td>
                        <td>已结账&nbsp;</td>
                        <td><span style="color: green;">已开发票</span>&nbsp;</td>
                        <td>2018/6/3 22:51:34&nbsp;</td>
                        <td>2018/6/3 23:32:29&nbsp;</td>
                       
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
