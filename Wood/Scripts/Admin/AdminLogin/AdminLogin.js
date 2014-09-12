/*
检查浏览器是否支持
*/
var isIE = !!window.ActiveXObject;
var isIE6 = isIE && !window.XMLHttpRequest;
//IE6浏览器跳转到指定的页面
if (isIE6) {
    window.location.href = "/ErrorPage/Browser_Not_Support";
}

//回车键
document.onkeydown = function (e) {
    if (!e) {
        e = window.event; // //火狐中是 window.event
    }

    if ((e.keyCode || e.which) == 13) {
        var obtnSearch = document.getElementById("Log_Submit");
        //让另一个控件获得焦点就等于让文本输入框失去焦点
        obtnSearch.focus();
        obtnSearch.click();
    }
}

$(document).ready(function () {
    ToggleCode("Verify_codeImag", "VerifyCode");
});

//验证登陆是否合法
function CheckUserDataValid() {
    if (!LoginBtn()) {
        return false;
    }
    else {
        CheckingLogin(1);

        //window.location.href = "MainIndex.aspx";
        //CheckingLogin(0);

        //登陆账户
        var Account = $("#Account").val();
        //登陆密码
        var Pwd = $("#Pwd").val();
        //验证码
        var Code = $("#Code").val();

        var params = "Action=Login&Account=" + escape(Account) + "&Pwd=" + escape(Pwd) + "&Code=" + Code;
        GetAjaxFunction("/AdminLogin/Login", params, function (rs) {
            if (parseInt(rs) == 1) {
                showTopMsg("密码输入错误", 3000, "error");
                $("#Pwd").focus();
                CheckingLogin(0);
                return;
            }
            else if (parseInt(rs) == 2) {
                showTopMsg("验证码超时", 3000, "error");
                ToggleCode("Verify_codeImag", "VerifyCode");
                CheckingLogin(0);
                return;
            }
            else if (parseInt(rs) == 3) {
                showTopMsg("验证码输入错误", 3000, "error");
                $("#Code").focus();
                CheckingLogin(0);
                return;
            }
            else if (parseInt(rs) == 4) {
                showTopMsg("登陆账户错误", 3000, "error");
                $("#Account").focus();
                CheckingLogin(0);
                return;
            }
            else if (parseInt(rs) == 0) {
                window.location.href = "/AdminIndex/Index";
                return;
            }
            else {
                CheckingLogin(0);
                alert(rs);
                window.location.href = window.location.href.replace('#', '');
            }
        });
    }
}

function GetAjaxFunction(url, parm, callBack) {
    $.ajax({
        type: "post",
        dataType: "text",
        url: url,
        data: parm,
        cache: false,
        async: false,
        success: function (msg) {
            callBack(msg);
        }
    });
}

//控件验证
function LoginBtn() {
    //登陆账户
    var Account = $("#Account").val();
    //登陆密码
    var Pwd = $("#Pwd").val();
    //验证码
    var Code = $("#Code").val();

    if (Account == "") {
        $("#Account").focus();
        showTopMsg("登陆账户不能为空", 3000, "error");
        return false;
    }

    if (Pwd == "") {
        $("#Pwd").focus();
        showTopMsg("登陆密码不能为空", 3000, "error");
        return false;
    }

    if (Code == "") {
        $("#Code").focus();
        showTopMsg("验证码不能为空", 3000, "error");
        return false;
    }

    if (Code.length != 4) {
        $("#Code").focus();
        showTopMsg("验证码必须为4位", 3000, "error");
        return false;
    }

    return true;
}

//根据id改变登陆按钮图片元素
function CheckingLogin(id) {
    if (id == 1) {
        //attr设置或改变元素的属性值
        $("#Log_Submit").attr("disabled", "disabled");
        $("#Log_Submit").attr("class", "signload");
        $(".load").show();
    }
    else {
        //removeAttr移除元素的属性
        $("#Log_Submit").removeAttr("disabled");
        $("#Log_Submit").attr("class", "sign");
        $(".load").hide();
    }
}

//清空
function ClearInput() {
    //登陆账户
    $("#Account").focus();
    $("#Account").val("");
    //登陆密码
    $("#Pwd").val("");
    //验证码
    $("#Code").val("");
}