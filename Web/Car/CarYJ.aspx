<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarYJ.aspx.cs" Inherits="yny_003.Web.Car.CarYJ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  
    <script type="text/javascript">
        tState = 'bx';
        tUrl = "Car/Handler/CarYJ.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="distr">
    </div>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('bx',this);" class="btn btn-danger">压力表</a> 
                <a href="javascript:void(0)" onclick="SearchByState('yy',this);" class="btn btn-success">营运</a>
                <a href="javascript:void(0)" onclick="SearchByState('by',this);" class="btn btn-success">保养</a>
                <a href="javascript:void(0)" onclick="SearchByState('gj',this);" class="btn btn-success">罐检</a>
                <a href="javascript:void(0)" onclick="SearchByState('aqf',this);" class="btn btn-success">安全阀</a>
            </div>
           <%-- <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" /><input
                    id="nTitle" name="txtKey" data-name="txtKey" placeholder="请输入车辆牌照" type="text" class="sinput" />
            </div>--%>
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
                    <th>车辆类型
                    </th>
                    <th>到期时间
                    </th>
                    <th>距期
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