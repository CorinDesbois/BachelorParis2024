//Ajout des billets dans le panier
//envoie les données du formulaire
//de booking.cshtml vers shop controller -> view"Cart"




let idEvent = document.querySelector(".js-idEvent")
let sportEvent = document.querySelector(".js-sportEvent")
let nameEvent = document.querySelector(".js-nameEvent")
let dateEvent = document.querySelector(".js-dateEvent")
let locationEvent = document.querySelector(".js-locationEvent")
let radios = document.getElementsByName("offerSelection")
let addToCartBtn = document.querySelector(".js-addToCart")


if (typeof addToCartBtn !== "undefined" && addToCartBtn !== "null") {
    addToCartBtn.addEventListener("click", () => {
        for (i of radios) {
            if (i.checked) {
                let cartItem = {
                    idTicket: Date.now(),
                    idEvent: idEvent.textContent,
                    sport: sportEvent.textContent,
                    event: nameEvent.textContent,
                    date: dateEvent.textContent,
                    location: locationEvent.textContent,
                    idOffer: i.value,
                    offer: i.dataset.name,
                    description: i.dataset.description,
                    price: i.dataset.price,
                    qty:1
                }
                saveItems(cartItem)
                window.alert("Le billet a bien été ajouté au panier")
                console.log(cartItem.idTicket)
                renderCart()
            }
        }

    })
}

//Affichage de la page panier lorsue l'on clique sur l'icône dans la barre de navigation
const cartLink = document.querySelector(".js-cartLink")
cartLink.addEventListener("click", () => {
    location.href = 'Cart';
});

// retourne à la liste des événements au click sur la flèche
const btn = document.querySelector(".js-buttonBackToEventList")
btn.addEventListener("click", () => {
    location.href = "../Events/Index"
})