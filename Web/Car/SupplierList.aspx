﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="yny_003.Web.Car.SupplierList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '0';
        tUrl = "Car/Handler/SupplierList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('0',this);" class="btn btn-danger">正常</a> <a href="javascript:void(0)" onclick="SearchByState('1',this);" class="btn btn-success">已删除</a>
            </div>
            <div class="pay" onclick="UpDateByID('Car/AddSupplier.aspx?','修改客户信息',900,470);">
                修改客户信息
            </div>
            <div class="pay" onclick="v5.show('Car/AddSupplier.aspx','新增客户信息','url',900,470)">
                新增客户信息
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" /><input
                    id="nTitle" name="txtKey" data-name="txtKey" placeholder="请输入名称" type="text" class="sinput" />
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
                    <th>期初金额
                    </th>
                    <th>欠款额度
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