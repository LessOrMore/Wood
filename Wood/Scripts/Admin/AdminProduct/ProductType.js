
//新增
function add() {
    var url = "/AdminProduct/ProductTypeEdit";
    top.openDialog(url, 'UserForm', '产品类型 - 添加', 750, 450, 50, 50);
}
//编辑
function edit() {
    var key = GetPqGridRowValue("#grid_paging", 0);
    if (IsEditdata(key)) {
        var url = "/AdminProduct/ProductTypeEdit?ProductTypeID=" + key;
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
    
}

