﻿using System;

namespace GildedRose.Prodotti
{
    public class AgedBrie : GenericItem
    {
        /// <summary>
        /// Metodo che aggiorna la qualità dopo una giornata.
        /// </summary>
        public override void UpdateQuality()
        {
            Quality += 1;

            if (SellIn <= 0)
            {
                Quality += 1;
            }

            // Limita la quality tra 0 e 50
            Quality = Math.Max(0, Math.Min(50, Quality));
        }
    }
}
