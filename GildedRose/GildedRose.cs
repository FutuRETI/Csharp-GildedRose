using System.Collections.Generic;
using System;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items) 
        {
            this.Items = Items;
        }
        
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                // Aggiorna SellIn
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                // Aggiorna Quality
                switch (Items[i].Name)
                {
                    case "Conjured":
                        Items[i].Quality = Math.Max(0, Items[i].Quality - 2);

                        if (Items[i].SellIn < 0)
                        {
                            Items[i].Quality = Math.Max(0, Items[i].Quality - 2);
                        }

                        break;
                    case "Aged Brie":
                        Items[i].Quality = Math.Min(50, Items[i].Quality + 1);

                        if (Items[i].SellIn < 0)
                        {
                            Items[i].Quality = Math.Min(50, Items[i].Quality + 1);
                        }
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        Items[i].Quality = Math.Min(50, Items[i].Quality + 1);

                        if (Items[i].SellIn < 10)
                        {
                            // Incrementa la seconda volta
                            Items[i].Quality = Math.Min(50, Items[i].Quality + 1);
                        }
                            
                        if (Items[i].SellIn < 5)
                        {
                            // Incrementa la terza volta
                            Items[i].Quality = Math.Min(50, Items[i].Quality + 1);
                        }

                        if (Items[i].SellIn < 0)
                        {
                            Items[i].Quality = 0;
                        }
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        // La quality non cambia mai.
                        break;
                    default:
                        Items[i].Quality = Math.Max(0, Items[i].Quality - 1);

                        if (Items[i].SellIn < 0)
                        {
                            Items[i].Quality = Math.Max(0, Items[i].Quality - 1);
                        }
                        break;
                }
            }
        }    
    }    
}