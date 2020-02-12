let lastScroll = 0;

$(window).scroll(function (e) {
    if ($(window).scrollTop() >= $(".logo-wrapper").height()) {
        $("header nav").addClass("fixed-header");
        $(".container").css("padding-top", $(".fixed-header").height()+100);
        //$("nav div").addClass("visible-title");
    } else {
        $("header nav").removeClass("fixed-header");
        $(".container").css("padding-top", 100);
        //$("nav div").removeClass("visible-title");
    }

    if ($(window).scrollTop() <= lastScroll || $(window).scrollTop() <= $(".logo-wrapper").height()) {
        $(".secondHeader").addClass("show-block");
        $(".secondHeader").removeClass("hide-block");
    } else {
        $(".secondHeader").addClass("hide-block");
        $(".secondHeader").removeClass("show-block");

    }

    lastScroll = $(window).scrollTop();
});
