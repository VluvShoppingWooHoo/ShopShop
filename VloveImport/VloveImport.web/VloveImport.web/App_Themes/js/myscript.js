
function showDialog(msg) {
    $("#windowMessage2").html(msg + '<br><center><a onclick=\"closeDialog()\" class=\"k-button\" style=\"text-decoration:none;padding:1px 20px;margin-top:25px;\">OK</a></center>');
    $("#windowMessage").data("kendoWindow").center().open();
}

function closeDialog() {
    $("#windowMessage").data("kendoWindow").close();
    //e.focus();
}


function txtWithcomma_onkeydown(e) {
    //debugger
    var key = e.keyCode || e.charCode;

    var nameContorl = '#' + e.currentTarget.id.toString();
    var valueContorl = e.currentTarget.value.replace(/,/g, '');

    var x = e.currentTarget.value.length;
    var y = valueContorl.length;
    var pos = doGetCaretPosition(e.currentTarget.id);

    if (key == 8 || key == 46) {
        if (key == 8) {
            var str = e.currentTarget.value;
            var res = str.charAt((pos - 1))

            tmpPosition = pos;
            charBackSpace = res;
            charBackSpaceLenght = x;
        }

        if (key == 46) {
            var str = e.currentTarget.value;
            var res = str.charAt(pos)

            tmpPosition = pos;
            charDelete = res;
            charDeleteLenght = x;
        }
    }
}
function txtWithcomma_onkeyup(e) {
    //debugger
    var nameContorl = '#' + e.currentTarget.id.toString();
    var valueContorl = e.currentTarget.value.replace(/,/g, '');

    var chk = parseInt(valueContorl.toString(), 10);
    if (isNaN(chk)) {
        $(nameContorl).val('');
        return;
    }

    var key = e.keyCode || e.charCode;

    if (key == 46) {
        if ((charDeleteLenght - e.currentTarget.value.length) == 1) {
            valueContorl = valueContorl.replace(/,/g, '');
            if (key == 46) {
                if (charDelete == ',') {
                    if ((e.currentTarget.value.length > 7) && ((e.currentTarget.value.length - tmpPosition) <= 3)) {
                        valueContorl = valueContorl.substring(0, tmpPosition - 1) + valueContorl.substring(tmpPosition);
                    }
                    else {
                        valueContorl = valueContorl.substring(0, tmpPosition) + valueContorl.substring(tmpPosition + 1);
                    }

                    var x = valueContorl.replace(/\B(?=(\d{3})+(?!\d))/g, ",").length;
                    if ((x > 3) && (x != 7)) {
                        tmpPosition = tmpPosition + 1;
                    }
                }
                else {
                    if ((e.currentTarget.value.length == 8) || (e.currentTarget.value.length == 4)) {
                        tmpPosition = tmpPosition - 1;
                    }
                }
            }

            $(nameContorl).val(valueContorl.replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            setCaretPosition(e.currentTarget.id, tmpPosition);
        }
        else {
            valueContorl = valueContorl.replace(/,/g, '');
            $(nameContorl).val(valueContorl.replace(/\B(?=(\d{3})+(?!\d))/g, ","));
        }
    }
    else if (key == 8) {
        if ((charBackSpaceLenght - e.currentTarget.value.length) == 1) {
            valueContorl = valueContorl.replace(/,/g, '');
            if (key == 8) {
                if (charBackSpace == ',') {
                    if ((e.currentTarget.value.length > 7) && ((e.currentTarget.value.length - tmpPosition) <= 3)) {
                        valueContorl = valueContorl.substring(0, tmpPosition - 3) + valueContorl.substring(tmpPosition - 2);
                    }
                    else {
                        valueContorl = valueContorl.substring(0, tmpPosition - 2) + valueContorl.substring(tmpPosition - 1);
                    }

                    var x = valueContorl.replace(/\B(?=(\d{3})+(?!\d))/g, ",").length;
                    if ((x > 3) && (x != 7)) {
                        tmpPosition = tmpPosition - 2;
                    }
                    else {
                        tmpPosition = tmpPosition - 3;
                    }
                }
                else {
                    if ((e.currentTarget.value.length == 8) || (e.currentTarget.value.length == 4)) {
                        tmpPosition = tmpPosition - 2;
                    }
                    else {
                        tmpPosition = tmpPosition - 1;
                    }
                }
            }

            $(nameContorl).val(valueContorl.replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            setCaretPosition(e.currentTarget.id, tmpPosition);
        } else {
            valueContorl = valueContorl.replace(/,/g, '');
            $(nameContorl).val(valueContorl.replace(/\B(?=(\d{3})+(?!\d))/g, ","));
        }
    }
    else {
        var x = e.currentTarget.value.length;
        var y = valueContorl.replace(/\B(?=(\d{3})+(?!\d))/g, ",").length;
        var pos = doGetCaretPosition(e.currentTarget.id);


        pos = pos + (y - x);
        $(nameContorl).val(valueContorl.replace(/\B(?=(\d{3})+(?!\d))/g, ","));
        setCaretPosition(e.currentTarget.id, pos);
    }
}
function txtWithcomma_onblur(e) {
    debugger
    var nameContorl = '#' + e.currentTarget.id.toString();
    var valueContorl = e.currentTarget.value.replace(/,/g, '');

    //var chk = parseFloat(valueContorl.toString(), 10).toFixed(2);
    var chk = valueContorl.toString();
    if (isNaN(chk)) {
        $(nameContorl).val('');
        return;
    }
    else {
        $(nameContorl).val(chk.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
    }
}
function txtWithcomma_onblurnonedecimal(e) {
    debugger
    var nameContorl = '#' + e.currentTarget.id.toString();
    var valueContorl = e.currentTarget.value.replace(/,/g, '');

    var chk = parseInt(valueContorl.toString(), 10);
    if (isNaN(chk)) {
        $(nameContorl).val('');
        return;
    }
    else {
        $(nameContorl).val(chk.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
    }
}

function doGetCaretPosition(ctrlid) {
    //debugger;
    var ctrl = document.getElementById(ctrlid);
    var CaretPos = 0; // IE Support
    if (document.selection) {
        ctrl.focus();
        var Sel = document.selection.createRange();
        Sel.moveStart('character', -ctrl.value.length);
        CaretPos = Sel.text.length;
    }
        // Firefox support
    else if (ctrl.selectionStart || ctrl.selectionStart == '0')
        CaretPos = ctrl.selectionStart;
    return CaretPos;
}
function setCaretPosition(ctrlid, pos) {
    //debugger;
    var ctrl = document.getElementById(ctrlid);
    if (ctrl.setSelectionRange) {
        ctrl.focus();
        ctrl.setSelectionRange(pos, pos);
    }
    else if (ctrl.createTextRange) {
        var range = ctrl.createTextRange();
        range.collapse(true);
        range.moveEnd('character', pos);
        range.moveStart('character', pos);
        range.select();
    }
}
function numberFormat() {

    //
    $("input.numberFormatNegs").each(function () {
        var val = $(this).val().replace(/\,/g, '');
        if (val < 0) {
            $(this).addClass("text-red");
        }
        else {
            $(this).removeClass("text-red");
        }
    });

    //$(".numberFormatDisplay").ready(function () {
    //    $(".numberFormatDisplay").html((parseFloat($(".numberFormatDisplay").html())).toFixed(2));
    //    $(".numberFormatDisplay").html(addCommas($(".numberFormatDisplay").html()));
    //});
    $("div.numberFormat").each(function (index) {
        try {
            $(this).html((parseFloat($(this).html().replace(new RegExp(",", "g"), ""))).toFixed(2));
            if (isNaN($(this).html())) {
                $(this).html("");
            }
            else {
                if ($(this).html() >= 0) {
                    $(this).html(addCommas($(this).html()));
                }
                else {
                    $(this).html("");
                }
            }
        }
        catch (ex) { $(this).html(""); }
    });
    $("td.numberFormat").each(function (index) {
        try {
            $(this).html((parseFloat($(this).html().replace(new RegExp(",", "g"), ""))).toFixed(2));
            if (isNaN($(this).html())) {
                $(this).html("");
            }
            else {
                if ($(this).html() >= 0) {
                    $(this).html(addCommas($(this).html()));
                }
                else {
                    $(this).html("");
                }
            }
        }
        catch (ex) { $(this).html(""); }
    });
    $("span.numberFormat").each(function (index) {
        try {
            if ($(this).text() != "") {
                var x = BigNumber($(this).text().replace(new RegExp(",", "g"), ""));
                $(this).text(x.toFixed(2));
                if (isNaN($(this).text())) {
                    $(this).text("");
                }
                else {
                    if ($(this).text() >= 0) {
                        $(this).text(addCommas($(this).text()));
                    }
                    else {
                        $(this).text("");
                    }
                }
            }
        }
        catch (ex) {
            $(this).html("");
        }
    });
    $("span.numberFormats").each(function (index) {
        try {
            $(this).html((parseFloat($(this).html().replace(new RegExp(",", "g"), ""))).toFixed(2));
            if (isNaN($(this).html())) {
                $(this).html("");
            }
            else {
                if ($(this).html() >= 0 || $(this).html() < 0) {
                    if ($(this).html() < 0) {
                        $(this).addClass("text-red");
                    }
                    $(this).html(addCommas($(this).html()));
                }
                else {
                    $(this).html("");
                }
            }
        }
        catch (ex) { $(this).html(""); }
    });

    $("span.numberFormatsPercentage").each(function () {
        var val_linked = $(this).html();
        var val_not_linked = val_linked.replace("%", "").replace(/\,/g, '');
        if (val_not_linked >= 0 || val_not_linked < 0) {
            if (val_not_linked < 0) {
                $(this).addClass("text-red");
            }
        }
    });

    $("span.numberFormatNone").keypress(function (evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    });
    $("span.numberFormatNoneDecimal").each(function (index) {
        try {
            if ($(this).html().indexOf(".") == -1) {
                $(this).html((parseInt($(this).html().replace(new RegExp(",", "g"), ""))));
                if (isNaN($(this).html())) {
                    $(this).html("");
                }
                else {
                    if ($(this).html() >= 0) {
                        $(this).html(addCommas($(this).html()));
                    }
                    else {
                        $(this).html("");
                    }
                }
            }
            else {
                $(this).html("");
            }
        }
        catch (ex) { $(this).html(""); }
    });
    //$(".numberFormat").ready(function () {
    //    $(".numberFormat").val((parseFloat($(".numberFormat").val().replace(new RegExp(",", "g"), ""))).toFixed(2));
    //    $(".numberFormat").val(addCommas($(".numberFormat").val()));
    //});
    //$(".numberFormat").ready(function () {
    //    $(this).val((parseFloat($(this).val().replace(new RegExp(",", "g"), ""))).toFixed(2));
    //    $(this).val(addCommas($(this).val()));
    //});
    $(".numberFormat").each(function (index) {
        try {
            if ($(this).val() != "") {
                var x = BigNumber($(this).val().replace(new RegExp(",", "g"), ""));
                $(this).val(x.toFixed(2));
                if (isNaN($(this).val())) {
                    $(this).val("");
                }
                else {
                    if ($(this).val() >= 0) {
                        $(this).val(addCommas($(this).val()));
                    }
                    else {
                        $(this).val("");
                    }
                }
            }
        }
        catch (ex) { $(this).val(""); }
    });
    $(".numberFormats").each(function (index) {
        try {
            $(this).val((parseFloat($(this).val().replace(new RegExp(",", "g"), ""))).toFixed(2));
            if (isNaN($(this).val())) {
                $(this).val("");
            }
            else {
                if ($(this).val() >= 0 || $(this).val() < 0) {
                    //$(this).val(addCommas($(this).val()));
                }
                else {
                    $(this).val("");
                }
            }
        }
        catch (ex) { $(this).val(""); }
    });

    $(".numberFormatNoneDecimal").each(function (index) {
        try {
            if ($(this).val().indexOf(".") == -1) {
                $(this).val(parseInt($(this).val().replace(new RegExp(",", "g"), "")));
                if (isNaN($(this).val())) {
                    $(this).val("");
                }
                else {
                    if ($(this).val() >= 0) {
                        $(this).val(addCommas($(this).val()));
                    }
                    else {
                        $(this).val("");
                    }
                }
            }
            else {
                $(this).val("");
            }
        }
        catch (ex) { $(this).val(""); }
    });
    $(".numberFormat").keypress(function (evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    });
    $(".numberFormats").keypress(function (evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode != 45 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    });

    $(".numberFormatNegs").keypress(function (evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode != 45 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    });

    $(".numberFormatNegs").keyup(function (evt) {
        var obj = $(this);
        var val = obj.val().replace(/\,/g, '');
        var i = filterInt(val);

        if (isNaN(i)) {
            var lChar = val.substr(val.length - 1, val.length);
            var bVal = val.substr(0, val.length - 1);
            if (val.length != 1 && val != "-") {
                var bVal = val.substr(0, val.length - 1);
                if (lChar == ".") {
                    var j = filterInt(bVal);
                    if (val.split(".").length > 2 || isNaN(j)) {
                        val = bVal;
                    }
                } else {
                    val = bVal;
                }
            } else if (val == ".") {
                val = bVal;
            }
        } else {
            val = i;
        }
        obj.val(numberWithCommas(val));
        if (val < 0) {
            $(this).addClass("text-red");
        }
        else {
            $(this).removeClass("text-red");
        }
    });

    $(".numberFormatPos").keypress(function (evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    });

    $(".numberFormatPos").keyup(function (evt) {
        var obj = $(this);
        var val = obj.val().replace(/\,/g, '');
        var i = filterInt(val);

        if (isNaN(i)) {
            var lChar = val.substr(val.length - 1, val.length);
            var bVal = val.substr(0, val.length - 1);
            if (val.length != 1 && val != "-") {
                var bVal = val.substr(0, val.length - 1);
                if (lChar == ".") {
                    var j = filterInt(bVal);
                    if (val.split(".").length > 2 || isNaN(j)) {
                        val = bVal;
                    }
                } else {
                    val = bVal;
                }
            } else if (val == ".") {
                val = bVal;
            }
        } else {
            val = i;
        }
        obj.val(numberWithCommas(val));
    });

    $(".numberFormatNone").keypress(function (evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    });

    $(".numberFormatNegs, .numberFormatPos").blur(function () {
        var val = $.trim($(this).val().replace(/\,/g, ''));
        if (val != '') {
            $(this).val(numberWithCommas(parseFloat(Math.round(val * 100) / 100).toFixed(2)));
            if (val < 0) {
                $(this).addClass("text-red");
            }
            else {
                $(this).removeClass("text-red");
            }
        }
    });

    $(".numberFormatNoneDecimal").keypress(function (evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    });
    $(".numberFormat").focusout(function () {
        try {
            if ($(this).val() != "") {
                var x = BigNumber($(this).val().replace(new RegExp(",", "g"), ""));
                $(this).val(x.toFixed(2));
                if (isNaN($(this).val())) {
                    $(this).val("");
                }
                else {
                    if ($(this).val() >= 0) {
                        $(this).val(addCommas($(this).val()));
                    }
                    else {
                        $(this).val("");
                    }
                }
            }
        }
        catch (ex) { $(this).val(""); }
    });
    $(".numberFormatNoneDecimal").focusout(function () {
        try {
            if ($(this).val().indexOf(".") == -1) {
                $(this).val(parseFloat($(this).val().replace(new RegExp(",", "g"), "")));
                if (isNaN($(this).val())) {
                    $(this).val("");
                }
                else {
                    if ($(this).val() >= 0) {
                        $(this).val(addCommas($(this).val()));
                    }
                    else {
                        $(this).val("");
                    }
                }
            }
            else {
                $(this).val("");
            }
        }
        catch (ex) { $(this).val(""); }
    });
}

function maxLenght() {

    $("textarea.maxlength1000").keypress(function (evt) {
        debugger;
        if (this.value.length >= 1000) {
            return false;
        }
    });

    $("textarea.maxlength5000").keypress(function (evt) {
        debugger;
        if (this.value.length >= 5000) {
            return false;
        }
    });
}

window.repositions = function (params) {
    switch (params) {
        case "bootbox":
            var _top = ($(window).height() - $('.bootbox').find('.modal-dialog').outerHeight()) / 2;
            $('.bootbox').find('.modal-dialog').css({
                'margin-top': function () {
                    return _top;
                }
            });
            break;
    }
}

filterInt = function (value) {
    //if (/^(\-|\+)?([0-9]+|Infinity)^((\.)?(([0-9]+|Infinity)))$/.test(value))
    //return Number(value);
    if (/^-?\d+(.\d+)?$/.test(value))
        return value;
    return NaN;
}

function numberWithCommas(x) {
    var parts = x.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
}

function showDialogErrorMessage(panel_id, html_list_err_msg, msg) {
    //debugger;
    //$("#windowMessage2").html(msg + '<br><center><a onclick=\"closeDialog()\" class=\"k-button\" style=\"text-decoration:none;padding:1px 20px;margin-top:25px;\">OK</a></center>');
    //$("#windowMessage").data("kendoWindow").center().open();
    //$.error(msg);

    showFeedback("error", msg);
    if (html_list_err_msg != undefined && html_list_err_msg.length > 0 && panel_id != undefined) {
        var html_li = "";
        for (var i = 0; i < html_list_err_msg.length; i++) {
            html_li += "<li>" + html_list_err_msg[i] + "</li>";
        }
        $("#" + panel_id + " .error_details").html("<div class='alert alert-danger alert-dismissable'><ul>" + html_li + "</ul></div>");
    }

}

function showPanelErrorMessage(panel_id, html_list_err_msg) {
    if (html_list_err_msg != undefined && html_list_err_msg.length > 0 && panel_id != undefined) {
        var html_li = "";
        for (var i = 0; i < html_list_err_msg.length; i++) {
            html_li += "<li>" + html_list_err_msg[i] + "</li>";
        }
        $("#" + panel_id + " .error_details").html("<div class='alert alert-danger alert-dismissable'><ul>" + html_li + "</ul></div>");
    }
}
function clearPanelErrorMessage(panel_id) {
    $("#" + panel_id + " .error_details").html("");
}
function clearAllPanelErrorMessage() {
    $(" .error_details").html("");
}
function addExtensionClass(extension) {
    switch (extension) {
        case '.jpg':
            return "jpg-file";
        case '.png':
        case '.img':
        case '.gif':
            return "png-file";
        case '.doc':
        case '.docx':
            return "doc-file";
        case '.xls':
        case '.xlsx':
            return "xls-file";
        case '.pdf':
            return "pdf-file";
        case '.zip':
        case '.rar':
            return "zip-file";
        default:
            return "default-file";
    }
}

function returnClass(panel, e) {
    if (e.className == "toggle-up") {
        $(panel).removeClass(e.className);
        $(panel).addClass("toggle-down");
    }
    else {
        $(panel).removeClass(e.className);
        $(panel).addClass("toggle-up");
    }
}

function toggle(e) {
    var panel = "#"
    var id = e.id.split('_');
    if (id[1] != undefined)
        panel += id[1];
    $(panel).toggle();
    panel = "#_" + id[1];
    returnClass(panel, e);
}

function validateEmail(str) {
    var index_at = str.indexOf('@')
    if (index_at == -1) {
        return false;
    }

    var name = str.substr(0, index_at);
    /* should test name for other invalids*/

    var domain = str.substr(index_at + 1);
    /* should check for extra "@" and any other checks that would invalidate an address of which there are likely many*/
    if (domain.indexOf('@') != -1) {
        return false;
    }
    return domain.indexOf('.') > 1;
}
function SetPermission(commponentName, isEnable, isReadOnly, tabDetail) {
    //alert("1123");
    //debugger;
    var element = $("div[id='" + tabDetail + "']").find("[permission*='" + commponentName + "']");
    //var element = $("[permission*='" + commponentName + "']");
    if (element.length > 0) {

        element.each(function (index, elem) {
            //debugger
            var jqueryElement = $("#" + elem.id);
            if (jqueryElement.length > 0) {
                //debugger
                //alert(jqueryElement[0].dataset);
                if (jqueryElement.data("kendoNumericTextBox") != undefined && jqueryElement.data("kendoNumericTextBox") != null) {
                    if (isEnable == "False") {
                        //hide
                        jqueryElement.data("kendoNumericTextBox").wrapper.hide();
                    }
                    else {
                        if (isReadOnly == "True") {
                            //disabled
                            jqueryElement.data("kendoNumericTextBox").enable(false);
                        }
                    }
                }
                else if (jqueryElement.data("kendoDropdownlist") != undefined && jqueryElement.data("kendoDropdownlist") != null) {
                    if (isEnable == "False") {
                        //hide
                        jqueryElement.data("kendoDropdownlist").wrapper.hide();
                    }
                    else {
                        if (isReadOnly == "True") {
                            //disabled
                            jqueryElement.data("kendoDropdownlist").enable(false);
                        }
                    }
                }

                else {
                    if (isEnable == "False") {
                        jqueryElement.hide();
                    }
                }
            }
        });
    }
}

function ValidateSavePanel(validateModel) {
    var i = 0;
    var result = true;
    for (i = 0; i < validateModel.length; i++) {

        var id = validateModel[i].id;
        var name = validateModel[i].name;
        var isRequired = validateModel[i].required;
        var value = "";
        //debugger

        if ($("#" + id).closest('.k-dropdown') != undefined &&
                $("#" + id).closest('.k-dropdown').length > 0) {
            value = $("#" + id).data('kendoDropDownList').value();
        } else {
            value = $("#" + id).val();
        }

        if (isRequired && $.trim(value) == "") {
            $("#validatefor-" + id).text(name + " is required.");
            $("#validatefor-" + id).css("font-size", "80%");

            if ($("#" + id).closest('.k-dropdown') != undefined &&
                $("#" + id).closest('.k-dropdown').length > 0) {
                $("#" + id).closest('.k-dropdown').addClass("input-validation-error");
            } else if ($("#" + id).closest('.k-numerictextbox') != undefined &&
                $("#" + id).closest('.k-numerictextbox').length > 0) {
                $("#" + id).closest('.k-numerictextbox').addClass("input-validation-error");
            } else {
                $("#" + id).addClass("input-validation-error");
            }

            //if ($("#" + id)[0].dataset.role == "numerictextbox" ||
            //    $("#" + id)[0].dataset.role == "dropdownlist") {

            //    // $("#" + id).parent().attr("style", "border: 1px solid #e80c4d");
            //}
            result = false;
        }
        else
            $("#validatefor-" + id).text('');
    }
    return result;
}

function onRowBound(e) {
    $(".k-grid-save-changes").removeClass("k-button");
    $(".k-grid-save-changes").addClass("btn btn-success");
    $(".k-grid-Edit").removeAttr("href");
    $(".k-grid-Remove").removeAttr("href");
    $(".k-grid-View").removeAttr("href");
    $(".k-grid-Add").removeAttr("href");
    $(".k-grid-Shared").removeAttr("href");
    $(".k-grid-RemoveBase").removeAttr("href");
    $(".k-grid-Select").removeAttr("href");
    $(".k-grid-Import").removeAttr("href");

    $(".k-grid-save-changes").html("<i class=\"fa fa-check\"></i>Save");
    $(".k-grid-Edit").html("<i class=\"fa fa-pencil-square-o\"></i>");
    $(".k-grid-Delete").html("<i class=\"fa fa-times\"></i>");
    $(".k-grid-Remove").html("<i class=\"fa fa-times\"></i>");
    $(".k-grid-View").html("<i class=\"fa fa-eye\"></i>");
    $(".k-grid-Add").html("<i class=\"fa fa-pencil\"></i>");
    $(".k-grid-Shared").html("<i class=\"fa fa-external-link\"></i>");
    $(".k-grid-RemoveBase").html("<i class=\"fa fa-trash-o\"></i>");
    $(".k-grid-Select").html("<i class=\"fa fa-check\"></i>");
    $(".k-grid-Import").html("<i class=\"fa fa-download\"></i>");

    $(".k-grid-Edit").addClass("btnEdit");
    $(".k-grid-Shared").addClass("btnEdit");
    $(".k-grid-Select").addClass("btnSearch");
    $(".k-grid-save-changes").addClass("btnEdit");

    $(".k-grid-Delete").addClass("btnDelete");
    $(".k-grid-Remove").addClass("btnDelete");
    $(".k-grid-RemoveBase").addClass("btnDelete");

    $(".k-grid-Add").addClass("btnAdd");

    $(".k-grid-View").addClass("btnView");

    $(".k-grid-Import").addClass("btnImport");

    //checkPermission(true);
}


function OnRowIconDataBound(e) {
    //debugger
    e.sender.element.find(".k-button.k-button-icontext.k-grid-View").find("span").addClass("fa fa-eye");
    e.sender.element.find(".k-button.k-button-icontext.k-grid-View")
        .removeClass("k-button k-button-icontext").addClass("btn btn-default btn-sm i-gap-right-xs view-only");


    e.sender.element.find(".k-button.k-button-icontext.k-grid-Download").find("span").addClass("fa fa-eye");
    e.sender.element.find(".k-button.k-button-icontext.k-grid-Download")
        .removeClass("k-button k-button-icontext").addClass("btn btn-default btn-sm i-gap-right-xs");

    //e.sender.element.find(".k-grid-View").find("span").addClass("k-icon k-i-restore");
    //e.sender.element.find(".k-grid-View").find("span").parent().addClass("tooltip");
    //e.sender.element.find(".k-grid-View").find("span").parent().attr("title", "View");

    //e.sender.element.find(".k-button.k-button-icontext.k-grid-Edit").each(function (i, e) {
    //    $('#' + this.id).removeClass("k-button").addClass("k-icon k-edit");
    //});

    e.sender.element.find(".k-button.k-button-icontext.k-grid-Edit").find("span").addClass("fa fa-pencil");
    e.sender.element.find(".k-button.k-button-icontext.k-grid-Edit")
        .removeClass("k-button k-button-icontext").addClass("btn btn-default btn-sm i-gap-right-xs");

    e.sender.element.find(".k-button.k-button-icontext.k-grid-BA").find("span").addClass("fa fa-plus");
    e.sender.element.find(".k-button.k-button-icontext.k-grid-BA")
        .removeClass("k-button k-button-icontext").addClass("btn btn-default btn-sm i-gap-right-xs");
    //e.sender.element.find(".k-button.k-button-icontext.k-grid-Edit").find("span").addClass("k-icon k-edit");
    //e.sender.element.find(".k-grid-Edit").find("span").parent().addClass("tooltip");
    //e.sender.element.find(".k-grid-Edit").find("span").parent().attr("title", "Edit");

    e.sender.element.find(".k-button.k-button-icontext.k-grid-Delete").find("span").addClass("fa fa-trash-o");
    e.sender.element.find(".k-button.k-button-icontext.k-grid-Delete")
        .removeClass("k-button k-button-icontext").addClass("btn btn-default btn-sm i-gap-right-xs");

    //e.sender.element.find(".k-grid-Delete").find("span").addClass("k-icon k-cancel");
    //e.sender.element.find(".k-grid-Delete").find("span").parent().addClass("tooltip");
    //e.sender.element.find(".k-grid-Delete").find("span").parent().attr("title", "Delete");

    e.sender.element.find(".k-grid-MoreDetail").find("span").addClass("k-icon k-i-restore");
    //e.sender.element.find(".k-grid-MoreDetail").find("span").parent().addClass("tooltip");
    //e.sender.element.find(".k-grid-MoreDetail").find("span").parent().attr("title", "More Detail");

    e.sender.element.find(".k-grid-History").find("span").addClass("fa fa-clock-o");
    e.sender.element.find(".k-button.k-button-icontext.k-grid-History")
        .removeClass("k-button k-button-icontext").addClass("btn btn-default btn-sm i-gap-right-xs");
    //e.sender.element.find(".k-grid-History").find("span").parent().addClass("tooltip");
    //e.sender.element.find(".k-grid-History").find("span").parent().attr("title", "History");

    e.sender.element.find(".k-grid-NewBA").find("span").addClass("k-icon k-i-plus");
    //e.sender.element.find(".k-grid-NewBA").find("span").parent().addClass("tooltip");
    //e.sender.element.find(".k-grid-NewBA").find("span").parent().attr("title", "New BA");

    e.sender.element.find(".k-grid-Select").find("span").addClass("fa fa-check-square-o");
    e.sender.element.find(".k-button.k-button-icontext.k-grid-Select")
        .removeClass("k-button k-button-icontext").addClass("btn btn-default btn-sm i-gap-right-xs");
    //e.sender.element.find(".k-grid-Select").find("span").parent().addClass("tooltip");
    //e.sender.element.find(".k-grid-Select").find("span").parent().attr("title", "Select");

    $('.tooltip').tooltipster({
        animation: 'fade',
        delay: 200,
        theme: 'tooltipster-punk',
        touchDevices: false,
        trigger: 'hover'
    });
}


function IwfProgress() {

    var panelbodypage = $("#panelbodypage");

    this.Load = function () {
        kendo.ui.progress(panelbodypage, true);
    }

    this.LoadComplete = function () {
        kendo.ui.progress(panelbodypage, false);
    }
}

function PanelProgress(panelName) {

    var panelbodypage = $("#" + panelName + "");

    this.Load = function () {
        kendo.ui.progress(panelbodypage, true);
    }

    this.LoadComplete = function () {
        kendo.ui.progress(panelbodypage, false);
    }
}

/** script upload file **/
/* created by thanaprn 11/02/2014*/
var uploadFile = new UploadFileTemplate();

function UploadFileTemplate() {
    this.index = function (dataItem, gridID) {
        var data = $("#" + gridID).data("kendoGrid").dataSource.data();

        return data.indexOf(dataItem);
    }
    this.allowExtension = function (extension) {
        //switch (extension) {
        //    case '.jpg':
        //    case '.png':
        //    case '.gif':
        //    case '.doc':
        //    case '.docx':
        //    case '.xls':
        //    case '.xlsx':
        //    case '.pdf':
        //        return true;
        //    default:
        //        return false;
        //}
        return true;
    }
    this.onComplete = function (e) {
        //grid refresh
        //debugger
        var id_upload = this.element.attr("id");
        $("#grid_" + id_upload).data("kendoGrid").dataSource.read();
        $("#grid_" + id_upload).find("ul[class='k-upload-files k-reset']").remove();
        $("#grid_" + id_upload).find("button[class='k-button k-upload-selected']").remove();
        $("#grid_" + id_upload).find("input[type='file']")
        //showDialog("Upload Complete");
    }
    this.onError = function (e) {
        ////////console.log(e);
        ////////debugger;
        //////if (e.files.length > 0) {
        //////    //debugger
        //////    var filename = e.files[0].name;
        //////    //alert("");
        //////    //$.warning("File " + filename + " upload not support!");
        //////    //$.warning("File " + filename + " upload not support!");

        //////    showFeedback("warning", "ไม่สามารถ Upload file นี้ได้ เนื่องจากไฟล์เสีย,แนบไฟล์ไม่ถูกต้อง หรือไฟล์มีขนาดใหญ่เกินไป");
        //////    var id_upload = this.element.attr("id");

        //////    $("#grid_" + id_upload).find("li").find("div").each(function (index, element) {
        //////        if ($(element).attr("filename") == filename) {
        //////            $(element).parent().remove();
        //////        }
        //////    });
        //////    $("#grid_" + id_upload).find("strong").remove();

        //////}//$.warning(e.response.message);
    }
    this.onUpload = function (e) {
        //var files = e.files;
        //var waiting_process = "wait";
        ////debugger
        //$.each(files, function () {
        //    //debugger
        //    var extension = this.extension.toLowerCase();
        //    var size = this.size;
        //    var eObject = e;
        //    $.ajax({
        //        type: "POST",
        //        url: "/Upload/IsAllowFile",
        //        data: "{type:'" + extension + "',size:"+size+"}",
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (response) {
        //            //debugger
        //            var message_response = eval(response);
        //            if (message_response.response) {
        //                //$("#" + grid_id).data("kendoGrid").dataSource.read();
        //                //reload();
        //                waiting_process = "done";
        //            }
        //            else {
        //                //showDialog("ไม่สามารถลบข้อมูลได้");
        //                waiting_process = "done";
        //                alert(message_response.message);
        //                eObject.preventDefault();
        //            }

        //        },
        //        failure: function (msg) {
        //            //showDialog("ไม่สามารถลบข้อมูลได้");
        //            //$("#" + grid_id).data("kendoGrid").dataSource.read();

        //            waiting_process = "done";
        //            eObject.preventDefault();
        //        }
        //    });


        //    //if (!uploadFile.allowExtension(this.extension.toLowerCase())) {
        //        //showDialog("File upload not support!")
        //        //e.preventDefault();
        //    //}

        //    //else if (this.size / 1024 / 1024 > 5) {
        //        //showDialog("Max 5Mb file size is allowed!")
        //        //e.preventDefault();
        //    //}
        //});

        //var process_id = setInterval(function () {
        //    //debugger;
        //    if (waiting_process != "wait")
        //    {
        //        clearInterval(process_id);
        //    }
        //}, 1000);

    }

    this.onSelectUpload = function (e) {
        //debugger
        var grid_id = this.element.attr("id");
        if ($("#" + grid_id).find("ul[class='k-upload-files k-reset']").length == 0) {
            //send remove session
        }
    }
    this.onSuccess = function (e) {
        //e.preventDefault();
        //debugger
        if (e.response.status != undefined) {
            if (!e.response.status) {
                //$.warning(e.response.message);
                showFeedback("warning", e.response.message);
                //alert(e.response.message);
                //debugger
                var filename = e.response.filename;
                var id_upload = this.element.attr("id");

                $("#grid_" + id_upload).find("li").find("div").each(function (index, e) {
                    //debugger
                    if ($(e).attr("filename") == filename) {
                        $(e).parent().remove();
                    }
                });
                $("#grid_" + id_upload).find("strong").remove();
            }
        }
    }

    this.onUploadFileDelete = function (e) {
        if (confirm("ต้องการลบข้อมูลไฟล์นี้ ?")) {
            e.preventDefault();

            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            //alert(dataItem.ID);
            var grid_id = this.element.attr("id");

            $.ajax({
                type: "POST",
                url: "/Upload/Delete",
                data: "{data:" + dataItem.ID + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //debugger
                    if (response) {
                        $("#" + grid_id).data("kendoGrid").dataSource.read();
                        //reload();
                    }
                    else {
                        //$.error("ไม่สามารถลบข้อมูลได้");
                        showFeedback("error", "ไม่สามารถลบข้อมูลได้");
                    }

                },
                failure: function (msg) {
                    //$.error("ไม่สามารถลบข้อมูลได้");
                    showFeedback("error", "ไม่สามารถลบข้อมูลได้");
                    $("#" + grid_id).data("kendoGrid").dataSource.read();
                }
            });

            //$(this.element.attr("id")).data("kendoGrid");

            //var item = $("#"+this.element.attr("id")).data("kendoGrid").dataItem($(this).closest("tr"));
            //// item contains the item corresponding to clicked row
            //alert(item);
            //// If I want to remove the row...
            //$("#" + this.element.attr("id")).data("kendoGrid").removeRow($(this).closest("tr"));
            //$("#grid_" + id_upload).data("kendoGrid").dataSource.read();
        }
    }
}
/** end script upload **/
/** download file uri encode **/
function downloadFileByID(id, type) {
    $.fileDownload('/Workflows/DownloadFileID?id=' + id + '&type=' + type)
            .done(function () {
                //alert('File download a success!');
            })
            .fail(function () {
                alert("File not found can't download!");
            });
}
/*download file ใช้ตอน stage 1 service info*/
function downloadFile(filename, type) {
    //debugger
    //alert(filename + " " + type);
    //alert(encodeURIComponent(filename) + " " + type);
    //window.location = '/Workflows/DownloadFile?filename=' + encodeURIComponent(filename) + '&type=' + type;

    //$.fileDownload($(this).prop('href'), {
    //    preparingMessageHtml: "We are preparing your report, please wait...",
    //    failMessageHtml: "There was a problem generating your report, please try again."
    //});
    //return false;

    //this is critical to stop the click event which will trigger a normal file download!
    //alert('/Workflows/DownloadFile?filename=' + encodeURIComponent(filename) + '&type=' + type);
    //try{
    $.fileDownload('/Workflows/DownloadFile?filename=' + encodeURI(filename) + '&type=' + type)
        .done(function () {
            //alert('File download a success!');
        })
        .fail(function () {
            alert("File not found can't download!");
        });
    //}
    //catch (ex)
    //{
    //window.location = '/Workflows/DownloadFile?filename=' + encodeURIComponent(filename) + '&type=' + type;
    //}
    //return false;
}

/* begin workspace helper class */

function avoidNull(text) {
    try {
        if (text != null && text != -1 && text != '-1')
            return text;
    }
    catch (ex) {
        return "-";
    }
    return "-";
}
/* end workspace helper class */

var Loading;
Loading = Loading || (function () {
    return {
        show: function () {
            bootbox.dialog({
                message: "<div class='img-loading'></div>",
                isLoading: true
            });
            $(".modal-dialog").css("margin", "8% auto");
            $(".modal-content").removeClass("modal-content");
        },
        hide: function () {
            bootbox.hideAll();
        },

    };
})();

var Loading2;
Loading2 = Loading2 || (function () {
    return {
        show: function () {
            bootbox.dialog({
                message: "<div class='img-loading'></div>",
                isLoading: true
            });
            $(".bootbox .modal-dialog").css("margin", "8% auto");
            $(".bootbox .modal-dialog .modal-content").removeClass("modal-content");
        },
        hide: function () {
            bootbox.hideAll();
        },

    };
})();