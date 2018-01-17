<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BCenterList.aspx.cs" Inherits="zx270.Web.Member.BCenterList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "Member/Handler/BCenterList.ashx";
        tState = "false";
        SearchByCondition();
        function displayA(isShow) {
            if (isShow) {
                $("#DivOperation").show();
            } else {
                $("#DivOperation").hide();
            }
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('false',this);displayA(true);"
                    class="btn btn-danger">未审核</a><a href="javascript:void(0)" onclick="SearchByState('true',this);displayA(false);"
                        class="btn btn-success">已审核</a>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" data-name="txtKey" id="mKey" placeholder="请输入会员账号" type="text" class="sinput" />
                <input type="text" name="txtKey" data-name="txtKey" id="startDate" placeholder="开始日期" class="daycash_input"
                    style="width: 120px;" onclick="WdatePicker({ maxDate: '#F{$dp.$D(\'endDate\')}' })" />
                <input type="text" name="txtKey" data-name="txtKey" id="endDate" placeholder="截止日期" class="daycash_input"
                    style="width: 120px;" onclick="WdatePicker({ minDate: '#F{$dp.$D(\'startDate\')}' })" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                    <th>会员ID
                    </th>
                    <th>会员名称
                    </th>
                    <th>手机号
                    </th>
                    <th>申请时间
                    </th>
                    <th>申请职位
                    </th>
                    <th>地区
                    </th>
                    <%--<th>
                        营业执照
                    </th>--%>
                    <th>是否审核
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <span id="DivOperation" runat="server"><a href="javascript:void(0);" title="正常审核"
                        onclick="RunAjaxByList('false','BCenter',',');">审核</a><a href="javascript:void(0);"
                            title="删除" onclick="RunAjaxByList('','Del_BCenter',',');">删除</a></span>
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
