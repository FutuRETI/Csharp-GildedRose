using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                ItemFactory.CreaItem("+5 Dexterity Vest", 10, 20),
                ItemFactory.CreaItem("Aged Brie", 2, 0),
                ItemFactory.CreaItem("Elixir of the Mongoose", 5, 7),
                ItemFactory.CreaItem("Sulfuras, Hand of Ragnaros", 0, 80),
                ItemFactory.CreaItem("Sulfuras, Hand of Ragnaros", -1, 80),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 5, 49),
                // this conjured item does not work properly yet
                ItemFactory.CreaItem("Conjured Mana Cake", 3, 6)
            };

            var app = new GildedRose(Items);

            
            for (var i = 0; i < 31; i++)
            {
                System.Console.WriteLine("-------- day " + i + " --------");
                System.Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                System.Console.WriteLine("");
                app.UpdateQuality();
            }

        }

    }
}
