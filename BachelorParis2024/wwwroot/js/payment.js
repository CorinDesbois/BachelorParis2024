//fonction permettant de déclencher le processus de paiement.
//en cas de paiement réussi (respon.ok), la commande est validée

const payBtn = document.querySelector(".js-goToPayment")
payBtn.addEventListener("click", async() => {
    try {
        const paymentResponse = await fetch("/Payment/ProcessPayment", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        })
        if (!paymentResponse.ok) {
            const paymentData = await paymentResponse.json()
            console.log("message: ", paymentData.message)
            let errorMessage = document.getElementById("js-errorFr")
            errorMessage.innerHTML = "Echec de la tentative de paiement"
                location.href = "../Shared.Error"
            

        }
        else
        {   
            console.log("paiement effectué avec succès")
            localStorage.clear()
            setTimeout(() => {
                window.alert("Votre paiement a été accepté. Vous pouvez d'ors et déjà retrouver vos billets dans l'onglet mes commandes. Nous vous disons un grand merci et à bientôt !")
                location.href = "../OrdersEF/Index"
            },500)
            
        }
    } catch (error) {
        let errorMessage = document.getElementById("js-errorFr")
        errorMessage.innerHTML = "Une erreur s'est produite"
        location.href = "../Shared/Error"
        }
})
