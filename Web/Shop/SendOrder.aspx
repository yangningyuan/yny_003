<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendOrder.aspx.cs" Inherits="yny_003.Web.Shop.SendOrder" %>

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
                                    <td>
                                        商品名称
                                    </td>
                                    <td>
                                        价格
                                    </td>
                                    <td>
                                        库存
                                    </td>
                                    <td>
                                        订购数量
                                    </td>
                                    <td>
                                        合计价格
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
                                                <%#GetOrderDetailCount(Eval("GID"))%>
                                            </td>
                                            <td>
                                                <%#Convert.ToDecimal(Eval("CostPrice")) * GetOrderDetailCount(Eval("GID"))%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="ReceiveDiv">
                                收货人:<%=ReceiveInfoModel.Receiver%>；联系电话<%=ReceiveInfoModel.Phone%>
                                <br />
                                地址:<%=ReceiveInfoModel.DetailAddress%>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            订单金额：<%=orderModel.TotalPrice%>；
                        </td>
                    </tr>
                    <tr>
                        <td>
                            快递公司:
                            <input id="txtExpressCompany" class="normal_input" type="text" maxlength="20" require-type="require"
                                require-msg="快递公司" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            快递单号：<input id="txtExpressCode" class="normal_input" type="text" require-type="require"
                                require-msg="快递单号" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input class="btn btn-danger" id="Button1" type="button" runat="server" value="确认发货"
                                onclick="checkSendNow();" />
                        </td>
                    </tr>
                </table>
            </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkSendNow() {
            if (checkForm()) {
                var comp = $("#txtExpressCompany").val();
                var comCode = $("#txtExpressCode").val();
                var result = GetAjaxString('sendOrder', $("#hidId").val() + "&com=" + comp + "&code=" + comCode, 'Shop/Handler/Ajax.ashx');
                if (result == 0) {
                    v5.alert("发货失败，请重试 ", '1', 'true');
                }
                else {
                    v5.alert("发货成功 ", '1', 'true');
                    callhtml('Shop/OrderList.aspx', '订单列表');
                }
            }
        }
    </script>
</body>
</html>
