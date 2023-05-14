// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(".scroll").click(function (event) {
        event.preventDefault();
        var target = $(this.hash);
        $('html, body').animate({
            scrollTop: target.offset().top
        }, 500);
    });
});

$(document).ready(function () {
    $(".skokDoOfert").click(function () {
        window.location.href = "ViewOffers";
    });
});

$(document).ready(function () {
    $(".skokDoZrobieniaOfert").click(function () {
        window.location.href = "SetOffer";
    });
});