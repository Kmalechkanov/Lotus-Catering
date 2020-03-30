let lastScroll = 0;
//let isMobile = false;

//$(window).load(function (e) {
//    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
//        isMobile = true;
//    }
//});

$(window).scroll(function (e) {
    if ($(window).width() <= 600) {
        return;
    }

    if ($(window).scrollTop() >= $(".logo-wrapper").height()) {
        $("header nav").addClass("fixed-header");
        $(".container").css("padding-top", $(".fixed-header").height()+10);
    } else {
        $("header nav").removeClass("fixed-header");
        $(".container").css("padding-top", 10);
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

function auto_grow(element) {
    element.style.height = "5px";
    element.style.height = (element.scrollHeight) + "px";
}