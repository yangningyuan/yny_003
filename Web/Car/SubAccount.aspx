<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubAccount.aspx.cs" Inherits="yny_003.Web.Car.SubAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '0';
        tUrl = "Car/Handler/SubAccount.ashx";
        SearchByCondition();
        // 导出Excel
        function exportExcel() {
            ExportExcel("Car/Handler/ExportExcel.ashx", "SuppLExcel");
        }
    </script>
</head>
<body>
    <%--  <div id="distr">
    </div>--%>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <%--  <a href="javascript:void(0);" onclick="SearchByState('0',this);" class="btn btn-danger">未结账</a> <a href="javascript:void(0)" onclick="SearchByState('1',this);" class="btn btn-success">已结账</a>--%>
            </div>

            <%--  <select id="coststate" name="txtKey" data-name="txtKey" onchange="SearchByCondition()" style="margin-top:8px;">
                                <option value="">任务状态</option>
                                <option value="0">未完成</option>
                                <option value="1">已完成</option>
                                <option value="2">已取消</option>
                            </select>--%>


            <%--  <div class="pay" onclick="UpDateByID('Car/ModifyTast.aspx?','修改任务',900,470);">
                修改任务
            </div>
            <div class="pay" onclick="v5.show('Car/AddTast.aspx','新增任务','url',900,470)">
                新增任务
            </div>--%>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input type="button" value="导出Excel" class="btn btn-success" onclick="exportExcel()" />
                <input id="CName" name="txtKey" data-name="txtKey" placeholder="请输入结账编号" type="text" class="sinput" />
                <select id="SupplierName" runat="server" name="txtKey" data-name="txtKey" onchange="SearchByCondition()">
                </select>
                <%--<input id="SupplierName" name="txtKey" data-name="txtKey" placeholder="请输入客户名称" type="text" class="sinput" />--%>

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
                    <th>结账编号
                    </th>
                    <th>客户类型
                    </th>
                    <th>客户名称
                    </th>
                    <th>付款类型
                    </th>
                    <th>付款总金额
                    </th>
                    <th>余额付款金额
                    </th>
                    <th>经办人
                    </th>
                    <th>结账时间
                    </th>
                    <th>操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <%--<a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_Obj',',');">删除</a>--%>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function ReSubAccount(oid) {
            layer.confirm("确认反结账吗？", function () {
                $.ajax({
                    type: 'post',
                    url: '/car/SubAccount.aspx?Action=Modify',
                    data: { oid: oid },
                    success: function (info) {
                        v5.alert(info, '1', 'true');
                        setTimeout(function () {
                            //window.parent.location.reload(); //刷新父页面
                            if (info == '反结账成功') {
                                parent.callhtml('/Car/SubAccount.aspx', '付款单列表'); onclickMenu();
                            }
                        }, 1000);
                    }
                });
            });
        }
    </script>
</body>
</html>
