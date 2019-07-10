
//Object.prototype.addMethod = function (name, fn) {
//    if (!name || !fn)
//        return;
//    var old = this[name];
//    this[name] = function () {
//        var fncLen = fn.length,
//            argLen = arguments.length;
//        if (fncLen === argLen) {
//            return fn.apply(this, arguments);
//        } else if (typeof old === "function") {
//            return old.apply(this, arguments);
//        } else {
//            throw new Error("no " + name + " method with " + argLen + " param(s) defined!");
//        }
//    }
//};
const AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
    return data;
};


//function doAjax(url, data, callback) {
function doAjax() {
    let paramUrl;
    let paramData;
    let paramCallback;
    switch (arguments.length) {
        case 2:
            paramUrl = arguments[0];
            paramCallback = arguments[1];
            $.ajax({
                url: paramUrl,
                type: "GET",
                async: false,
                data: "",
                success: function (result) {
                    paramCallback(result);
                },
                error: function () {

                    alert("Unauthorized");
                }
            });
            break;
        case 3:
            paramUrl = arguments[0];
            paramData = arguments[1];
            paramCallback = arguments[2];
            $.ajax({
                url: paramUrl,
                type: "post",
                async: false,
                data: AddAntiForgeryToken(paramData),
                success: function (result) {
                    paramCallback(result);
                },
                error: function () {

                    alert("Unauthorized");
                }
            });
            break;
    }
};
//function doAjax(url, callback) {

//    $.ajax({
//        url: url,
//        type: "GET",
//        data:"",
//        success: function (result) {
//            callback(result);
//        },
//        error: function () {

//            alert("Unauthorized");
//        }
//    });
//};