<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TastList.aspx.cs" Inherits="yny_003.Web.Car.TastList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '0';
        tUrl = "Car/Handler/TastList.ashx";
        SearchByCondition();

        function celTast(id)
        {
            ActionModel("Car/TastList.aspx?Action=Add", "tid="+id);
        }
    </script>
</head>
<body><div id="distr">
    </div>
    <div id="mempay">
        <div class="control">
            <div class="select">
                 <a href="javascript:void(0);" onclick="SearchByState('0',this);" class="btn btn-danger">正常</a> <%--<a href="javascript:void(0)" onclick="SearchByState('1',this);" class="btn btn-success">已删除</a>--%>
            </div>
               
                            <select id="coststate" name="txtKey" data-name="txtKey" onchange="SearchByCondition()" style="margin-top:8px;">
                                <option value="">任务状态</option>
                                <option value="0">未完成</option>
                                <option value="1">已完成</option>
                                <option value="2">已取消</option>
                            </select>
            <select id="TType" name="txtKey" data-name="txtKey" onchange="SearchByCondition()" style="margin-top:8px;">
                                <option value="">任务类型</option>
                                <option value="1">装车</option>
                                <option value="2">卸车</option>
                                <option value="3">空车</option>
                            </select>
                        
            <div class="pay" onclick="UpDateByID('Car/ModifyTast.aspx?','修改任务',900,470);">
                修改任务
            </div>
            <div class="pay" onclick="v5.show('Car/AddTast.aspx','新增任务','url',900,470)">
                新增任务
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input id="nTitle" name="txtKey" data-name="txtKey" placeholder="请输入任务名称" type="text" class="sinput" style="display:none;" />
                <input id="SupplierName" name="txtKey" data-name="txtKey" placeholder="请输入单位名称" type="text" class="sinput" />

                <input id="CarSJ1" name="txtKey" data-name="txtKey" placeholder="请输入主司机" type="text" class="sinput" />
                <input id="CarSJ2" name="txtKey" data-name="txtKey" placeholder="请输入副司机" type="text" class="sinput" />
                <input id="Spare2" name="txtKey" data-name="txtKey" placeholder="请输入车牌号" type="text" class="sinput" />
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="50px">全选
                    </th>
                    <th>序号
                    </th>
                   <%-- <th>任务名称
                    </th>--%>
                    <th>任务类型
                    </th>
                    <th>单位名称
                    </th>
                    <th>联系电话
                    </th>
                   
                    <th>派遣车辆
                    </th>
                     <th>派遣挂车
                    </th>
                     <th>商品
                    </th>
                    <th>下单数量
                    </th>
                    <th>实际数量
                    </th>
                    <%--<th>费用类型
                    </th>--%>
                    <th>创建日期
                    </th>
                    <th>交货日期
                    </th>
                     <th>任务状态
                    </th>
                    <th>操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <%--<a href="javascript:void(0);" title="" onclick="RunAjaxByList('','Del_Obj',',');">删除</a>--%>
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