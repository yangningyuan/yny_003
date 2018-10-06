<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarExcel.aspx.cs" Inherits="yny_003.Web.Car.CarExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script type="text/javascript">
        tState = '0';
        tUrl = "Car/Handler/CarExcelList.ashx";
        SearchByCondition();

        // 导出Excel
        function exportExcel() {
            ExportExcel("Car/Handler/ExportExcel.ashx", "车辆信息统计报表Excel");
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('0',this);" class="btn btn-danger">正常</a> <a href="javascript:void(0)" onclick="SearchByState('1',this);" class="btn btn-success">已报废</a>
            </div>

            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                
                <input type="button" value="车辆信息统计报表" class="btn btn-success" onclick="exportExcel()" />
                <select id="TType" name="txtKey" data-name="txtKey" onchange="SearchByCondition()" style="margin-top: 8px;">
                    <option value="">任务状态</option>
                    <option value="0">未完成</option>
                    <option value="1">已完成</option>
                </select>
                <input id="nTitle" name="txtKey" data-name="txtKey" placeholder="请输入车辆牌照" type="text" class="sinput" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" placeholder="开始日期"
                    value="开始日期" onfocus="if (value =='开始日期'){value =''}" class="daycash_input" style="width: 120px;"
                    onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" placeholder="截止日期"
                    value="截止日期" onfocus="if (value =='截止日期'){value =''}" class="daycash_input" style="width: 120px;"
                    onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="4%">全选
                    </th>
                    <th>序号
                    </th>
                    <th>牌照
                    </th>
                    <th>车型
                    </th>
                    <th>装车次数
                    </th>
                    <th>卸车次数
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
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
