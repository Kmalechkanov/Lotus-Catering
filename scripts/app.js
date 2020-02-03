let lastScroll = 0;

$(window).scroll(function (e) {
  if ($(window).scrollTop() >= $(".logo-wrapper").height()) {
    $("header nav").addClass("fixed-header");
    //$("nav div").addClass("visible-title");
  } else {
    $("header nav").removeClass("fixed-header");
    //$("nav div").removeClass("visible-title");
  }
  
  console.log($(window).scrollTop() + " " + $(".logo-wrapper").height());
  if ($(window).scrollTop() <= lastScroll || $(window).scrollTop() <= $(".logo-wrapper").height()) {
    $(".secondHeader").addClass("show-block");
    $(".secondHeader").removeClass("hide-block");
  } else {
    $(".secondHeader").addClass("hide-block");
    $(".secondHeader").removeClass("show-block");

  } 

  lastScroll = $(window).scrollTop();
});
