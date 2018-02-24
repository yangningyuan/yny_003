<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerCar.aspx.cs" Inherits="yny_003.Web.mobile.html.VerCar" %>

<div class="content content-padded">
    <div class="list-block myinfo">
        <form id="form1">
            <input type="hidden" id="bankauto" runat="server" />
            <ul>
                <!-- Text inputs -->
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">主司机</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtSIJI1" id="txtSIJI1" runat="server" placeholder="主司机" readonly >
                            </div>
                        </div>
                    </div>
                </li>
                 <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">副司机</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtSIJI2" id="txtSIJI2" runat="server" placeholder="副司机"  readonly>
                            </div>
                        </div>
                    </div>
                </li>

                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">车辆牌照</div>
                            <div class="item-input">
                                <input type="text" value="" name="txtCarCode" id="txtCarCode" runat="server"  placeholder="请输入车辆牌照" >
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="item-content">
                        <div class="item-inner">
                            <div class="item-title label">确认车辆里程</div>
                            <div class="item-input">
                                 <input type="text" value="" name="txtMileage" id="txtMileage" runat="server"  placeholder="请输入车辆里程" >
                            </div>
                        </div>
                    </div>
                </li>
               
            </ul>
        </form>
    </div>
    <div class="content-block">
        <div class="row">
            <div class="col-100" id="btnhtml" runat="server">
                <a href="javascript:checkChange();" class="button button-big button-fill button-success">确认</a>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function checkChange() {
        if ($('#txtCarCode').val().trim() == "") {
            layer.msg("车辆牌照不能为空");
            return;
        } else if ($('#txtMileage').val().trim() == "") {
            layer.msg("里程不能为空");
            return;
        } else {
            ActionModel("mobile/html/VerCar.aspx?Action=add", $('#form1').serialize(), "mobile/html/VerCar.aspx");
        }
    }
</script>