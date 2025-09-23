// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//script permettant de revenir vers a section sport preview de maniète plus fluide
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

/*Animation des images représentant les disciplines 
sur la page d'accueil*/
    /*1_ au survol de la souris l'image tourne de 180° autour
    de l'axe y*/
    /*2_le nom du sport s'affiche au lieu du dessin*/
    /*3_ Lorsque la souris sort, l'image revient à son état initial*/
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

    
/*Au click sur l'image:
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

//Bouton de fermeture de la page Events/Index
let closeButton = document.querySelector(".js-closeEventsList")
    closeButton?.addEventListener("click", () => {
        console.log("click !!")
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



//Réservation d'un événement
/*Au click sur un bouton + de la page Events/Index: 
    1_récupération de l'événement ()
    2_envoi des valeurs vers le controller via un fomulaire caché pour affichage sur la page Shop/Booking*/

/*const addButtons = document.querySelectorAll(".js-bookEvent")

forEach(button in addButtons)
{   
    button.addEventListener("mousedown", () => {
        console.log("click")
        document.getElementById(".hiddenFormEventsPage").submit()
        console.log(document.getElementById(".hiddenFormEventsPage"))
    })
}*/


    