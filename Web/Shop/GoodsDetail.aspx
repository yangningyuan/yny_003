<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsDetail.aspx.cs" Inherits="yny_003.Web.Shop.GoodsDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function numDesc1(obj) {
            var oldNum = $(obj).next().val();
            if (parseInt(oldNum) != 1) {
                var newNum = parseInt(oldNum) - 1;
                $(obj).next().val(newNum);
            }
        }
        function numAsc1(obj) {
            var oldNum = $(obj).prev().val();
            var newNum = parseInt(oldNum) + 1;
            $(obj).prev().val(newNum);
        }
        function checkIsNum1() {
            var value = $.trim($("#choiceOrderNum").val());
            if (!(/(^\d+$)/.test(value)) || value < 0) {
                v5.error('购买数量只能输入正整数', '1', 'true');
                $("#choiceOrderNum").focus().val("1");
                return false;
            }
        }
        function checkAddCar1() {
            var result = GetAjaxString('AddShopCar', $("#hidId").val() + "&count=" + $("#choiceOrderNum").val(), 'Shop/Handler/Ajax.ashx');
            if (result == "0") {
                v5.alert("添加失败，请重试", '1', 'true');
            }
            else {
                v5.alert("已添加到任务包，您可以在[任务包]中提交订单并结算", '2', 'true');
            }
        }
        function checkBuyNow1() {
            var result = GetAjaxString('AddShopCar', $("#hidId").val() + "&count=" + $("#choiceOrderNum").val() + "&pop=1", 'Shop/Handler/Ajax.ashx');
            if (result == "1") {

            }
        }

    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input type="hidden" id="hidId" runat="server" />
            <div class="goodinfo">
                <table cellpadding="0" cellspacing="0" id="goodinfotb">
                    <tr>
                        <td>
                            商品名称：<%=model.GName%>; &emsp; 商品分类：<%=GetCategory(model.GParentCode)%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            价格：<span class="spPrice">
                                <%=model.CostPrice%>/<%=model.Unit%></span> &emsp; 已售出数量：<%=model.SelledCount%>
                            &emsp; 库存：<%=model.SellingCount%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            商品描述：<%=model.Remark%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>数量:</strong> <span class="goodNum numDesc" onclick="numDesc1(this)">&nbsp;-&nbsp;</span>
                            <input type="text" id="choiceOrderNum" class="numVal" value="1" onchange="checkIsNum1()" />
                            <span class="goodNum numAsc" onclick="numAsc1(this)">&nbsp;+&nbsp;</span>
                            <input class="btn btn-success" id="btnOK" type="button" value="加入任务包" onclick="checkAddCar1();" />
                            <input class="btn btn-danger" id="Button1" type="button" value="立即购买" style="display: none"
                                onclick="checkBuyNow1();" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="float: left" id="tablePic">
                                <asp:Repeater ID="rep_PicList" runat="server">
                                    <ItemTemplate>
                                        <div class="appDiv">
                                            <img class="appImg" src="<%#Eval("PicURL") %>" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            </form>
        </div>
    </div>
</body>
</html>
