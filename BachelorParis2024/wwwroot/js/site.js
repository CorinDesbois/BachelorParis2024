//Affichage de la page panier lorsue l'on clique sur l'icône dans la barre de navigation
cartLink = document.querySelector(".js-cartLink")
cartLink.addEventListener("click", () => {
    location.href = 'Shop/Cart';
});
