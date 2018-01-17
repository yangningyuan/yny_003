<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjList.aspx.cs" Inherits="yny_003.Web.OJ.ObjList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '';
        tUrl = "OJ/Handler/ObjList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0)" onclick="SearchByState('',this);" class="btn btn-danger">
                    所有</a> <a href="javascript:void(0);" onclick="SearchByState('1',this);" class="btn btn-success">
                        已完成</a> <a href="javascript:void(0)" onclick="SearchByState('0',this);" class="btn btn-success">
                           未完成</a>
            </div>
            <div class="pay" onclick="UpDateByID('OJ/EditObj.aspx?','修改项目',900,470);">
                修改项目</div>
            <div class="pay" onclick="v5.show('OJ/AddObj.aspx','新增项目','url',900,470)">
                新增项目</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" /><input
                    id="nTitle" name="txtKey" data-name="txtKey" placeholder="请输入项目名称"  type="text" class="sinput" />
            </div>
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
                    <th width="14%">
                        项目名称
                    </th>
                    <th>
                        负责人
                    </th>
                    
                    <th>
                        总经费
                    </th>
                    <th>
                        批复部门
                    </th>
                    <th>
                        开始时间
                    </th>
                    <th>
                        结束时间
                    </th>
                    <th>
                        状态
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_Obj',',');">
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
