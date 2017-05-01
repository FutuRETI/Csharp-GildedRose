using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            // Crea un insieme di elementi già disponibili nella locanda.
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

            // Fai un ciclo di 31 giorni per simulare un mese di attività della locanda.
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");

                app.AcquistaForniture();    // Riceve il fonritore e decidi se acquistare dei prodotti.
                app.ServiClienti();         // Servi i clienti che entrano nella locanda durante la giornata di lavoro.
                app.UpdateQuality();        // Al termine della giornata, aggiorna la qualità di tutti i prodotti rimasti in locanda.

                Console.WriteLine("=> Cassa = " + app.Cassa);
            }

        }

    }
}
