﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartTypeList.aspx.cs" Inherits="yny_003.Web.OJ.DepartTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '';
        tUrl = "OJ/Handler/DepartTypeList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
              
            </div>
            <div class="pay" onclick="UpDateByID('OJ/EditDepartType.aspx?','修改批复部门',900,470);">
                修改批复部门</div>
            <div class="pay" onclick="v5.show('OJ/EditDepartType.aspx','新增批复部门','url',900,470)">
                新增批复部门</div>
            <%--<div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" /><input
                    id="nTitle" name="txtKey" data-name="txtKey" value="请输入项目名称" onfocus="if (value =='请输入项目名称'){value =''}"
                    onblur="if (value ==''){value='请输入项目名称'}" type="text" class="sinput" />
            </div>--%>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th width="40%">
                        批复部门名称
                    </th>
                    <th width="40%">
                        备注
                    </th>
                    
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_DepartType',',');">
                                删除</a>
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
