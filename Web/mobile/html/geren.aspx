﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="geren.aspx.cs" Inherits="yny_003.Web.mobile.html.geren" %>

  <div class="content">
                <img src="/mobile/img/Settingimg.jpg">
                <div class="">
                    <div class="person_info">
                        <div class="row">
                            <div class="col-30"><img src="/mobile/img/women.png"></div>
                            <div class="col-70">
                                <ul class="personlist">
                                    <li><strong><%=TModel.MID %>，您好</strong></li>
                                    <li><label></label><i class="zs"></i><span class="po1"><%=TModel.MAgencyType.MAgencyName %></span></li>
                                    <li><span>团队有效投资额：<b><%=TModel.MConfig.YJMoney %></b></span>&nbsp;</li>
                                    <li><span>会员类型：<b><%=TModel.Role.RName %></b></span>&nbsp;</li>
                                    <li><i class="jiangjin"></i><%=yny_003.BLL.Reward.List["MHB"].RewardName %>：<%=TModel.MConfig.MHB %></li>
                                    <li><i class="currentm"></i><%=yny_003.BLL.Reward.List["MJB"].RewardName %>：<%=TModel.MConfig.MJB %></li>
                                    
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="notice_content ortherbg">
                        <div class="news_panel"><img src="/mobile/img/mynewsn.png"></div>
                        <div class="news mynews">
                            <marquee behavior="scroll" direction="left" scrolldelay="150"><%=noticecontent %></marquee>
                        </div>
                    </div>
                    <div class="in_outmoney">
                        <ul>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/HKList.aspx','汇款管理');"><i class="recharge"></i>充值</a>
                            </li>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/TXList.aspx','提现记录');"><i class="Withdrawals"></i>提现</a>
                            </li>
                        </ul>
                    </div>
                    <div class="list-block myinfo">
                        <ul>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/Pwd.aspx','密码设置');" class="item-link item-content">
                                    <div class="item-inner">
                                        <div class="item-title">安全设置</div>
                                    </div>
                                </a>
                            </li>
                            <!--<li>
                                 <a href="" class="item-link item-content">
                                      <div class="item-inner">
                                           <div class="item-title">购物中心</div>
                                      </div>
                                 </a>
                            </li>-->
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/CW.aspx','财务');" class="item-link item-content">
                                    <div class="item-inner">
                                        <div class="item-title">会员财务</div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/TD.aspx','团队管理');" class="item-link item-content">
                                    <div class="item-inner">
                                        <div class="item-title">团队管理</div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/TZ.aspx','投资中心');" class="item-link item-content">
                                    <div class="item-inner">
                                        <div class="item-title">投资中心</div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/GGTZ.aspx','公告通知');" class="item-link item-content">
                                    <div class="item-inner">
                                        <div class="item-title">公告通知</div>
                                    </div>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div class="exit">
                        <%--<a href="/SysManage/Out.aspx">退出登录</a>--%>
                        <a href="javascript:window.parent.location.href='/SysManage/Out.aspx';">退出登录</a>
                        
                    </div>
                </div>
            </div>