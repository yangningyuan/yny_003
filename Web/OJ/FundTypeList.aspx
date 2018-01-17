<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FundTypeList.aspx.cs" Inherits="yny_003.Web.OJ.FundTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '';
        tUrl = "OJ/Handler/FundTypeList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
              
            </div>
            <div class="pay" onclick="UpDateByID('OJ/EditFundType.aspx?','修改经费来源',900,470);">
                修改经费来源</div>
            <div class="pay" onclick="v5.show('OJ/EditFundType.aspx','新增经费来源','url',900,470)">
                新增经费来源</div>
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
                        经费来源名称
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
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_FundType',',');">
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
