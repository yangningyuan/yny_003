<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upjiezhang.aspx.cs" Inherits="yny_003.Web.Car.upjiezhang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Admin/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Admin/css/font-awesome.min.css" rel="stylesheet" />
    <link href="/Admin/css/style.css" rel="stylesheet" />
    <link href="/Admin/css/style-responsive.css" rel="stylesheet" />
    <link href="/Admin/css/reset.css" rel="stylesheet" />
    <link href="/Admin/css/main.css" rel="stylesheet" />
    <link href="/Admin/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <%--<script src="/Admin/js/jquery-1.8.3.min.js"></script>--%>
    <script type="text/javascript" src="/Admin/js/jquery-1.11.1.min.js"></script>
</head>
<body style="background: url();">

    <div>
        <span>付款单号：<%=acode %></span><span style="float: right;">单位名称：<%=suppname %></span><span style="float: right;">余额：<%=blanmoney %>&nbsp;&nbsp;&nbsp;</span>
        <table cellpadding="0" cellspacing="0" class="tabcolor table table-bordered table-hover" id="Result" style="background-color: rgb(252, 252, 252);">
            <tbody>
                <tr>

                    <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">序号
                    </th>
                    <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">类型
                    </th>
                    <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">单位
                    </th>
                    <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">任务时间
                    </th>
                    <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">发票
                    </th>
                    <th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">应付款
                    </th>
                    <%--<th style="background-color: rgb(199, 42, 37); color: rgb(255, 255, 255);">已付款
                    </th>--%>
                </tr>
                <%
                    if (listacc != null)
                    {
                        int index = 0;
                        foreach (var item in listacc)
                        {
                            index++;
                %>
                <tr onclick="trClick(this)">

                    <td><% =index%></td>
                    <td><%=item.AType.ToString().Replace("0","装车").Replace("1","卸车") %></td>
                    <td><%=item.SupplierName %>&nbsp;</td>
                    <td><%=item.CreateDate %></td>
                    <td><%=item.Spare == "1" ? "<span style='color:green;'>已开发票</span>" : "<span style='color:red;'>未开发票</span>" %></td>
                    <td><%=item.TotalMoney %></td>
                    <%--<td><%=item.ReMoney %></td>--%>
                </tr>
                <%
                        }

                    }

                %>
                <tr onclick="trClick(this)">
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>付款总额：</td>
                    <td><%= totalmoney%></td>
                    <%--<td></td>--%>
                </tr>
            </tbody>
        </table>
        <span></span>
        <br />
        <div id="mempay" style="float: left; width:100%;">
            <div id="finance" style="background-color:#EEEEEE; ">
                <form id="form1" runat="server">
                    <input type="hidden" id="hcid" name="hcid" runat="server" />
                    <input type="hidden" id="htotalmoney" name="htotalmoney" runat="server" />
                    <input type="hidden" id="hsuppid" name="hsuppid" runat="server" />
                    <input type="hidden" id="hacode" name="hacode" runat="server" />
                    <table cellpadding="0" cellspacing="0" >
                        <tr>
                            <td width="24%" align="right">经办人
                            </td>
                            <td width="24%" style="height: 40px;">
                                <input id="UserName" class="normal_input" runat="server" style="width: 50%;" />
                            </td>
                             <td width="24%" align="right">支付金额
                            </td>
                            <td width="24%" style="height: 40px;">
                                <input id="PayMoney" class="normal_input" runat="server" style="width: 50%;" />
                            </td>
                        </tr>
                       
                        <tr>
                            <td width="24%" align="right">付款方式
                            </td>
                            <td width="24%" style="height: 40px;">
                                <input type="radio" name="JZType" value="1" checked="checked" onclick="fkjsnone()" />余额支付
                                <input type="radio" name="JZType" value="2" onclick="fkjs()" />账户卡支付
                                <input type="radio" name="JZType" value="3" onclick="fkjs()" />账户卡+余额支付
                            </td>
                                 <td width="24%" align="right"   style="display: none;" id="fkview">请选择付款卡
                            </td>
                            <td width="24%"   style="display: none;" id="ifkview">
                                <select id="FKAccount" name="FKAccount">
                                    <%
                                        if (listbank != null)
                                        {
                                            for (int i = 0; i < listbank.Count; i++)
                                            {
                                    %>
                                    <option value="<%=listbank[i].ID %>"><%=listbank[i].AccountName %></option>
                                    <%
                                            }
                                        }
                                    %>
                                </select>
                            </td>
                        </tr>

                       <br />
                        <br />
                        <br />
                        <tr>
                             <td></td>
                            <td></td>
                            <td width="24%" align="right"></td>
                            <td width="24%" align="left">

                                <input type="button" class="pay btn btn-success" value="结账" onclick="subaccChange();" />
                            </td>
                           
                        </tr>
                        <tr></tr>
                        <tr></tr>
                    </table>
                </form>
            </div>
        </div>
    </div>
    <script src="/Admin/js/bootstrap.min.js"></script>
    <script src="/Admin/js/jquery.scrollTo.min.js"></script>
    <script src="/Admin/js/jquery.nicescroll.js"></script>
    <script src="/Admin/js/common-scripts.js"></script>

    <script src="/Admin/js/EPjs.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="/Admin/pop/css/pop.css" />
    <link rel="stylesheet" type="text/css" href="/Admin/pop/css/V5-UI.css" />
    <link rel="stylesheet" type="text/css" href="/Admin/pop/css/next_page_search.css" />
    <link rel="stylesheet" type="text/css" href="/plugin/layer/skin/layer.css" />
    <link rel="stylesheet" type="text/css" href="/plugin/kindeditor/themes/default/default.css" />
    <script type="text/javascript" src="/plugin/layer/layer.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/MyValide.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/TableToExcel.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/linkage.js"></script>

    <link href="/plugin/layui/css/layui.css" rel="stylesheet" />
    <script src="/plugin/layui/layui.js"></script>

    <script type="text/javascript" src="/Shop/js/shopJs.js"></script>
    <%--<script type="text/javascript" src="Module/Investment/js/invest.js"></script>--%>
    <script type="text/javascript" src="/Admin/pop/js/javascript_main.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/ajax.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/javascript_pop.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/V5-UI.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/jquery.pagination.js" charset="gbk"></script>
    <script type="text/javascript" src="/plugin/date/WdatePicker.js"></script>
    <script type="text/javascript" src="/plugin/ZeroClipboard/ZeroClipboard.js"></script>
    <script type="text/javascript" src="/plugin/kindeditor/kindeditor-min.js"></script>
    <script src="/Admin/pop/js/jquery.qrcode.min.js"></script>
    <script>
        function subaccChange() {
            if ($('#UserName').val() == '') {
                v5.error('经办人不能为空', '1', 'ture');
            } else if ($("#FKAccount").val() == '') {
                v5.error('付款卡不能为空', '1', 'ture');
            }
            else {
                //ActionModel("/car/upjiezhang.aspx?Action=Modify", $('#form1').serialize(), "Car/AccountUPList.aspx");
                $.ajax({
                    type: 'post',
                    url: '/car/upjiezhang.aspx?Action=Modify',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.alert(info, '1', 'true');
                        setTimeout(function () {
                            //window.parent.location.reload(); //刷新父页面

                            if (info == '结账成功') {
                                var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
                                parent.layer.close(index);  // 关闭layer

                                setTimeout(function () {
                                    parent.callhtml('/Car/AccountUPList.aspx', '付款单列表'); onclickMenu();
                                }, 1000);

                            }
                        }, 1000);
                    }
                });
            }
        }

        function fkjs() {
            document.getElementById("fkview").style.display = "";
            document.getElementById("ifkview").style.display = "";
        }
        function fkjsnone() {
            document.getElementById("fkview").style.display = "none";
            document.getElementById("ifkview").style.display = "none";
        }

        
    </script>
</body>
</html>
