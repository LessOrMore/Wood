
//新增
function add() {
    var url = "/AdminProduct/ProductTypeEdit";
    top.openDialog(url, 'UserForm', '产品类型 - 添加', 600, 250, 50, 50);
}
//编辑
function edit() {
    var rows = GetGridRowValue("#producttypeTable");
    if (IsEditdata(rows)) {
        key = rows[0].TypeID;
        var key = "";
        var url = "/AdminProduct/ProductTypeEdit?TypeID=" + key;
        top.openDialog(url, 'UserForm', '用户信息 - 编辑', 750, 450, 50, 50);
    }
}
//删除
function Delete() {
    var key = GetPqGridRowValue("#grid_paging", 0);
    if (IsDelData(key)) {
        var delparm = 'action=Delete&key=' + key;
        delConfig('UserList.aspx', delparm);
    }
}
//刷新
function windowload() {
    $("#grid_paging").pqGrid("refreshDataAndView");
    GetRowIndex = -1;
}

//productEdit
function Enter() {
    $("form").submit();
}

