using GildedRose.Prodotti;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        readonly IList<Item> Items;
        readonly RetailService Vendita;

        public GildedRose(IList<Item> Items) 
        {
            this.Items = Items;
            Vendita = new RetailService(Items);
        }

        public void UpdateQuality()
        {
            foreach(Item Item in Items)
            {
                // Aggiorna la quality di tutti i prodotti
                (Item as GenericItem).UpdateQuality();

                // Aggiorna la sellin di tutti i prodotti
                (Item as GenericItem).UpdateSellIn();
            }
        }

        public IList<Item> ServiClienti()
        {
            return Vendita.GetProdottiVendutiOggi();
        }
    }
}