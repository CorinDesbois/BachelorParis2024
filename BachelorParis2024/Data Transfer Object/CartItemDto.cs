//classe servant d'intermédiaire
//n'exposant que les propriétés qui doivent être récupérées du JSON envoyé par le front
using System.Text.Json.Serialization;

namespace BachelorParis2024.Data_Transfer_Object
{
    public class CartItemDto
    {
        [JsonPropertyName("idTicket")]
        public long IdTicket { get; set; }

        [JsonPropertyName("idEvent")]
        public int IdEvent { get; set; }

        [JsonPropertyName("idOffer")]
        public int IdOffer { get; set; }

        [JsonPropertyName("qty")]
        public int Quantity { get; set; }
    }
}
