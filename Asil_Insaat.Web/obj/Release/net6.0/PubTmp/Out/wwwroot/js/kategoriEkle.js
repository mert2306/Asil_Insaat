

$(document).ready(function () {

    $("#btnSave").click(function (event) {
        event.preventDefault();

        var addUrl = app.Urls.kayegoriEkleUrl;
        var redirectUrl = app.Urls.YaziEkleUrl;

        var KategoriEklemeViewModel = {

            Name: $("input[id=kategoriIsim]").val()
        }

        var jsonData = JSON.stringify(KategoriEklemeViewModel);
        console.log(jsonData);
        $.ajax({

            url: addUrl,
            type: "POST",
            contentType: "application/json; charset-utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl;
                }, 1500);
            },
            error: function () {
                toast.error("Bir Hatan Var Sanırım!!", "HATA")
            }


        });


    });


});