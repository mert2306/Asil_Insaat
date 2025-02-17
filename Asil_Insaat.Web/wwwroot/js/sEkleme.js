﻿$(document).ready(function () {

    $("#btnSave").click(function (event) {
        event.preventDefault();

        var addUrl = app.Urls.SatisBirimiEkleUrl;
        var redirectUrl = app.Urls.UrunEkleUrl;

        var satisBirimiEklemeViewModel = {
            Aciklama: $("input[id=satisBirimiIsim]").val()
        };

        var jsonData = JSON.stringify(satisBirimiEklemeViewModel);
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
                toast.error("Bir Hatan Var Sanırım!!", "HATA");
            }
        });


    });


});
