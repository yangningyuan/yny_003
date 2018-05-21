<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TastView.aspx.cs" Inherits="yny_003.Web.mobile.html.TastView" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="bankauto" runat="server" />
            <input type="hidden" id="cid" runat="server" />
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content" style="background-color: powderblue">
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
                               <span style="color:red; font-size:10px;">【<%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","空车") %>】 <%=cartast.Name%></span>
                            </div>
                        </div>
                    </div>
                </li>

                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">供应商或客户</div>
                            <div class="item-input">
                                <%=supplier!=null?supplier.Name:"" %><br />
                                <div style="color: red; width:100%; font-size:10px;">【联系人：<%=cartast.SupplierTelName %>】<br />【联系方式：<%=cartast.SupplierTel %>】</div>
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
                                <input type="text" value="<%=zhusiji%>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">副司机</div>
                            <div class="item-input">
                                <input type="text" value="<%=fusiji%>" disabled="disabled">
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
                            <div class="item-title label"><%=cartast.TType.ToString().Replace("1","实际装车时间").Replace("2","调度派遣车辆时间") %></div>
                            <div class="item-input">
                                <%=cartast.ComDate %>
                            </div>
                        </div>
                    </div>
                </li>
               <%-- <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">费用类型</div>
                            <div class="item-input">
                                <%=yny_003.BLL.C_CostType.GetModel( cartast.CostType ).Name%>
                            </div>
                        </div>
                    </div>
                </li>
             --%>
                 <li>
                    <div class="item-content" style="background-color: powderblue">
                        <div class="item-inner">
                            <div class="item-title label"><%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","空车") %>商品详情</div>
                            <div class="item-input">
                            </div>
                             <div class="item-input"><a class="button" style="float:right;" href="javascript:pcallhtml('/mobile/html/BDImgAdd.aspx?id=<%=cartast.ID %>','上传磅单图片');">上传</a></div>
                        </div>
                    </div>
                </li>
                   <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">磅单图片</div>
                            <div class="item-input">
                                <%  if (!string.IsNullOrEmpty(cartast.BDImg)) 
                                    {
                                    %>
                                        <img src="<%=cartast.BDImg %>" />
                                    <%
                                        }else {
                                        %>
                                   请上传磅单图片，并与实际装车，卸车数量相符
                                <%
                                        }
                                     %>
                               
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content" style="background-color: powderblue">
                        <div class="item-inner">
                            <div class="item-title label"><%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","空车") %>商品详情</div>
                            <div class="item-input">
                            </div>
                             <div class="item-input"><a class="button" style="float:right;" href="javascript:pcallhtml('/mobile/html/LoadGoods.aspx?id=<%=cartast.ID %>','添加装卸车商品');"><%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","") %></a></div>
                        </div>
                    </div>
                </li>
                <%  if (order!=null&& order.OrderDetail != null)
                    {
                        foreach (var item in order.OrderDetail)
                        {
                %>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label"><%=yny_003.BLL.Goods.GetModel( item.GId).GName %></div>
                            <div class="item-input">
                                总<%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","空车") %>量<span style="color: red;"><%=item.GCount %></span>
                            </div>
                            <div class="item-input">
                                已<%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","空车") %>量<span style="color: red;"><%=item.ReCount %></span>
                            </div>
                        </div>
                    </div>
                </li>
                <%
                        }
                    }
                %>
              <%--  <li>
                    <div class="item-content" style="background-color: powderblue">
                        <div class="item-inner">
                            <div class="item-title label">费用详情</div>
                            <div class="item-input">
                            </div>
                            <div class="item-input"><a class="button" style="float:right;" href="javascript:pcallhtml('/mobile/html/CostAdd.aspx?id=<%=cartast.ID %>','添加费用');">添加费用</a></div>
                        </div>
                    </div>
                </li>
                <%  if (listcost != null)
                    {
                        foreach (var item in listcost)
                        {
                %>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label"><%=item.CostMoney %></div>
                            <div class="item-input">
                                <%=item.CareteDate %>
                            </div>
                            <div class="item-input">
                                <img src="<%=item.CostImgUrl %>" />
                            </div>
                        </div>
                    </div>
                </li>
                <%
                        }
                    }
                %>--%>
                <div class="content-block" id="anbtn" runat="server">
                    <div class="row">
                        <div class="col-100">
                            <a href="javascript:checkChange();" class="button button-big button-fill button-success">确认完成此任务</a>
                        </div>
                    </div>
                </div>
            </ul>
        </form>
    </div>

</div>
<script type="text/javascript">
    function checkChange() {
        //layer.confirm(function () {
        //    //ActionModel("mobile/html/TastView.aspx?Action=add", $('#form1').serialize());
        //});
            
        layer.confirm('确定交付任务吗？', {
            btn: ['确定', '取消']//按钮
        }, function (index) {
            layer.close(index);
            ActionModel("mobile/html/TastView.aspx?Action=add", $('#form1').serialize(),"mobile/html/TastList.aspx");
        });
    }
</script>
