<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WZAdd.aspx.cs" Inherits="yny_003.Web.mobile.html.WZAdd" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="bankauto" runat="server" />
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">车辆牌照</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtName" id="txtName" placeholder="请输入车辆牌照" >
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">违章记录</div>
                            <div class="item-input">
                                <textarea runat="server" name="txtDateils" id="txtDateils" rows="4"></textarea>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">处理结果</div>
                            <div class="item-input">
                            <textarea runat="server" name="txtRemark" id="txtRemark" rows="4"></textarea>
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
                <a href="javascript:checkChange();" class="button button-big button-fill button-success">提交</a>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function checkChange() {
        if ($('#txtName').val().trim() == "") {
            layer.msg("车辆牌照不能为空");
            return;
        } else if ($('#txtDateils').val().trim() == "") {
            layer.msg("违章记录不能为空");
            return;
        } else if ($('#txtRemark').val().trim() == "") {
            layer.msg("处理结果不能为空");
            return;
        } else {
            ActionModel("mobile/html/WZAdd.aspx?Action=add", $('#form1').serialize());
        }
    }
</script>