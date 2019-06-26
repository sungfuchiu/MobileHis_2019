$.ajaxSetup({
    cache: false,
    statusCode: {
        401: function () {
            window.location.href = "/LogOn/";
        }
    }
});

AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
    return data;
};

function popupwindow(url, title, w, h) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    return window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}

function doAjax(url, data, callback) {
    $.ajax({
        url: url,
        type: "post",
        data: AddAntiForgeryToken(data),
        success: function (result) {
            
            callback(result);
        },
        error: function () {
           
            alert("Unauthorized");
        }
    });
}

function SetNavCookie(key) {
    $.cookie("NavCookie", key, { path: '/', expires: 365 });
}

function setIntro(o) {
    $.cookie("intro-cookie", $(o).prop('checked'), { path: '/', expires: 365 });    
}


    function createAutoClosingAlert(selector, delay, v) {
        $(selector + " p").text(v);
        $(selector).fadeIn('slow');
        window.setTimeout(function () { $(selector).fadeOut('hide'); }, delay);
    }


    jQuery(document).ready(function ($) {
        if ($.cookie("sysLang")) {      
            $("#lng").val($.cookie("sysLang"));
        }
        else {
            $.cookie("sysLang", $("#lng").val(), { path: '/', expires: 365 });
        }

        $('.pager> a').each(function (i, item) {
            var page = getURLParameter($(item).attr('href'), "page");
            $(item).attr('href', '#').click(function () {
                $('<input>')
                .attr({ type: 'hidden', id: 'page', name: 'page', value: page })
                .appendTo($('form'));
                $('form').submit();
            });
        });

        function getURLParameter(url, name) {
            return decodeURI(
                (RegExp(name + '=' + '(.+?)(&|$)').exec(url) || [, null])[1]
            );
        }

        $("#lng").change(function () {

            $.cookie("sysLang", $(this).val(), { path: '/', expires: 365 });
            location.reload();
        });


    });

    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
              ? args[number]
              : ""
            ;
        });
    }
   
    function HanldSessionStage() {

        this.set = function (key, val) {
            if (key && typeof key == 'string') {
                if (!sessionStorage.getItem(key)) {
                    sessionStorage.setItem(key, val);
                }
            }
        }
        this.get = function (key) {
            if (key && typeof key == 'string') {
                return sessionStorage.getItem(key);
            }
            else {
                return null;
            }
        }
        this.remove = function (key) {
            if (key && typeof key == 'string') {
                sessionStorage.removeItem(key);
            }
        }
       
    }
    function getUrlVars(url) {
        var vars = [], hash;
        var hashes = url.substring(url.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    }


   
    
