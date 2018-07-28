<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountUPList.aspx.cs" Inherits="yny_003.Web.Car.AccountUPList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '0';
        tUrl = "Car/Handler/AccountUPList.ashx";
        SearchByCondition();
        function celTast(id)
        {
            ActionModel("Car/AccountUPList.aspx?Action=Add", "tid=" + id);
        }
        function execfp(id) {
            ActionModel("Car/AccountUPList.aspx?Action=Other", "cid=" + id);
        }
        // 导出Excel
        function exportExcel() {
            ExportExcel("Car/Handler/ExportExcel.ashx", "AccountUPExcel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                 <a href="javascript:void(0);" onclick="SearchByState('0',this);" class="btn btn-danger">未结账</a> <a href="javascript:void(0)" onclick="SearchByState('1',this);" class="btn btn-success">已结账</a>
            </div>
               
                          <%--  <select id="coststate" name="txtKey" data-name="txtKey" onchange="SearchByCondition()" style="margin-top:8px;">
                                <option value="">任务状态</option>
                                <option value="0">未完成</option>
                                <option value="1">已完成</option>
                                <option value="2">已取消</option>
                            </select>
            <select id="TType" name="txtKey" data-name="txtKey" onchange="SearchByCondition()" style="margin-top:8px;">
                                <option value="">任务类型</option>
                                <option value="1">装车</option>
                                <option value="2">卸车</option>
                                <option value="3">空车</option>
                            </select>--%>
                        
          <%--  <div class="pay" onclick="UpDateByID('Car/ModifyTast.aspx?','修改任务',900,470);">
                修改任务
            </div>
            <div class="pay" onclick="v5.show('Car/AddTast.aspx','新增任务','url',900,470)">
                新增任务
            </div>--%>
            <div class="pay btn btn-success" onclick="UpDateByID('Car/ModifyAccount.aspx?type=uplist','修改付款单',900,470);">
                修改付款单
            </div>
            <div class="search" id="DivSearch" runat="server">
               <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />
                <input id="CName" name="txtKey" data-name="txtKey" placeholder="请输入任务编号" type="text" class="sinput" />
                 <select id="SupplierName" runat="server" name="txtKey" data-name="txtKey" onchange="SearchByCondition()" >
            </select>

            <%--    <input id="CarSJ1" name="txtKey" data-name="txtKey" placeholder="请输入主司机" type="text" class="sinput" />
                <input id="CarSJ2" name="txtKey" data-name="txtKey" placeholder="请输入副司机" type="text" class="sinput" />
                <input id="Spare2" name="txtKey" data-name="txtKey" placeholder="请输入车牌号" type="text" class="sinput" />--%>
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                   <%-- <th>任务名称
                    </th>--%>
                    <th>任务编号
                    </th>
                    <th>供应商名称
                    </th>
                    <th>应付总金额
                    </th>
                      <th>
                        商品数量
                    </th>
                    <th>商品单价</th>
                    <th>已付金额
                    </th>
                    <th>状态
                    </th>
                    <th>发票状态
                    </th>
                    <th>任务时间
                    </th>
                     <th>结账时间
                    </th>
                     <th>修改备注
                    </th>
                    <th>操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="subjiezhang()">结账</a>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function subjiezhang()
        {
            //iframe层
            if ($("#SupplierName").val() == "--请选择--")
            {
                v5.error('请选择供应商', '1', 'ture');
            }
            else if (cidList.join(',') == "") {
                layer.open({
                    type: 2,
                    title: '付款单结账',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['50%', '45%'],
                    content: '/car/upjiezhang2.aspx?suppid=' + $("#SupplierName").val() + '&cid=' + cidList.join(',') //iframe的url
                });
            } else {
                layer.open({
                    type: 2,
                    title: '付款单结账',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['80%', '70%'],
                    content: '/car/upjiezhang.aspx?suppid=' + $("#SupplierName").val() + '&cid=' + cidList.join(',') //iframe的url
                });
            }
        }
    </script>
</body>
</html>