$(function () {
    $("#spValue").hide();

    var progress = 0;
    $("#spValue").html(progress);

    $("#btnStart").click(function () {
        progress = 0;
        $("#btnReset").addClass("disabled");
        $("#btnStart").button("loading");
        $("#spValue").html(progress);
        $("#spValue").show();
        var interval = setInterval(function () {
            $("#spValue").html(progress);
            $("#divProgressInfo").css("width", progress + "%");
            progress++;
            if (progress > 100) {
                clearInterval(interval);
                $("#btnStart").button("reset");
                $("#btnReset").removeClass("disabled");
            }
        }, 100);
    });

    $("#btnReset").click(function () {
        $("#spValue").hide();
        progress = 0;
        $("#divProgressInfo").css("width", "0%");
    });


});