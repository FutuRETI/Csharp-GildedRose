using System;

namespace GildedRose.Prodotti
{

    public class GenericItem : Item
    {
        public double Value { get; set; }

        /// <summary>
        /// Metodo che calcola il prezzo di acquisto del prodotto da un fornitore.
        /// </summary>
        /// <returns>Il prezzo di acquisto.</returns>
        public double GetPurchasePrice()
        {
            return Value * Quality;
        }

        /// <summary>
        /// Metodo che calcola il prezzo di vendita del prodotto a un cliente.
        /// </summary>
        /// <returns>Il prezzo di vendita.</returns>
        public double GetOfferPrice()
        {
            return Value * Quality * 1.5;
        }

        /// <summary>
        /// Metodo che aggiorna la qualità dopo una giornata.
        /// </summary>
        public virtual void UpdateQuality()
        {
            Quality -= 1;

            if (SellIn <= 0)
            {
                Quality -= 1;
            }

            // Limita la quality tra 0 e 50
            Quality = Math.Max(0, Math.Min(50, Quality));
        }

        /// <summary>
        /// Metodo che decrementa la SellIn dopo ogni giornata.
        /// </summary>
        public virtual void UpdateSellIn()
        {
            SellIn -= 1;
        }
    }
}
