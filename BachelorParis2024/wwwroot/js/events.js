// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//script permettant de revenir vers la section sport preview de manière plus fluide
//à revoir
window.addEventListener("DOMContentLoaded", () => {
    if (window.location.hash) {
        const target = document.querySelector(window.location.hash);
        if (target) {
            // Calcul de la position avec offset
            const headerHeight = document.querySelector("header").offsetHeight;
            const elementPosition = target.getBoundingClientRect().top + window.scrollY;
            const offsetPosition = elementPosition - headerHeight;

            window.scrollTo({
                top: offsetPosition,
                behavior: "smooth"
            });
        }
    }
});

/*Images représentant les disciplines sur la page d'accueil*/
    //1_Animation au survol
const disciplineImage = document.querySelectorAll('.js-discipline')
let eventsPageTitle = document.getElementsByClassName('.js-eventsPage-title')

disciplineImage.forEach(img => {
    let sportImg = img.lastElementChild
    let sportName = img.firstElementChild.textContent
    img.addEventListener('mouseenter', () => {
        img.classList.add('js-discipline-rotation')
        img.classList.add('js-pointer')
        timeOutId = setTimeout(() => {
            img.classList.add('bg_blue')
            img.classList.add('text-white')
            img.classList.add('text-center')
            img.textContent = sportName
            img.classList.remove()
            img.classList.remove('js-discipline-rotation')
        }, 400)
    })
    img.addEventListener('mouseleave', () => {
        clearTimeout(timeOutId)
        img.classList.remove('js-discipline-rotation')
        sportImg.classList.remove('js-hidden')
        img.classList.remove('bg_blue')
        img.textContent = ""
        img.appendChild(sportImg)  
    })
})

        /* 2_Au click sur l'image:
    1_récupération du nom du sport 
    2_envoi dans le formulaire de la page Home/Index
    3_submit du formulaire pour que le controller puisse récupérer la valeur
*/
disciplineImage.forEach(img => {
    let sportName = img.firstElementChild.textContent
    img.addEventListener('mousedown', () => {
        document.getElementById("hiddenFormInput").value = sportName
        document.getElementById("hiddenFormHomePage").submit()
    })
})

//Bouton de fermeture de la page Events/Index
let closeButton = document.querySelector(".js-closeEventsList")
    closeButton?.addEventListener("click", () => {
        window.location.assign("../Home#sports_preview")

    })

//Fermeture de la page Shop/Booking
let backToListButton = document.querySelector(".js-buttonBackToEventList")
backToListButton?.addEventListener("click", () => {  
    let category = document.querySelector(".js-sportNameValue")
    let sport = category.textContent
    document.getElementById("hiddenInputCLoseBookingPage").value = sport
    document.getElementById("hiddenFormCLoseBookingPage").submit() 
})

//Accès à la liste des événement par sport depuis la liste complète des sport de la page Home/Index
//En cliquant sur le sport souhaité dans la liste affichée
//Utilisation du formulaire caché de la page Home/Index
let eventsButton = document.querySelectorAll(".js-sportSelection")
eventsButton.forEach(btn => {
    btn.addEventListener("click", () => {
        let sport = btn.textContent
        console.log("click event !!")
        console.log("sport: " +sport)
        document.getElementById("hiddenFormInput").value = sport
        document.getElementById("hiddenFormEventPage").submit()
    })
})
//A revoir, ne fonctionne pas correctement pour le moment


