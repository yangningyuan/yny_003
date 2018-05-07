<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarYJ.aspx.cs" Inherits="yny_003.Web.mobile.html.CarYJ" %>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
   
      <form id="form1">
          <input type="hidden" name="txtKey" id="countdate" />
            <input name="txtKey" id="mKey" type="hidden" class="sinput" />

            <%--<div class="clear"></div>
            <div class="search-time">
                <input type="text" placeholder="开始时间" id="begin_time" runat="server" class="laydate-icon" />
                <input type="text" placeholder="结束时间" id="end_time" runat="server" class="laydate-icon" />
                <button type="button" class="requery searchh">查询</button>
            </div>--%>


        <div class="buttons-tab">
            <input type="hidden" value="bx" id="state" runat="server" />
            <a href="javascript:void(0)" onclick="$('#state').val('bx'); dianji(this); " class="tab-link active button requery">压力表</a>
            <a href="javascript:void(0)" onclick="$('#state').val('yy'); dianji(this); " class="tab-link button requery">营运</a>
            <a href="javascript:void(0)" onclick="$('#state').val('by'); dianji(this); " class="tab-link button requery">保养</a>
            <a href="javascript:void(0)" onclick="$('#state').val('gj'); dianji(this); " class="tab-link button requery">罐检</a>
            <a href="javascript:void(0)" onclick="$('#state').val('aqf'); dianji(this); " class="tab-link button requery">安全阀</a>
        </div>
    </form>
    <script type="text/x-jquery-tmpl" id="JKListTmpl">
        <tr>
            <td>${PZCode}</td>
            <td>${CarType}</td>
            <td>${CType}</td>
            <td>${DQDate}</td>
            <td>{{html CountDay}}</td>
        </tr>
    </script>

    <table class=" table table-striped table-bordered ">
        <thead>
            <tr>
                <th>牌照</th>
                <th>车型</th>
                <th>车辆类型</th>
                <th>到期时间</th>
                <th>距期</th>
            </tr>
        </thead>
        <tbody id="data_container">
        </tbody>
    </table>
    <div id="page_container">
    </div>
</div>

<script>
    $(".buttons-tab a").click(function () {
        var n = $(".buttons-tab a").index(this);
        $(".buttons-tab a").eq(n).addClass("active");
    })
    function dianji(obj) {
        $(".tab-link").removeClass('active');
        obj.addClass('active');
    }

    $(function () {
        $('#data_container').on('click', '.list-detail', function () {
            //console.log(parseInt($(this).next().css('height')));
            if (parseInt($(this).next().css('height')) < 300) {
                $(this).next().css('height', '300px');
            }

            $(this).next().slideDown();
        })
        $('#data_container').on('click', '.detail-close', function () {
            $(this).parent().slideUp();
        })
    })
</script>
<script type="text/javascript">
    setTimeout(function () {
        $('#page_container').Paging({
            TemplateContainer: '#JKListTmpl',
            DataContainer: '#data_container',
            DataUrl: '/mobile/html/CarYJ.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);
    function XSTastCel(id) {
        ActionModel("mobile/html/CarYJ.aspx?Action=Add", "cid=" + id, "mobile/html/CarYJ.aspx");
    }
</script>
