<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="geren.aspx.cs" Inherits="yny_003.Web.mobile.html.geren" %>

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
                                    <br />
                                    <li><span>员工类型：<b><%=TModel.Role.RName %></b></span>&nbsp;</li>
                                   <%-- <li><i class="jiangjin"></i><%=yny_003.BLL.Reward.List["MHB"].RewardName %>：<%=TModel.MConfig.MHB %></li>
                                    <li><i class="currentm"></i><%=yny_003.BLL.Reward.List["MJB"].RewardName %>：<%=TModel.MConfig.MJB %></li>--%>
                                    
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
                                <a href="javascript:pcallhtml('/mobile/html/TastList.aspx','我的任务');"><i class="recharge"></i>我的任务</a>
                            </li>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/BXList.aspx','我的报修');"><i class="Withdrawals"></i>我的报修</a>
                            </li>
                        </ul>
                    </div>
                    <div class="list-block myinfo">
                        <ul>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/ModifyPwd.aspx','密码设置');" class="item-link item-content">
                                    <div class="item-inner">
                                        <div class="item-title">密码设置</div>
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
                          <%--  <li>
                                <a href="javascript:pcallhtml('/mobile/html/CW.aspx','财务');" class="item-link item-content">
                                    <div class="item-inner">
                                        <div class="item-title">员工财务</div>
                                    </div>
                                </a>
                            </li>--%>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/GGTZ.aspx','公告通知');" class="item-link item-content">
                                    <div class="item-inner">
                                        <div class="item-title">公告通知</div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript:pcallhtml('/mobile/html/WZList.aspx','违章查询');" class="item-link item-content">
                                    <div class="item-inner">
                                        <div class="item-title">违章查询</div>
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