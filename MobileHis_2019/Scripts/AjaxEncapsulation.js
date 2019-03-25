
AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
    return data;
};


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