//sur la page panier

//fonction permettant de vider le panier
document.addEventListener("DOMContentLoaded", () => {
    const clearCart = document.querySelector(".js-clearCart")
    clearCart.addEventListener ("click", () => {
        removeAllItems()
        renderCart()
    })
})

//fonction permettant de revenir à la liste des événements
const backArrow = document.querySelector(".js-backToList")
backArrow.addEventListener ("click", () => {
    location.href = "../Events/Index"
    
})

//fonction permettant de valider la panier
//au clic, les données du local storage sont envoyées au ControllerBase(API)
//ce dernier contrôlera si l'utilisateur est connecté et sauvegardera le panier dans la BDD
const submit = document.querySelector(".js-submitCart")
submit.addEventListener("click", async () => {
    console.log('clic !')
    const cart = JSON.parse(localStorage.getItem("savedItems")) || []
    console.log(cart)
    console.log("stringify: ")
    console.log(JSON.stringify(cart))

    const response = await fetch("/Cart/PostCart", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(cart),
    });
    if (response.ok) {
        console.log("panier envoyé")
        location.href="../Cart/Checkout"
    }
    else if (response.status === 401) {
        console.error("utilisateur non connecté")
        location.href = "../Identity/Account/Login"
    }
    else {
        console.error("erreur lors de l'envoi du panier")
    }
})