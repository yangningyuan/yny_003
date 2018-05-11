<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JKChange.aspx.cs" Inherits="yny_003.Web.mobile.html.JKChange" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="bankauto" runat="server" />
            <ul>
                <!-- Text inputs -->
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">借款人</div>
                            <div class="item-input">
                                <input type="text" value="<%=TModel.MID%>" disabled="disabled">
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">借款金额</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtMHB" id="txtMHB" placeholder="请输入借款金额">
                            </div>
                        </div>
                    </div>
                </li>
               
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">借款发放方式</div>
                            <div class="item-input">
                                <input type="text" value=""  name="txtFFType" id="txtFFType" placeholder="请填写借款发放方式">
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
        if ($('#txtMHB').val().trim() == "") {
            layer.msg("借款金额不能为空");
            return;
        } else {
            ActionModel("mobile/html/JKChange.aspx?Action=add", $('#form1').serialize(), "mobile/html/JKList.aspx");
        }
    }
</script>
