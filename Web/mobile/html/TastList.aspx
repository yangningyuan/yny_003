<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TastList.aspx.cs" Inherits="yny_003.Web.mobile.html.TastList" %>

<div class="content content-padded pull-to-refresh-content" data-ptr-distance="55">
    <!-- 默认的下拉刷新层 -->
    <div class="pull-to-refresh-layer">
        <div class="preloader"></div>
        <div class="pull-to-refresh-arrow"></div>
    </div>
   
      <form id="form1">
        <div class="buttons-tab">
            <input type="hidden" value="0,-2" id="state" runat="server" />
            <a href="javascript:void(0)" onclick="$('#state').val('0,-2'); dianji(this); " class="tab-link active button requery">未完成</a>
            <a href="javascript:void(0)" onclick="$('#state').val('1'); dianji(this); " class="tab-link button requery">已完成</a>
            <a href="javascript:void(0)" onclick="$('#state').val('2'); dianji(this); " class="tab-link button requery">已取消</a>
        </div>
    </form>
    <script type="text/x-jquery-tmpl" id="JKListTmpl">
        <tr>
            
            <td>${Name}</td>
            <td>${SupplierTel}</td>
            <td>${CreateDate}</td>
            <td>{{html dhtml}}</td>
        </tr>
    </script>

    <table class=" table table-striped table-bordered ">
        <thead>
            <tr>
                <th>客户</th>
                <th>商品名称</th>
                <th>时间</th>
                <th>详情</th>
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
            DataUrl: '/mobile/html/TastList.aspx?Action=Other',
            QueryContainer: '#form1',
            Rendered: function () {
                window.MobileSelectAll();
            }
        });
    }, 50);

</script>