<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarList.aspx.cs" Inherits="yny_003.Web.mobile.html.CarList" %>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
   
      <form id="form1">
          <input type="hidden" name="txtKey" id="countdate" />
            <input name="txtKey" id="mKey" type="hidden" class="sinput" />

            <div class="clear"></div>
            <div class="search-time">
                <input type="text" placeholder="开始时间" id="begin_time" runat="server" class="laydate-icon" />
                <input type="text" placeholder="结束时间" id="end_time" runat="server" class="laydate-icon" />
                <button type="button" class="requery searchh">查询</button>
            </div>


        <div class="buttons-tab">
            <input type="hidden" value="0" id="state" runat="server" />
            <a href="javascript:void(0)" onclick="$('#state').val('0'); dianji(this); " class="tab-link active button requery">正常</a>
            <a href="javascript:void(0)" onclick="$('#state').val('1'); dianji(this); " class="tab-link button requery">报废</a>
        </div>
    </form>
    <script type="text/x-jquery-tmpl" id="JKListTmpl">
        <tr>
            <td>${PZCode}</td>
            <td>${CarType}</td>
            <td>${CType}</td>
            <td>${CarZLC}</td>
        </tr>
    </script>

    <table class=" table table-striped table-bordered ">
        <thead>
            <tr>
                <th>牌照</th>
                <th>车型</th>
                <th>车辆类型</th>
                <th>里程</th>
                
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
            DataUrl: '/mobile/html/CarList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);
    function XSTastCel(id) {
        ActionModel("mobile/html/CarList.aspx?Action=Add", "cid=" + id, "mobile/html/CarList.aspx");
    }
</script>
<script>
    var start = {
        elem: '#begin_time',
        format: 'YYYY-MM-DD',
        min: '2009-06-16', //设定最小日期为当前日期
        max: '2099-06-16', //最大日期
        istoday: false,
        choose: function (datas) {
            end.min = datas; //开始日选好后，重置结束日的最小日期
            end.start = datas //将结束日的初始值设定为开始日
        }
    };
    var end = {
        elem: '#end_time',
        format: 'YYYY-MM-DD',
        min: start.toString(),
        max: '2099-06-16',
        istoday: false,
        choose: function (datas) {
            start.max = datas; //结束日选好后，重置开始日的最大日期
        }
    };
    //    laydate.skin("molv");
    laydate(start);
    laydate(end);
</script>