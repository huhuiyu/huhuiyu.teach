$(function () {
    var json1 = {
        "name": "张三",
        "phone": "15080604020"
    };

    $("#json1").html("姓名：" + json1.name + "，电话：" + json1.phone);
    var json2 = {};
    json2.name = "可乐",
    json2.value = 3.5;

    $("#json2").html(JSON.stringify(json2));

    var json3 = {
        "id": 100,
        "name": "开发部",
        "toString": function () {
            return this.id + "-" + this.name;
        }
    };

    $("#json3").html(json3.toString());

    var json4 = JSON.parse($("#txtJson").val());
    $("#json4").html(json4.item + ":" + json4.count);
    var json5 = {
        "province": "湖南",
        "citys": [{
            "id": 100, "name": "长沙"
        }, {
            "id": 200, "name": "常德"
        }]
    };

    $("#json5").html(json5.province);

    $.each(json5.citys, function (i, v) {
        var option = $(document.createElement("option"));
        option.attr("value", v.id);
        option.append(v.name);
        $("#selJson").append(option);
    });

    $.get("json_data.html", function (result) {
        $("#json6").html(result.name + ":" + result.data);
    }, "json");

    $.post("json.aspx", { "mode": 1 }, function (result) {
        $("#json7").html(result.data);
    }, "json");

    $.post("json.aspx", { "mode": 2 }, function (result) {
        $("#json8").html(result.data);
    }, "json");
});