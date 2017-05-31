$(function () {

    $("#spanTime").html(new Date().toLocaleString());

    setInterval(function () {
        $("#spanTime").html(new Date().toLocaleString());
    }, 1000);

    $("#btnOkDialog").click(function () {
        var name = $("#txtName").val();
        var password = $("#txtPassword").val();

        $("#divName").removeClass("has-error");
        $("#divPassword").removeClass("has-error");

        if (name === "") {
            $("#okDialogInfo").html("用户名必须填写!");
            $("#divName").addClass("has-error");

            $("#dialogOk").modal({ "show": true });

            $("#dialogOk").on("hidden.bs.modal", function () {
                $("#txtName").focus();
            });
            return;
        }

        $("#divName").addClass("has-success");

        if (password === "") {
            $("#okDialogInfo").html("密码必须填写!");
            $("#divPassword").addClass("has-error");

            $("#dialogOk").modal({ "show": true });

            $("#dialogOk").on("hidden.bs.modal", function () {
                $("#txtPassword").focus();
            });
            return;
        }

        $("#divPassword").addClass("has-success");

        $("#okDialogInfo").html("提交的信息：<br/>用户名：" + name + ",密码：" + password);

        $("#dialogOk").modal({ "show": true });

        $("#dialogOk").on("hidden.bs.modal", function () {
            $("#txtName").val("");
            $("#txtPassword").val("");

            $("#divName").removeClass("has-success");
            $("#divPassword").removeClass("has-success");

            $("#txtName").focus();
        });

    });


});