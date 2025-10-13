document.addEventListener("DOMContentLoaded", () => {
    const clearCart = document.querySelector(".js-clearCart")
    clearCart.addEventListener ("click", () => {
        console.log("click !!")
        removeAllItems()
        renderCart()
    })
})

let backArrow = document.querySelector(".js-backToList")
backArrow.addEventListener ("click", () => {
    console.log("click click !!")
    location.href = "../Events/Index"
    
})

