<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostList2.aspx.cs" Inherits="yny_003.Web.Car.CostList2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '0';
        tUrl = "Car/Handler/CostList2.ashx";
        SearchByCondition();
        function shcost(id)
        {
            ActionModel("Car/CostList2.aspx?Action=Other", "cid="+id, "Car/CostList2.aspx");
        }
        // 导出Excel
        function exportExcel() {
            ExportExcel("Car/Handler/ExportExcel.ashx", "费用统计报表Excel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                 <a href="javascript:void(0);" onclick="SearchByState('0',this);" class="btn btn-danger">未审核</a> <a href="javascript:void(0)" onclick="SearchByState('2',this);" class="btn btn-success">已审核</a> <a href="javascript:void(0)" onclick="SearchByState('1',this);" class="btn btn-success">已删除</a>
                <span style="color:white;">未审核：</span><span style="color:white;" id="summoney" runat="server"></span>
            </div>
            <%--<div class="pay" onclick="UpDateByID('Car/AddCost.aspx?','修改费用类型',900,470);">
                修改费用类型
            </div>
            <div class="pay" onclick="v5.show('Car/AddCost.aspx','新增费用类型','url',900,470)">
                新增费用类型
            </div>--%>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                 <input type="button" value="费用统计报表" class="btn btn-success" onclick="exportExcel()" />
                
                <input
                    id="nTitle" name="txtKey" data-name="txtKey" placeholder="请输入费用名称" type="text" class="sinput" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                    <th>申请费用人
                    </th>
                    <th>费用用途
                    </th>
                    <th>费用金额
                    </th>
                    <th>费用图片
                    </th>
                    <th>创建日期
                    </th>
                    <th>操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_Obj',',');">删除</a>
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