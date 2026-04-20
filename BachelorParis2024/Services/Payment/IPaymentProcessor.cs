namespace BachelorParis2024.Services.Payment
{
    //interface retournant un boolen indiquant si le paiement a réussi ou non
    //elle permettra de pouvoir intégrer plus tard un vrai processeur de paiement sans avoir à modifier le code appelant
    public interface IPaymentProcessor
    {
        Task<bool> ProcessPaymentAsync(string uderId);
        
    }
}
