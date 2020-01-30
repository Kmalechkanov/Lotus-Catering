$(window).scroll(function (e) {
  if ($(window).scrollTop() >= $(".logo-wrapper").height()) {
    $("header nav").addClass("fixed-header");
    //$("nav div").addClass("visible-title");
  } else {
    $("header nav").removeClass("fixed-header");
    //$("nav div").removeClass("visible-title");
  }
});