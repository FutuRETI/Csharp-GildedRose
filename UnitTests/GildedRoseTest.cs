using NUnit.Framework;
using System.Collections.Generic;

/**
 * Questa classe contieiene un esempio di un test che potrete utilizzare come "traccia"
 * per l'implementazione dei vostri nuovi casi di test.
 * 
 * Come vedete il metodo di test (in questo caso chiamato foo) è suddiviso in tre parti distinte:
 * - given: è una parte preparatoria al caso di test vero e proprio, in questa parte del metodo
 *   vengono create tutte le precondizioni necessarie a permettere l'esecuzione del test vero
 *   e proprio
 * - when: è la parte in cui viene eseguita l'operazione che si sta testando; configurate tutte le
 *   precondizioni in questa parte viene eseguita una specifica funzionalità sotto test (in questo
 *   caso viene eseguito il metodo UpdateQuality)
 * - then: è l'ultima parte del test e contiene le ferifiche che devono essere fatte per accertarsi
 *   che la funzionalità sotto test abbia prodotto i risultati attesi (in questo caso è presente
 *   un'Assert che non verifica nessuna caratteristica rilevante del metodo UpdateQuality, ma test
 *   reali dovranno invece verificare proprietà significative della funzionalità testata).
 *   
 * Consigliamo di sviluppare tutti i test mantenendo questa struttura (proprio comprensiva anche delle
 * tre righe di commento che permettano di identificare le varie parti del metodo di test).
 **/
namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        [TestCase("Prodotto generico", 10, 10)]
        [TestCase("Prodotto generico", 1, 10)]
        public void AggiornaProdottoGenerico(string ItemName, int ItemSellIn, int ItemQuality) {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(ItemQuality - 1, Items[0].Quality);
        }

        [TestCase("Prodotto generico", 0, 10)]
        [TestCase("Prodotto generico", -1, 10)]
        public void AggiornaProdottoScaduto(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(ItemQuality - 2, Items[0].Quality);
        }

        [TestCase("Prodotto generico", 10, 0)]
        [TestCase("Prodotto generico", 10, -1)]
        [TestCase("Prodotto generico", 0, 0)]
        [TestCase("Prodotto generico", 0, -1)]
        [TestCase("Prodotto generico", -1, 0)]
        [TestCase("Prodotto generico", -1, -1)]
        public void QualityMaiNegativa(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [TestCase("Aged Brie", 10, 10)]
        [TestCase("Aged Brie", 1, 10)]
        public void AggiornaAgedBrie(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(ItemQuality + 1, Items[0].Quality);
        }

        [TestCase("Aged Brie", 0, 10)]
        [TestCase("Aged Brie", -1, 10)]
        public void AggiornaAgedBrieScaduto(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(ItemQuality + 2, Items[0].Quality);
        }

        [TestCase("Aged Brie", 10, 50)]
        [TestCase("Aged Brie", 0, 50)]
        [TestCase("Aged Brie", -1, 49)]
        public void QualityMaiMaggiore50(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 10)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 10)]
        public void AggiornaBackstage(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(ItemQuality + 1, Items[0].Quality);
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 10)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 8, 10)]
        public void AggiornaBackstageMeno10(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(ItemQuality + 2, Items[0].Quality);
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 10)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 2, 10)]
        public void AggiornaBackstageMeno5(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(ItemQuality + 3, Items[0].Quality);
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 10)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", -1, 10)]
        public void AggiornaBackstageScaduto(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [TestCase("Sulfuras, Hand of Ragnaros", 10, 10)]
        [TestCase("Sulfuras, Hand of Ragnaros", -10, 10)]
        [TestCase("Sulfuras, Hand of Ragnaros", 10, -10)]
        [TestCase("Sulfuras, Hand of Ragnaros", -10, -10)]
        public void AggiornaSulfuras(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [TestCase("Conjured Mana Cake", 10, 10)]
        [TestCase("Conjured Mana Cake", 1, 10)]
        public void AggiornaConjured(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(ItemQuality - 2, Items[0].Quality);
        }

        [TestCase("Conjured Mana Cake", 0, 10)]
        [TestCase("Conjured Mana Cake", -1, 10)]
        public void AggiornaConjuredScaduto(string ItemName, int ItemSellIn, int ItemQuality)
        {
            // given
            IList<Item> Items = new List<Item> { ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, 0.0) };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(ItemSellIn - 1, Items[0].SellIn);
            Assert.AreEqual(ItemQuality - 4, Items[0].Quality);
        }
    }
}
