

function RunAjaxByListEPBuy(state, ajaxKey, keys) {
    $.ajax({
        type: 'post',
        url: "/EP/Handler/Ajax.ashx",
        data: { type: "EPvalid", id: keys, pwd: "" },
        success: function (info) {
            if (info != "1") {
                v5.error(info, '1', 'true');
            } else {
                verifypsd(function () {
                    var data = RunAjaxGetKey(ajaxKey, keys, null, null, "/EP/Handler/Ajax.ashx");
                    PageLoad();
                    v5.alert(data, '1', 'true');
                });
            }
        }
    });
}

function RunAjaxByListEP(state, ajaxKey, keys) {
    verifypsd(function () {
        var data = RunAjaxGetKey(ajaxKey, keys, null, null, "/EP/Handler/Ajax.ashx");
        PageLoad();
        v5.alert(data, '1', 'true');
    });
}