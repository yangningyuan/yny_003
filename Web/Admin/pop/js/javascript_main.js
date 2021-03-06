﻿function changetabcolor(title) {
    //if (title)
    	$("#mempay").prepend("<div class=\"alert alert-danger\" id='divtitle' style='margin-bottom:0px; margin-top:50px; '><strong>" + title + "</strong></div>");
    $("#finance").find("table").addClass('table table-bordered table-striped table-white');
    $("#mempay .control").addClass('alert');
    $("#mempay .control .pay").addClass('btn btn-success');
    $("#mempay .control .select").find("a").addClass('btn btn-primary btn-stroke');
    $("#mempay .control .search").find(".ssubmit").addClass('btn btn-danger');
    $("#mempay .control .cheeckbox table").find("td").css('padding-right', '5px');
    $("#mempay").find(".ui_table").find("table").addClass(' table table-bordered table-hover').css("background-color", "rgb(252, 252, 252)");
    $("#mempay").find(".ui_table").find("th").css('background-color', '#c72a25').css('color', '#FFFFFF');
    $("#finance").find(".normal_btnok").addClass('btn btn-success');
    $(".ui_table_control .pn").find("a").addClass('btn btn-warning');

    CheckplaceholderSupport();
    //    convertLanguage(true);
}

function CheckplaceholderSupport() {
    if (!placeholderSupport()) {   // 判断浏览器是否支持 placeholder
        $('[placeholder]').focus(function () {
            var input = $(this);
            if (input.val() == input.attr('placeholder')) {
                input.val('');
                input.removeClass('placeholder');
            }
        }).blur(function () {
            var input = $(this);
            if (input.val() == '' || input.val() == input.attr('placeholder')) {
                input.addClass('placeholder');
                input.val(input.attr('placeholder'));
            }
        }).blur();
    };
}

function placeholderSupport() {
    return 'placeholder' in document.createElement('input');
}

function callhtml(url, title) {
    cur_pageIndex = 0;
    if (url.indexOf("?") > -1)
        url += "&r=" + Math.random();
    else
        url += "?r=" + Math.random();
    //if (RunAjaxGetKey('VerifyUrl', url) == 'TRUE') {
    //    verifypsd(function () {
    //        setTimeout(function () { $("#main-content").load(url, function () { changetabcolor(title); }); }, 10);
    //    });
    //}
    //else {
        setTimeout(function () { $("#main-content").load(url, function () { changetabcolor(title); }); }, 10);
    //}
}

function checkForm() {
    var result = true;
    $("[require-type]").each(function () {
        var rtype = $(this).attr("require-type");
        var rMsg = $(this).attr("require-msg");
        if (typeof (rMsg) == 'undefined') {
            rMsg = '';
        }
        var value = $.trim($(this).val());
        if (rtype == "int") {
            if (!(/(^\d+$)/.test(value)) || value < 0) {
                v5.error(rMsg + '：只能输入正整数', '1', 'true');
                result = false;
                $(this).focus();
                return false;
            }
        }
        if (rtype == "decimal") {
            if (!$.isNumeric(value)) {
                v5.error(rMsg + '：只能输入数字', '1', 'true');
                result = false;
                $(this).focus();
                return false;
            }
        }
        if (rtype == "require") {
            if (value == '') {
                v5.error(rMsg + '：不能为空', '1', 'true');
                result = false;
                $(this).focus();
                return false;
            }
        }
    });
    return result;
}

 
