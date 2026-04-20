//Affichage de la page panier lorsue l'on clique sur l'icône dans la barre de navigation
cartLink = document.querySelector(".js-cartLink")
cartLink.addEventListener("click", () => {
    location.href = 'Shop/Cart';
});

//Afficher la page de création de compte dans une modale au click sur "Créer un compte"
const createAccount = document.querySelector(".js-identityConnection")
//let registerUser = document.getElementById("registerUser")
createAccount.addEventListener("click", () => {
    console.log("click !!")
    location.href="../Identity/Account/Register"

    
})
