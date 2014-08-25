$(document).ready(function () {

    LoginLocation();
    $(".loginbtn").click(function () {
        Login();
    });
});

function LoginLocation() {
    $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
    $(window).resize(function () {
        $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
    });
}
function Login() {
    var username = $(".loginuser").val();
    var password = $('.loginpwd').val();
    var param = {
        username:username,
        password:password
    };

    AjaxLogin(param);
}

function AjaxLogin(param) {
    $.ajax({
        type: "post",
        url: "/AdminLogin/Login",
        data: param,
        success: function (msg) {
            if (msg == "OK") {
                window.location = "/AdminIndex/Index";
            }
        },
        error: function (msg) {

        }

    });
}