<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BXView.aspx.cs" Inherits="yny_003.Web.mobile.html.BXView" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="bankauto" runat="server" />
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">报修人</div>
                            <div class="item-input">
                                <input type="text" value="<%=TModel.MID%>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
                   <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">报修时间</div>
                            <div class="item-input">
                               <%=bxerror.CreateDate %>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">车辆牌照</div>
                            <div class="item-input">
                               <%=bxerror.CarCode %>
                            </div>
                        </div>
                    </div>
                </li>
               
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">报修类型</div>
                            <div class="item-input">
                                <%=bxerror.EType %>
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">报修说明</div>
                            <div class="item-input">
                                <%=bxerror.EDetails %>
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">报修地址</div>
                            <div class="item-input">
                                <%=bxerror.Address %>
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">拍照</div>
                            <div class="item-input">
                               <img src="<%=bxerror.ImgUrl %>" />
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </form>
    </div>
    
</div>