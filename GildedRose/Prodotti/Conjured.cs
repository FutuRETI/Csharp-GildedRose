using System;

namespace GildedRose.Prodotti
{
    public class Conjured : GenericItem
    {
        public override void UpdateQuality()
        {
            Quality -= 2;

            if (SellIn <= 0)
            {
                Quality -= 2;
            }

            // Limita la quality tra 0 e 50
            Quality = Math.Max(0, Math.Min(50, Quality));
        }
    }
    
}
