// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/*Animation des images représentant les disciplines 
sur la page d'accueil*/

    /*1_ au survol de la souris l'image tourne de 180° autour
    de l'axe y*/
    /*2_le nom du sport s'affiche au lieu du dessin*/
    /*3_ Lorsque la souris sort, l'image revient à son état initial*/
const disciplineImage = document.querySelectorAll('.js-discipline')
const eventsPageTitle = document.querySelector('.js-eventsPage-title');
console.log(eventsPageTitle)

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


    





    