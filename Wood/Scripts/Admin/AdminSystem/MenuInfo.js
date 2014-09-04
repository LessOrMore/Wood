
$(document).ready(function () {
    $("html").css("overflow", "hidden");
    $("body").css("overflow", "hidden");

    iframeresize();

    Loading(true);

    BindData();

    if ($("#errMsg") != null && $("#errMsg").val() != "" && typeof ($("#errMsg").val()) != "undefined") {
        showTipsMsg($("#errMsg").val(), 3000, 3);
        //新增或修改时刷新页面
        //window.top.$('#' + Current_iframeID())[0].contentWindow.window.location.reload();
    }

});

function BindData() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/AdminSystem/GetMenuJson",
        data: "{}",
        dataType: 'json',
        success: function (result) {
            $("#menuTable").datagrid('loadData', result);
        }

    });
}

function btnHandler(flag) {
    var url = "/Menu/";
    var vname;
    if (flag == 0) {
        vname = "新增";
        url += "Edit";
    }
    else if (flag == 1) {
        vname = "编辑";
        url += "Edit";
    }
    else if (flag == 2) {
        vname = "删除";
        url += "Delete";
    }
    else if (flag == 3) {
        vname = "查看";
        url += "Read";
    }

    var rows = $('#menuTable').datagrid('getSelections');
    if (rows.length > 0 && flag != 0) {
        url += "?MenuID=" + rows[0]["MenuID"];
    }

    else if (rows.length < 1 && (flag != 0)) {
        showTipsMsg("请选择需要操作的数据后进行操作", 3000, 3);
        return;
    }

    //2删除
    if (flag == 2) {
        var delparm = {};
        delparm.MenuID = rows[0]["MenuID"];
        delConfig(url, delparm);
    }
    else {
        top.openDialog(url, "MenuForm", "菜单管理 - " + vname, 650, 200, 50, 50, function () {
            $("#menuTable").datagrid("reload");
        });
        //top.$('#' + Current_iframeID())[0].contentWindow.window.location.reload();

    }
}

function Enter() {
    $("form").submit();
}
