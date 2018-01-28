<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowOrder.aspx.cs" Inherits="yny_003.Web.Shop.ShowOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <input type="hidden" id="hidId" runat="server" />
                <div class="goodinfo">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>商品名称
                                        </td>
                                        <td>价格
                                        </td>
                                        <td>库存
                                        </td>
                                        <td><%=orderModel.OType==1?"装车":"卸车" %>数量
                                        </td>
                                        <td><%=orderModel.OType==1?"已装车":"已卸车" %>数量
                                        </td>
                                        <td>合计价格
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="repGoodList" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <img class="appImg" alt="<%#Eval("GName")%>" src="<%#Eval("ImageAddr")%>" />
                                                    <%#Eval("GName")%>
                                                </td>
                                                <td>
                                                    <%#Eval("CostPrice")%>/<%#Eval("Unit")%>
                                                </td>
                                                <td>
                                                    <%#Eval("SellingCount")%>
                                                </td>
                                                <td>
                                                    <%#GetOrderDetailCount(Eval("GID")).GCount%>
                                                </td>
                                                <td>
                                                    <%#GetOrderDetailCount(Eval("GID")).ReCount%>
                                                </td>
                                                <td>
                                                    <%#Convert.ToDecimal(Eval("CostPrice")) *GetOrderDetailCount(Eval("GID")).GCount%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td>
                                <div class="ReceiveDiv">
                                    收货人:<%=ReceiveInfoModel.Receiver%>；联系电话<%=ReceiveInfoModel.Phone%>
                                    <br />
                                    地址:<%=ReceiveInfoModel.DetailAddress%>
                                </div>
                            </td>
                        </tr>--%>
                        <tr style="display: none">
                            <td>
                                <strong>数量:</strong> <span class="goodNum numDesc" onclick="numDesc(this)">&nbsp;-&nbsp;</span>
                                <input type="text" id="choiceOrderNum" class="numVal" value="1" onchange="checkIsNum()" />
                                <span class="goodNum numAsc" onclick="numAsc(this)">&nbsp;+&nbsp;</span>
                            </td>
                        </tr>
                        <tr>
                            <td>订单金额：<%=orderModel.TotalPrice%>
                            </td>
                        </tr>
                      <%--  <tr>
                            <td>状态:<span style="color: Red"><%=status %></span>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <input class="btn btn-danger" id="Button1" type="button" runat="server" value="返回订单列表"
                                    onclick="OrderList();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function OrderList() {
            callhtml('Shop/OrderList.aspx', '订单列表');
        }
    </script>
</body>
</html>
