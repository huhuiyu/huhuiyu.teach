$(function () {
   
    $('[data-toggle="tooltip"]').tooltip();

    $("#txtName").focus();

    $("#txtName").popover({
        "placement": "top"
        , "content": "用户名必须填写！"
        , "trigger": "manual"
    });

    $("#txtName").blur(function () {
        checkName();
    });

    $("#btnNext").click(function () {

        if (!checkName()) {
            return;
        }
        var $btnLoad = $(this).button("loading");
        setTimeout(function () {
            $btnLoad.button("reset");

            $("#li-one").removeClass("active");
            $("#li-two").addClass("active");

            $("#tab-one").removeClass("in");
            $("#tab-one").removeClass("active");

            $("#tab-two").addClass("in");
            $("#tab-two").addClass("active");

            $("#txtPassword").focus();
        }, 2000);


    });

    $("#btnPre").click(function () {
        $("#li-two").removeClass("active");
        $("#li-one").addClass("active");

        $("#tab-two").removeClass("in");
        $("#tab-two").removeClass("active");

        $("#tab-one").addClass("in");
        $("#tab-one").addClass("active");
        $("#txtName").focus();
    });

    function checkName() {
        if ($("#txtName").val() == "") {
            $("#divName").removeClass("has-success");
            $("#divName").addClass("has-error");
            $("#txtName").popover("show");
            $("#txtName").focus();
            return false;
        }
        $("#divName").removeClass("has-error");
        $("#divName").addClass("has-success");
        $("#txtName").popover("hide");
        return true;
    }
});