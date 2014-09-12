//编辑
function edit() {
    top.openDialog("/AdminCompany/Edit/", 'Edit', '公司信息 - 编辑', 750, 450, 50, 50);
}
//刷新
function windowload() {
    $("#grid_paging").pqGrid("refreshDataAndView");
    GetRowIndex = -1;
}


function SaveCompany()
{
    var param = {};
    param.CompanyName = $("#CompanyName").val();
    param.CompanySummary = $("#CompanySummary").val();
    param.CompanyDes = $("#CompanyDes").val();
    param.CompanyAddress = $("#CompanyAddress").val();
    param.CompanyTelephone = $("#CompanyTelephone").val();
    param.CompanyEmail = $("#CompanyEmail").val();

    $.ajax({
        type: 'post',
        url: '/AdminCompany/UpdateCompany',
        data: param,
        success: function (data, textState) {
            alert(data.message);
        },
        error: function (errmsg) {
            errmsg = '';
        }
    });
}