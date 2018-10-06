<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DDTast.aspx.cs" Inherits="yny_003.Web.mobile.html.DDTast" %>

<script>
    layui.use("upload", function () {
        layui.upload({
            url: '/Admin/UpLoadPic/UploadImage.ashx',
            success: function (res) {
                console.log(res); //上传成功返回值，必须为json格式
                if (res.isSuccess) {
                    $("#upimage").attr("src", res.msg);
                    $("#uploadurl").val(res.msg);
                } else {
                    v5.alert(res.msg, '1', 'true')
                }
            }
        });
    });

</script>
<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="fid" runat="server" />
                <input type="hidden" id="oid" runat="server" />
             <div style="display: none;">
                        <td width="15%" align="right">商品订单号<input runat="server" id="Hidden1" type="hidden" />
                        </td>
                        <td width="20%" style="height: 40px;">
                            <input id="ocode" class="normal_input" runat="server" readonly="readonly" style="width: 30%;" />
                        </td>
                    </div>
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">任务订单号</div><input runat="server" id="lbID" type="hidden" />
                            <div class="item-input">
                                <input type="text" id="Name"  readonly="readonly" runat="server">
                            </div>
                        </div>
                    </div>
                </li>

                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">供应商或客户</div>
                            <div class="item-input">
                                  <%=supplier!=null?supplier.Name:"" %><br />
                                <div style="color: red; width:100%; font-size:10px;">【联系人：<%=cartast.SupplierTelName %>】<br />【联系方式：<%=cartast.SupplierTel %>】</div>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">地址</div>
                            <div class="item-input">
                                <%=cartast.SupplierAddress %>
                            </div>
                        </div>
                    </div>
                </li>

                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">任务类型</div>
                            <div class="item-input">
                                 <select id="TType" runat="server">
                                <option value="1">装车</option>
                                <option value="2">卸车</option>
                                <option value="3">空车</option>
                            </select>
                            </div>
                        </div>
                    </div>
                </li>

                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">商品名称</div>
                            <div class="item-input">
                                <%=goodname %>
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">商品数量</div>
                            <div class="item-input">
                                <%=goodcount %>
                            </div>
                        </div>
                    </div>
                </li>
               
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label"  id="jhstr">调度派遣车辆时间</div>
                            <div class="item-input">
                                <input type="text" id="ComDate" name="ComDate"  class="laydate-icon"  runat="server" >
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">派遣牵引车辆</div>
                            <div class="item-input">
                                  <select id="Spare2" name="Spare2" runat="server">
                                
                            </select>
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">派遣挂车（可空）</div>
                            <div class="item-input">
                                <select id="CSpare2" name="CSpare2" runat="server">
                                
                            </select>
                            </div>
                        </div>
                    </div>
                </li>
                  <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">主驾驶</div>
                            <div class="item-input">
                               <select id="CarSJ1" name="CarSJ1" runat="server"   onchange="setViewSiJi1(this[selectedIndex].value)">
                            </select>
                            <span id="sjview1" style="font-size:10px;"></span>

                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">押运员</div>
                            <div class="item-input">
                                <select id="CarSJ2" name="CarSJ2" runat="server"   onchange="setViewSiJi2(this[selectedIndex].value)">
                            </select>
                            <span id="sjview2" style="font-size:10px;"></span>

                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </form>
    </div>
    <div class="content-block">
        <div class="row">
            <div class="col-100">
                <a href="javascript:checkChange();" class="button button-big button-fill button-success"  runat="server" id="subview">提交</a>
            </div>
        </div>
    </div>
</div>
<script>
    var start = {
        elem: '#ComDate',
        format: 'YYYY-MM-DD',
        min: '2009-06-16', //设定最小日期为当前日期
        max: '2099-06-16', //最大日期
        istoday: false,
        choose: function (datas) {
           
        }
    };
    laydate(start);
</script>
 <script type="text/javascript">
     $(function () {
         setTimeout(function () {
             var objSelect = document.getElementById("CSpare2");
             objSelect.options.add(new Option("空项", ""), 0);

             var objSelect2 = document.getElementById("CarSJ1");
             objSelect2.options.add(new Option("--请选择--", ""), 0);

             var objSelect3 = document.getElementById("CarSJ2");
             objSelect3.options.add(new Option("--请选择--", ""), 0);

         }, 300);
     });

                function checkChange() {
                    ActionModel("Car/DDTast.aspx?Action=Modify", $('#form1').serialize(), "mobile/html/DDTastList.aspx");
                }
                function setViewSiJi1(realobj) {
                    document.getElementById("sjview1").innerHTML = RunAjaxGetKey('GetCarSJ1', $('#CarSJ1').val());
                }
                function setViewSiJi2(realobj) {
                    document.getElementById("sjview2").innerHTML = RunAjaxGetKey('GetCarSJ2', $('#CarSJ2').val());
                }
    </script>