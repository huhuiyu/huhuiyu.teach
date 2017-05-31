$(function () {
    var index = 10000;

    $("#txtName").focus();

    $("#btnAdd").click(function () {
        var name = $("#txtName").val();
        var phone = $("#txtPhone").val();
        var $tr = $(document.createElement("tr"));
        var trClass = index % 2 === 0 ? "info" : "warning";
        $tr.addClass(trClass);
        var $td = $(document.createElement("td"));
        $td.append(index++);
        $tr.append($td);
        $td = $(document.createElement("td"));
        $td.append(name);
        $tr.append($td);
        $td = $(document.createElement("td"));
        $td.append(phone);
        $tr.append($td);
        $("#tabData").append($tr);
        $("#txtName").val("");
        $("#txtPhone").val("");
        $("#txtName").focus();
        $("#nodata").remove();

    });
});