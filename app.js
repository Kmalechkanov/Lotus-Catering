$(window).scroll(function (e) {
  if ($(window).scrollTop() >= 162) {
    $("header nav").addClass("fixed-header");
    //$("nav div").addClass("visible-title");
  } else {
    $("header nav").removeClass("fixed-header");
    //$("nav div").removeClass("visible-title");
  }
});