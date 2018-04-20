namespace GildedRose.Prodotti
{
    public class Sulfuras : GenericItem
    {
        /// <summary>
        /// Metodo che aggiorna la qualità dopo una giornata.
        /// Per il sulfuras, che è un prodotto magico, non deve esser fatto nulla.
        /// </summary>
        public override void UpdateQuality()
        {
            // Non far nulla
        }

        /// <summary>
        /// Metodo che aggiorna la SellIn dopo una giornata.
        /// Per il sulfuras, che è un prodotto magico, non deve esser fatto nulla.
        /// </summary>
        public override void UpdateSellIn()
        {
            // Non far nulla
        }
    }
}
