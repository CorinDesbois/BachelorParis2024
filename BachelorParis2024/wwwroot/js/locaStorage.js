//fonction permettant de stocker les articles dans le local storage du navigateur
const saveItems = (newItem) => {
    let savedItems = []
    //récuparation du panier existant s'il y en a déjà un
    let localValue = localStorage.getItem("savedItems")
    if (localValue !== null) {
        savedItems = JSON.parse(localValue) //-> sérialisation du tableau d'objets
    }

    //Ajout du nouvel articles
    savedItems.push(newItem)
    //Sauvegarde en JSON dans le local storage
    localStorage.setItem("savedItems", JSON.stringify(savedItems))
}

//fonction permettant de récupérer tous les articles stockés dans le local storage du navigateur
const getItems = () => {
    let localValue = localStorage.getItem("savedItems")
    //console.log(localValue ? JSON.parse(localValue) : [])
    return (localValue ? JSON.parse(localValue) : [])
}

//fonction permettant de vider le panier 
const removeAllItems = () => {
    localStorage.removeItem("savedItems")
}

//fonction permettant de retirer 1 seul article du panier 
const removeOneItem = (i) => {
    let localValue = localStorage.getItem("savedItems")
    let savedItems = JSON.parse(localValue)
    let item = savedItems.find(x => x.idTicket === i)
    savedItems.splice(i, 1)
    window.alert("Le billet va être supprimé du panier")
    localStorage.setItem("savedItems", JSON.stringify(savedItems))
}

//fonctions permettant la mise à jour de la quantité pour un articles
const increaseQty = (idTicket) => { 
    let savedItems = JSON.parse(localStorage.getItem("savedItems")) || [];
    let item = savedItems.find(x => x.idTicket == idTicket)
    if (item) {
        item.qty++
        localStorage.setItem("savedItems", JSON.stringify(savedItems))
    }
}

const decreaseQty = (idTicket) => {
    let savedItems = JSON.parse(localStorage.getItem("savedItems")) || [];
    let item = savedItems.find(x => x.idTicket == idTicket)
    if (item) {
        if (item.qty > 1) {
            item.qty--
        } else {
            savedItems.splice(i, 1) 
            window.alert("Le billet va être supprimé du panier")
        }
        localStorage.setItem("savedItems", JSON.stringify(savedItems))
    }
}

//fonction permettant de calculer le total du panier
const calculateCartAmount = () => {
    let savedItems = JSON.parse(localStorage.getItem("savedItems")) || [];
    let total = savedItems.reduce((acc, item) => {
    let price = parseFloat(item.price.replace(",", "."))
        return acc + (price * item.qty)
},0)
    return total
}

