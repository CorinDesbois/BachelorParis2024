//fonction permettant d'afficher le panier de façon dynamique

let n = 1 //-> nb de billets
let x = 0 //-> index de la ligne

const renderCart = () => {
    //1_Vider le contenu html existant
    const cartContainer = document.querySelector("#js-cartContainer")
    cartContainer.innerHTML = ""
    
    //2_Récupérer les articles contenus dans le localStorage
    const items = getItems()
    if (items.lenght === 0) {
        
        console.log("panier vide !!")
    }

    //3_les afficher dans la div prévue à cet effet

    for (i of items) {
        const divcartItem = document.createElement("section")
        divcartItem.classList.add("js-cartItemSection", "row", "row-cols-sm-2", "row-cols-md-3", "row-cols-lg-4")
        cartContainer.appendChild(divcartItem)
        const divEvent = document.createElement("div")
        divEvent.classList.add('js-cart_Event', "col")
        divEvent.innerHTML = `
            <h4>${i.sport}</h4>
            <h5>${i.event}</h5>
            <p>${i.date}</p>
            <p>${i.location}</p> `
        divcartItem.appendChild(divEvent)

        const divOffer = document.createElement("div")
        divOffer.classList.add("js-cart_Offer","col")
        divOffer.innerHTML = `
            <h4>${i.offer}</h4>
            <p>${i.description} </p>
            <p>Prix: ${i.price}€</p>`
        divcartItem.appendChild(divOffer)
        
        const total = parseInt(i.price)

        const divUpdate = document.createElement("div")
        divUpdate.classList.add("js-cart_Update", "flex-centered", "js-cart_Update", "btn", "rounded-pill", "col")
        const pDecrease = document.createElement("p")
        pDecrease.classList.add("js-cartDecrease", "align-self-center", "js-pointer", "m-lg-2")
        pDecrease.innerHTML = "-"
        divUpdate.appendChild(pDecrease)
        const pQty = document.createElement("p")
        pQty.classList.add("align-self-center", "m-lg-2")
        pQty.innerHTML = `${n}`
        divUpdate.appendChild(pQty)
        const pIncrease = document.createElement("p")
        pIncrease.classList.add("js-cartIncrease", "align-self-center", "js-pointer", "m-lg-2")
        pIncrease.innerHTML = "+"
        divUpdate.appendChild(pIncrease)
        const img = document.createElement("img")
        img.classList.add("js-bin", "align-self-center", "js-pointer", "m-lg-2")
        img.src = "../images/icones/corbeille-a-papier.png"
        img.alt = "corbeille"
        divUpdate.appendChild(img)
        divcartItem.appendChild(divUpdate)

        const divAmount = document.createElement("div")
        divAmount.classList.add("js-cart_Amount", "flex-centered","col", "js-Amount")
        divAmount.innerHTML = `
            <p>Total: ${total}€</p>`
        divcartItem.appendChild(divAmount)
    } 
    let bins = document.querySelectorAll(".js-bin")
    bins.forEach(bin => {
        bin.addEventListener("click", () => {
            removeOneItem(i.id)
            window.alert("Le billet a été supprimé du panier")
            renderCart()
        })
    })



    if (cartContainer.innerHTML === "") {
        console.log("vore panier est vide")
        cartContainer.innerHTML = `
        <h3>Votre panier est vide<h3>
        <img src= ../images/icones/chariot.png class="img-fluid" alt="panie vide">`
    }
}

renderCart()



