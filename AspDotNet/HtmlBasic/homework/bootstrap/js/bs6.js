$(function () {
    $("#my-carousel").carousel({
        "interval": 2000
    });

    $("#btnNext").click(function () {
        $("#my-carousel").carousel("next");
    });

    $("#btnPre").click(function () {
        $("#my-carousel").carousel("prev");
    });

});