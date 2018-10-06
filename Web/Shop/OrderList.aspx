<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="yny_003.Web.Shop.OrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        $(function () {
            tUrl = "Shop/Handler/OrderList2.ashx";
            tState = "<%=status %>";
            if (tState == 4) {
                $(".control .select > a:last").click();
            }
            else {
                SearchByCondition();
            }
        })
        //跳转到支付页面
        function payOrder(id) {
            callhtml('Shop/PayOrder.aspx?id=' + id, '订单支付');
        }
        //跳转到支付页面
        function ShowOrder(id) {
            callhtml('Shop/ShowOrder.aspx?id=' + id, '订单详情');
        }
        //管理员发货
        var pageii;
        var orderId = 0;
        function sendOrder(id) {
            callhtml('Shop/SendOrder.aspx?id=' + id, '订单发货');
        }
        function choiceReceive() {
            if (checkForm()) {
                layer.close(pageii);
                var comp = $.trim($("#txtExpressCompany").val());
                var comCode = $.trim($("#txtExpressCode").val());
                var result = GetAjaxString('sendOrder', orderId + "&com=" + comp + "&code=" + comCode, 'Shop/Handler/Ajax.ashx');
                if (result == 0) {
                    v5.alert("发货失败，请重试 ", '1', 'true');
                }
                else {
                    v5.alert("发货成功 ", '1', 'true');
                    callhtml('Shop/OrderList.aspx', '订单列表');
                }
            }
        }
        //确认收货
        function receiveOrder(id) {
            orderId = id;
            v5.confirm("确定收到货了吗？", realReceive);
        }
        function realReceive() {
            var result = GetAjaxString('receiveOrder', orderId, 'Shop/Handler/Ajax.ashx');
            if (result == 0) {
                v5.alert("收货失败，请重试 ", '1', 'true');
            }
            else {
                v5.alert("确认收货成功 ", '1', 'true');
                callhtml('Shop/OrderList.aspx', '订单列表');
            }
        }
        function seeExpress(id) {
            var result = GetAjaxString('seeExpress', id, 'Shop/Handler/Ajax.ashx');
            if (result != "0") {
                $("#txtExpressCompany").val(result.split('≌')[1]).attr("readonly", "readonly");
                $("#txtExpressCode").val(result.split('≌')[0]).attr("readonly", "readonly");
                $("#btnSendExperee").hide();
                pageii = layer.open({
                    type: 1,
                    shade: [0.5],
                    area: ['500px', 'auto'],
                    title: '选择收货人',
                    border: [5, 0.3, '#000'],
                    content: $('#receiveDiv')
                });
            }
        }
        // 导出Excel
        function exportExcel() {
            ExportExcel("ChangeMoney/Handler/ExportExcel.ashx", "THLBExcel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
              <%--  <a href="javascript:void(0);" onclick="SearchByState('',this);" class="btn btn-danger">全部</a>
                <a href="javascript:void(0)" onclick="SearchByState('1',this);" class="btn btn-success">未调度</a>
                <a href="javascript:void(0)" onclick="SearchByState('2',this);" class="btn btn-success">已调度</a>--%>
                <%--<a href="javascript:void(0)" onclick="SearchByState('3',this);" class="btn btn-success">未收货</a>--%>
                <%--<a href="javascript:void(0)" onclick="SearchByState('4',this);" class="btn btn-success">完成</a>--%>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--<input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />--%>
                <%--<input name="txtKey" data-name="txtKey" id="mKey" type="text" placeholder="客户名称" class="sinput" />--%>

                <select id="mKey" runat="server" name="txtKey" data-name="txtKey" onchange="SearchByCondition()" >
            </select>
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
            </div>
            <%--<div class="pay" onclick="UpDateByID('Member/UpMAgencyType.aspx?','升级员工',820,530)">
                升级员工</div>--%>
        </div>
        <div class="ui_table">
            <div id="receiveDiv" style="display: none">
                <table class="table">
                    <tr>
                        <td>快递公司
                        </td>
                        <td>
                            <input id="txtExpressCompany" class="normal_input" type="text" maxlength="20" require-type="require"
                                require-msg="快递公司" />
                        </td>
                    </tr>
                    <tr>
                        <td>快递单号
                        </td>
                        <td>
                            <input id="txtExpressCode" class="normal_input" type="text" require-type="require"
                                require-msg="快递单号" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="button" id="btnSendExperee" onclick="choiceReceive()" class="btn btn-success btn-sm"
                                value="确定" />
                        </td>
                    </tr>
                </table>
            </div>
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="4%">全选
                    </th>
                    <th>订单编号
                    </th>
                    <th>客户名称
                    </th>
                    <th>调度名称
                    </th>
                    <th>总价
                    </th>
                   <%-- <th>折后价
                    </th>--%>
                    <th>商品数量
                    </th>
                    <th>订单时间
                    </th>
                    <th>订单状态
                    </th>
                    <th>操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" id="divOperator" runat="server">
                    <%--<a href="javascript:void(0);" title="提交订单" onclick="RunAjaxByList('','SubmitOrder',',');">
                        提交订单</a>--%>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
