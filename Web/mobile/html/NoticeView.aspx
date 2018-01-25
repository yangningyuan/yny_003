<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeView.aspx.cs" Inherits="yny_003.Web.mobile.html.NoticeView" %>

<div class="content Notice pull-to-refresh-content native-scroll infinite-scroll infinite-scroll-bottom" data-distance="55" data-ptr-distance="55" id="index">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
    <div class="content-block-title"></div>
    <div class="list-block myinfo">
            <h4><%=notice.NTitle %></h4>
            <p>

                <%=notice.NContent %>
            </p>
    </div>

  