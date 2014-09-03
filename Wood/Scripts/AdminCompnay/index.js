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