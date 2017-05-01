using System;
using System.Collections.Generic;
using GildedRose.Prodotti;

namespace GildedRose
{
    public static class ItemFactory
    {
        public static readonly IList<string> NomeProdotti = new List<string>
        {
            "+5 Dexterity Vest",
            "Aged Brie",
            "Elixir of the Mongoose",
            "Sulfuras, Hand of Ragnaros",
            "Backstage passes to a TAFKAL80ETC concert",
            "Conjured Mana Cake"
        };

        public static string GetNomeProdottoRandom(Random Rand)
        {
            string ProdottoRichiesto = ItemFactory.NomeProdotti[Rand.Next(ItemFactory.NomeProdotti.Count)];
            return ProdottoRichiesto;
        }

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
