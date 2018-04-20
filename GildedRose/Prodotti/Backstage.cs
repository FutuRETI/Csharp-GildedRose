using System;

namespace GildedRose.Prodotti
{
    public class Backastage : GenericItem
    {
        /// <summary>
        /// Metodo che aggiorna la qualità dopo una giornata.
        /// </summary>
        public override void UpdateQuality()
        {
            // Incrementa la quality
            Quality += 1;
            // Se mancano 10 o meno giorni incrementa ancora
            if (SellIn <= 10) Quality += 1;
            // Se mancano 5 o meno giorni incrementa ancora
            if (SellIn <= 5) Quality += 1;

            // La quality precipita a 0 dopo la data di SellIn
            if (SellIn <= 0) Quality = 0;

            // Limita la quality tra 0 e 50
            Quality = Math.Max(0, Math.Min(50, Quality));
        }
    }
}
