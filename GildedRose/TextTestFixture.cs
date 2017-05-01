using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                ItemFactory.CreaItem("+5 Dexterity Vest", 10, 20, 23.5),
                ItemFactory.CreaItem("Aged Brie", 2, 0, 12.0),
                ItemFactory.CreaItem("Elixir of the Mongoose", 5, 7, 5.5),
                ItemFactory.CreaItem("Sulfuras, Hand of Ragnaros", 0, 80, 6.8),
                ItemFactory.CreaItem("Sulfuras, Hand of Ragnaros", -1, 80, 7.2),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, 21.4),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 10, 49, 24.3),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 5, 49, 44.2),
                // this conjured item does not work properly yet
                ItemFactory.CreaItem("Conjured Mana Cake", 3, 6, 11.6)
            };

            var app = new GildedRose(Items);

            // Ciclo sui giorni
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");

                app.AcquistaForniture();
                app.ServiClienti();
                app.UpdateQuality();

                Console.WriteLine("=> Cassa = " + app.Cassa);
            }

        }

    }
}
