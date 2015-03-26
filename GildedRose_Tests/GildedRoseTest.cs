using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
	[TestClass]
	public class GildedRoseTest
	{
		[TestMethod]
		public void testStandardProductDecreaseBy1PreSellIn() {
            // given
			IList<Item> Items = new List<Item> { new Item{ Name = "foo", SellIn = 100, Quality = 10} };
			GildedRose app = new GildedRose(Items);

            // when
			app.UpdateQuality();

            // then
			Assert.AreEqual(9, Items[0].Quality);
		}

        [TestMethod]
        public void testStandardProductDecreaseBy2PostSellIn()
        {
            // given
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(8, Items[0].Quality);
        }

        [TestMethod]
        public void testConjuredProductDecreaseBy2PreSellIn()
        {
            // given
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 100, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(8, Items[0].Quality);
        }

        [TestMethod]
        public void testConjuredProductDecreaseBy4PostSellIn()
        {
            // given
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            // when
            app.UpdateQuality();

            // then
            Assert.AreEqual(6, Items[0].Quality);
        }
	}
}
