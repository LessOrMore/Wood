$(document).ready(function () {

    $(".left").height($(window).height() - 93);
    $(".content").height($(window).height() - 93);
    $(".content").width($(window).width() - 195);

    /* left menu*/
    $(".menuson li").click(function () {
        $(".menuson li.active").removeClass("active")
        $(this).addClass("active");

        var url = $(this).find("div")[0].id;
        $(".content").html("");
        var frameHtml = "<iframe name=\"tabs_iframe\" height=\"100%\" width=\"100%\" src=\"" + url + "\" frameBorder=\"0\"></iframe>";
        $(".content").append(frameHtml);
    });

    $('.title').click(function () {
        var $ul = $(this).next('ul');
        $('dd').find('ul').slideUp();
        if ($ul.is(':visible')) {
            $(this).next('ul').slideUp();
        } else {
            $(this).next('ul').slideDown();
        }
    });
    /*end left menu*/

    /*top*/
    $(".nav li a").click(function () {
        $(".nav li a.selected").removeClass("selected")
        $(this).addClass("selected");
    })
    /*end top*/
});


