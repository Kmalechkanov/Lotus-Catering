let lastScroll = 0;

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

function AddAlert(status, message, alertType) {
    let template = document.querySelector("#alerts > div").cloneNode(true);
    template.style.display = "block"; 
    template.classList.add(alertType);
    template.children[1].textContent = status;
    template.children[2].textContent = message;
    document.getElementById("alerts").appendChild(template);
}

function RemoveAlert(elem) {
    var div = elem.parentElement;
    div.style.opacity = "0";
    setTimeout(function () { div.style.display = "none"; }, 600);
}