<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankAccountList.aspx.cs" Inherits="yny_003.Web.Car.BankAccountList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  
    <script type="text/javascript">
        tState = '0';
        tUrl = "Car/Handler/BankAccountList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
  
    <div id="mempay">
        <div class="control">
            <div class="select">
                
            </div>
            <div class="pay" onclick="UpDateByID('Car/AddAccountBank.aspx?','修改账户',900,470);">
                修改账户
            </div>
            <div class="pay" onclick="v5.show('Car/AddAccountBank.aspx','新增账户','url',900,470)">
                新增账户
            </div>
           
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="4%">全选
                    </th>
                    <th>序号
                    </th>
                    <th>账户名称
                    </th>
                   <%-- <th>余额
                    </th>
                    <th>开户名
                    </th>
                    <th>开户行
                    </th>--%>
                  <%--  <th>操作
                    </th>--%>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_AccountBank',',');">删除</a>
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