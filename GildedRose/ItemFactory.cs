using System;
using System.Collections.Generic;
using GildedRose.Prodotti;

namespace GildedRose
{
    public static class ItemFactory
    {
        /// <summary>
        /// Lista contenente tutti i prodotti disponibili per essere aggiunti alla locanda.
        /// </summary>
        public static readonly IList<string> NomeProdotti = new List<string>
        {
            "+5 Dexterity Vest",
            "Aged Brie",
            "Elixir of the Mongoose",
            "Sulfuras, Hand of Ragnaros",
            "Backstage passes to a TAFKAL80ETC concert",
            "Conjured Mana Cake"
        };

        /// <summary>
        /// Restistuisce un nome in modo casuale tra quelli disponibili per essere aggiunti alal locanda.
        /// </summary>
        /// <param name="Rand">Il generatore di numeri Random.</param>
        /// <returns>Il nome del prodotto casuale scelto.</returns>
        public static string GetNomeProdottoRandom(Random Rand)
        {
            return ItemFactory.NomeProdotti[Rand.Next(ItemFactory.NomeProdotti.Count)];
        }

        /// <summary>
        /// Metodo che crea un Item scegliendo la classe corretta in base al tipo di prodotto che si sta creando.
        /// </summary>
        /// <param name="Name">Il nome del prodotto da creare.</param>
        /// <param name="SellIn">La SellIn del prodotto da creare.</param>
        /// <param name="Quality">La qualità del prodotto da creare.</param>
        /// <param name="Value">Il valore del prodotto da creare.</param>
        /// <returns>Il prodotto creato.</returns>
        public static Item CreaItem(string Name, int SellIn, int Quality, double Value)
        {
            switch (Name)
            {
                case "Aged Brie":
                    return new AgedBrie { Name = Name, SellIn = SellIn, Quality = Quality, Value = Value };
                case "Sulfuras, Hand of Ragnaros":
                    // Il sulfuras ha la quality sempre impostata a 80, quindi ignora il valore passato e metti la costante 80.
                    return new Sulfuras { Name = Name, SellIn = SellIn, Quality = 80, Value = Value };
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new Backastage { Name = Name, SellIn = SellIn, Quality = Quality, Value = Value };
                case "Conjured Mana Cake":
                    return new Conjured { Name = Name, SellIn = SellIn, Quality = Quality, Value = Value };
                default:
                    return new GenericItem { Name = Name, SellIn = SellIn, Quality = Quality, Value = Value };
            }
        }
    }
}
