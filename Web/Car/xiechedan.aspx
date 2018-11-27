
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xiechedan.aspx.cs" Inherits="yny_003.Web.Car.xiechedan" %>

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
    <script>
        function celTast(id) {
            ActionModel("TastList.aspx?Action=Add", "tid=" + id);
            //layer.closeAll();
            //subxiechedan();
        }
        function SetBJTast(id) {
            ActionModel("TastList.aspx?Action=Modify", "tid=" + id);
            //layer.closeAll();
            //subxiechedan();
        }
        function SetCelTast(id) {
            ActionModel("TastList.aspx?Action=Other", "tid=" + id);
            //layer.closeAll();
            //subxiechedan();
        }
    </script>
    <script>
           function subxiechedan() {
            layer.open({
                type: 2,
                title: '卸车单',
                shadeClose: true,
                shade: 0.8,
                area: ['80%', '80%'],
                content: '/car/xiechedan.aspx?tid=' + $("#tidv").val()
            });
        }
    </script>
</head>
<body style="background: url();">
    <input type="hidden" id="tidv"  runat="server"/>
    <div>
        <table cellpadding="0" cellspacing="0" class="tabcolor table table-bordered table-hover" id="Result" style="background-color: rgb(252, 252, 252);">
            <tbody>
                <tr>
                    <th>卸车单号
                    </th>
                    <th>装车单号
                    </th>
                    <th>任务类型
                    </th>
                    <th>比重
                    </th>
                    <th>单位名称
                    </th>
                    <%--<th>联系电话
                    </th>--%>
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
                    <td><%=item.Name %></td>
                    <td><%=item.TCode %></td>
                    <td>
                        <%=BllModel.typename(item.TType)%>
                    </td>
                    <td><%=item.Prot %></td>
                    <td><%=BllModel.GetModelsub(item.SupplierName)%></td>
                    <td><%=item.Spare2 %></td>

                    <td><%=item.CSpare2 %></td>
                    <td><%=BllModel.getgoods(item.OCode) %></td>
                    <td><%=BllModel.getgoodsgcount(item.OCode) %></td>
                    <td><%=BllModel.getgoodsrecount(item.OCode) %></td>
                    <td><%=item.CreateDate %></td>
                    <td><%=item.ComDate %></td>
                    <td><%=BllModel.statename(item.TState)  %></td>
                    

                    <td><%
                            if (item.TState != 2 && TModel.Role.IsAdmin)
                            {
                                %>
                    <div class="pay btn btn-danger" onclick="celTast('<%=item.ID %>')">取消任务</div>
                        <%
                            }
                            else if (item.TState == -1 && TModel.Role.DiaoDu)
                            {%>
                    <div class="pay btn btn-success" onclick="callhtml('/Car/DDTast.aspx?id= <%=item.ID  %>','调度');onclickMenu()">调度</div>
                  <%
                      }
                      if (item.TState == 1)
                      {%>
                    <div class="pay btn btn-success" onclick="SetBJTast('<%=item.ID %>')">错误标记</div>
                 <%
                     }
                     if (item.TState == -2)
                     {
                           %>
                 <div class="pay btn btn-danger" onclick="SetCelTast('<%= item.ID %>')">取消标记</div>
                     <%
                         }
                        

                             %></td>
                </tr>
                <%
                        }

                    }

                %>
            </tbody>
        </table>
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
       

    </script>
</body>
</html>