

function updateGoodCarCount(carId, count) {
    var result = GetAjaxString('UpdateShopCar', carId + "&count=" + count, 'Shop/Handler/Ajax.ashx');
}

function numDesc(obj) {
    var oldNum = $(obj).next().val();
    if (parseInt(oldNum) != 1) {
        var newNum = parseInt(oldNum) - 1;
        $(obj).next().val(newNum);
        var price = parseFloat($.trim($(obj).parent().parent().find(".spSprice").text()));
        var totalMoney = newNum * price;
        $(obj).parent().parent().find(".spTotal").text(totalMoney.toFixed(2));
        $(obj).parent().parent().find(".spTotalDis").text((totalMoney * disc).toFixed(2));
        var cid = $.trim($(obj).parent().parent().find(".hidCId").val());
        updateGoodCarCount(cid, newNum);
    }
}

function numAsc(obj) {
    var oldNum = $(obj).prev().val();
    var newNum = parseInt(oldNum) + 1;
    $(obj).prev().val(newNum);
    var price = parseFloat($.trim($(obj).parent().parent().find(".spSprice").text()));
    var totalMoney = newNum * price;
    $(obj).parent().parent().find(".spTotal").text(totalMoney.toFixed(2));
    $(obj).parent().parent().find(".spTotalDis").text((totalMoney * disc).toFixed(2));
    var cid = $.trim($(obj).parent().parent().find(".hidCId").val());
    updateGoodCarCount(cid, newNum);
}

function RunAjaxByListShop(state, ajaxKey, joinKey, func) {
    if (cidList.length > 0) {
        if (state != '' && tState != state) {
            v5.error('操作无效', '1', 'true');
            return;
        }
        verifypsd(function () {
            var data = RunAjaxGetKey(ajaxKey, cidList.join(joinKey), null, null, 'Shop/Handler/Ajax.ashx');
            PageLoad();
            v5.alert(data, '1', 'true', func);
        });
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}

function RunAjaxByListAddKeyShop(state, ajaxKey, joinKey, otherParam, func) {
    if (cidList.length > 0) {
        if (ajaxKey != "DeleteMemberW") {
            if (state != '' && tState != state) {
                v5.error('操作无效', '1', 'true');
                return;
            }
        }
        verifypsd(function () {
            var data = RunAjaxGetKey(ajaxKey, cidList.join(joinKey) + "&otherParm=" + otherParam, null, null, 'Shop/Handler/Ajax.ashx');
            PageLoad();
            v5.alert(data, '1', 'true', func);
        });
    } else {
        v5.alert('请先选择行数据', '1', 'true');
    }
}