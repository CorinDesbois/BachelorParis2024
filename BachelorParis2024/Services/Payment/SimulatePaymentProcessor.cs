namespace BachelorParis2024.Services.Payment
{
    public class SimulatePaymentProcessor : IPaymentProcessor
    {
        public async Task<bool> ProcessPaymentAsync(string userId)
        {
            // Simuler un délai de traitement du paiement
            await Task.Delay(2000);
            // Pour la simulation, on retourne toujours true (paiement réussi)
            return true;
        }
    }
}
