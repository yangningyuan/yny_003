<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TastView.aspx.cs" Inherits="yny_003.Web.mobile.html.TastView" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="bankauto" runat="server" />
            <ul>
                <!-- Text inputs -->
                 <li>
                    <div class="item-content" style="background-color:powderblue">
                        <div class="item-inner">
                            <div class="item-title label">任务详情</div>
                            <div class="item-input">
                               
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">任务名称</div>
                            <div class="item-input">
                                <%=cartast.Name%>【<%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","空车") %>】
                            </div>
                        </div>
                    </div>
                </li>
                
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">供应商或客户</div>
                            <div class="item-input">
                                <%=cartast.SupplierName %><br /><span style="color:green">【联系人：<%=cartast.SupplierTelName %>，联系方式：<%=cartast.SupplierTel %>】</span>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">地址</div>
                            <div class="item-input">
                                <%=cartast.SupplierAddress %>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">主司机</div>
                            <div class="item-input">
                                <input type="text" value="<%=cartast.CarSJ1%>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">副司机</div>
                            <div class="item-input">
                                <input type="text" value="<%=cartast.CarSJ2%>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
              

                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">派遣车辆</div>
                            <div class="item-input">
                                <%=cartast.Spare2 %>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">费用类型</div>
                            <div class="item-input">
                                <%=yny_003.BLL.C_CostType.GetModel( cartast.CostType ).Name%>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">磅单图片</div>
                            <div class="item-input">
                                <img src="<%=cartast.BDImg %>" />
                            </div>
                        </div>
                    </div>
                </li>

                  <li>
                    <div class="item-content" style="background-color:powderblue">
                        <div class="item-inner">
                            <div class="item-title label">商品详情</div>
                            <div class="item-input">
                               
                            </div>
                        </div>
                    </div>
                </li>
                   <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">派遣车辆</div>
                            <div class="item-input">
                                <%=cartast.Spare2 %>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </form>
    </div>

</div>
