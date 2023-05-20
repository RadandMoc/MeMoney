// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(".scroll1").click(function (event) {
        event.preventDefault();
        var target = $(this.hash);
        $('html, body').animate({
            scrollTop: target.offset().top
        }, 500);
    });
});

$(document).ready(function () {
    let elements = document.querySelectorAll('.klasa');
    elements.forEach(function (element) {
        element.addEventListener('mouseleave', function (event) {
            element.style.transition = 'width 1s';
            element.style.width = '50px';
        });
    });
});

$(document).ready(function () {
    $(".skokDoZrobieniaOfert").click(function () {
        window.location.href = "SetOffer";
    });
});

$(document).ready(function () {
    $(".skokDoOfert").click(function () {
        window.location.href = "ViewOffers";
    });
});

function register() {
    Swal.fire({
        title: 'Wybierz rolę',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Twórca memów',
        cancelButtonText: 'Firma'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire('Wybrano Twórcę memów', '', 'success');
            window.location.href = '/MemAuthor';
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire('Wybrano Firmę', '', 'success');
            window.location.href = '/Company';
        }
    });
}

//Teoretycznie wprowadza partial view do obiektu klasy OfferBox
/*window.addEventListener('load', function () {
    const OffersContainer = document.querySelector('.OffersContainer');
    const xhr = new XMLHttpRequest();
    xhr.open('GET', '_BoxOfOffert', true);
    xhr.onload = function () {
        if (xhr.status === 200) {
            OffersContainer.innerHTML = xhr.responseText;
        }
    };
    xhr.send();
});*/
/*window.addEventListener('load', function () {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('offerBoxesContainer').innerHTML = this.responseText;
        }
    };
    xhr.open('GET', '_BoxOfOffert', true);
    xhr.send();
});*/

/*
//Klonowanie obiektu o konkretnym id
$(document).ready(function () {
    const kopiowacz = document.getElementById('kopiowacz');
    const klon = kopiowacz.cloneNode(true);
    const offersContainer = document.querySelector('.OffersContainer');
    offersContainer.appendChild(klon);
})*/

/*
function minimalnaOdleglosc() {
    const divs = document.getElementsByClassName("memesy");
    let minOdleglosc = window.innerHeight;
    for (let i = 0; i < divs.length; i++) {
        const odleglosc = divs[i].getBoundingClientRect().bottom - window.innerHeight;
        if (odleglosc < minOdleglosc) {
            minOdleglosc = odleglosc;
        }
    }
    return minOdleglosc;
}

function getShortestMemesyId() {
    let memesy = document.getElementsByClassName("memesy");
    let shortestMemesyId = memesy[0].id;
    for (let i = 1; i < memesy.length; i++) {
        if (memesy[i].id.length < shortestMemesyId.length) {
            shortestMemesyId = memesy[i].id;
        }
    }
    return shortestMemesyId;
}

var nextString ="https://scontent-vie1-1.xx.fbcdn.net/v/t39.30808-6/347133997_150714007974615_3551393103343863070_n.jpg?_nc_cat=1&ccb=1-7&_nc_sid=730e14&_nc_ohc=h8k5cduchN4AX9zXgMK&_nc_ht=scontent-vie1-1.xx&oh=00_AfC_cdfaARvnBpEfN0gQE2q8uJDhOY6EJYUWJS_FgWCLDw&oe=6468AF1A"

let intervalId = setInterval(function () {
    console.log(document.getElementsByClassName("memesy"));
    console.log(getShortestMemesyId());
    console.log(minimalnaOdleglosc());
    console.log(nextString);
    let memesy = document.getElementsByClassName("memesy");
    if (memesy.length > 0) {
        clearInterval(intervalId);
        if (minimalnaOdleglosc() <= 50) {
            let id = getShortestMemesyId();
            let img = document.createElement("img");
            img.src = nextString;
            img.alt = "";
            document.getElementById(id).appendChild(img);
        }
    }
}, 1000);
*/
