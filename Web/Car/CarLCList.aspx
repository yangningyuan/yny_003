<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarLCList.aspx.cs" Inherits="yny_003.Web.Car.CarLCList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  
    <script type="text/javascript">
        tState = '0';
        tUrl = "Car/Handler/CarLCList.ashx";
        SearchByCondition();

        // 导出Excel
        function exportExcel() {
            ExportExcel("Car/Handler/ExportExcel.ashx", "运输车辆交车记录统计报表Excel");
        }
    </script>
</head>
<body>
  
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input type="button" value="运输车辆交车记录统计报表" class="btn btn-success" onclick="exportExcel()" />
                <input
                    id="nTitle" name="txtKey" data-name="txtKey" placeholder="请输入车辆牌照" type="text" class="sinput" />
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
                    <th>主司机
                    </th>
                    <th>押运员
                    </th>
                    <th>开始里程
                    </th>
                    <th>交车里程
                    </th>
                    <th>行驶里程
                    </th>
                    <th>交车日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <%--<a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_Car',',');">删除</a>--%>
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