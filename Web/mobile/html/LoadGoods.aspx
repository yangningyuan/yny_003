<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadGoods.aspx.cs" Inherits="yny_003.Web.mobile.html.LoadGoods" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="cid" runat="server" />
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content" style="background-color: powderblue">
                        <div class="item-inner">
                            <div class="item-title label">商品调度</div>
                            <div class="item-input">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">任务名称</div>
                            <div class="item-input">
                                <%=cartast.Name%>【<%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","空车") %>】
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">商品列表</div>
                            <div class="item-input">
                                <select id="txtGoodList"  name="txtGoodList">
                                    <%=strordsel %>
                                </select>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">【<%=cartast.TType.ToString().Replace("1","装车").Replace("2","卸车").Replace("3","空车") %>】数量</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtGCount" id="txtGCount" placeholder="请输入调度数量">
                            </div>
                        </div>
                    </div>
                </li>
                <div class="content-block">
                    <div class="row">
                        <div class="col-100">
                            <a href="javascript:checkChange();" class="button button-big button-fill button-success">提交</a>
                        </div>
                    </div>
                </div>
            </ul>
        </form>
    </div>

</div>
<script type="text/javascript">
    function checkChange() {
        if ($('#txtGCount').val().trim() == "") {
            layer.msg("调度数量不能为空");
            return;
        } else {
            ActionModel("mobile/html/LoadGoods.aspx?Action=add", $('#form1').serialize(), "/mobile/html/TastView.aspx?id=" + $("#cid").val());
        }
    }
</script>
