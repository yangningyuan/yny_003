<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="yny_003.Web.Car.SupplierList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '0';
        tUrl = "Car/Handler/SupplierList.ashx";
        SearchByCondition();
        // 导出Excel
        function exportExcel() {
            ExportExcel("Car/Handler/ExportExcel.ashx", "客户供应商统计报表Excel");
        }
    </script>
</head>
<body>
    <div id="distr">
    </div>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('0',this);" class="btn btn-danger">正常</a> <a href="javascript:void(0)" onclick="SearchByState('1',this);" class="btn btn-success">已删除</a>
            </div>

             <select id="SType" name="txtKey" data-name="txtKey" onchange="SearchByCondition()" style="margin-top:8px;">
                                <option value="">类型</option>
                                <option value="1">供应商</option>
                                <option value="2">客户</option>
                            </select>

            <div class="pay" onclick="UpDateByID('Car/AddSupplier.aspx?','修改客户信息',900,470);">
                修改客户信息
            </div>
            <div class="pay" onclick="v5.show('Car/AddSupplier.aspx','新增客户信息','url',900,470)">
                新增客户信息
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
               <input type="button" value="客户供应商统计报表Excel" class="btn btn-success" onclick="exportExcel()" />
                <input id="nTitle" name="txtKey" data-name="txtKey" placeholder="请输入名称" type="text" class="sinput" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                    <th>名称
                    </th>
                    <th>联系人
                    </th>
                    <th>电话
                    </th>
                    <th>地址
                    </th>
                    <th>欠款额度
                    </th>
                    <th>期初金额
                    </th>
                    <th>创建日期
                    </th>
                    <th>是否停用
                    </th>
                    <th>操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_C_Supplier',',');">删除</a>

                    <a href="javascript:void(0);" style="background-color:#808080;" title="" onclick="RunAjaxByList('','Close_C_Supplier',',');">停用</a>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function ShowAccount(id) {
          
                layer.open({
                    type: 2,
                    title: '账户详情',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['60%', '50%'],
                    content: '/car/upjiezhang.aspx?suppid=' + $("#SupplierName").val() + '&cid=' + cidList.join(',') //iframe的url
                });
            }
        
    </script>
</body>
</html>
