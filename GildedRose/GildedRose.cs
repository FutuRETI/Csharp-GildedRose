using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        readonly IList<Item> Items;

        public GildedRose(IList<Item> Items) 
        {
            this.Items = Items;
        }
        
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                // Aggiorna la quality di tutti i prodotti
                Items[i].UpdateQuality();

                // Aggiorna la sellin di tutti i prodotti
                Items[i].UpdateSellIn();

            }
        }    
    }
}