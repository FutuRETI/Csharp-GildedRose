using NUnit.Framework;
using System.Collections.Generic;
using GildedRose.Prodotti;
using NSubstitute;

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
    public class BusinessRulesTest
    {
        [TestCase("Conjured Mana Cake", 10, 10, 0.0, ExpectedResult = 0.0)]
        [TestCase("Conjured Mana Cake", 10, 10, 10.1, ExpectedResult = 101.0 )]
        [TestCase("Conjured Mana Cake", 10, 10, -10.1, ExpectedResult = -101.0)]
        public double PrezzoAcquisto(string ItemName, int ItemSellIn, int ItemQuality, double Value)
        {
            // given

            // when
            GenericItem Prodotto = (GenericItem) ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, Value);

            // then
            return Prodotto.GetPurchasePrice();
        }

        [TestCase("Conjured Mana Cake", 10, 10, 0.0, ExpectedResult = 0.0)]
        [TestCase("Conjured Mana Cake", 10, 10, 10.1, ExpectedResult = 151.5)]
        [TestCase("Conjured Mana Cake", 10, 10, -10.1, ExpectedResult = -151.5)]
        public double PrezzoVendita(string ItemName, int ItemSellIn, int ItemQuality, double Value)
        {
            // given

            // when
            GenericItem Prodotto = (GenericItem)ItemFactory.CreaItem(ItemName, ItemSellIn, ItemQuality, Value);

            // then
            return Prodotto.GetOfferPrice();
        }

        [TestCase]
        public void AggiornaCassaDopoVendita()
        {
            // given
            IList<Item> Prodotti = new List<Item>
            {
                ItemFactory.CreaItem("Conjured Mana Cake", 10, 10, 10.1),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, 5.0),
            };

            SupplyService Supply = null;
            RetailService Retail = Substitute.For<RetailService>(new List<Item> { });
            Retail.GetProdottiVendutiOggi().Returns(Prodotti);
            GildedRose app = new GildedRose(new List<Item> { }, Retail, Supply);

            double CassaAttesa = app.Cassa;
            foreach (GenericItem Prodotto in Prodotti)
            {
                CassaAttesa += Prodotto.Value * Prodotto.Quality * 1.5;
            }

            // when
            app.ServiClienti();

            // then
            Assert.AreEqual(CassaAttesa, app.Cassa);
        }

        [TestCase]
        public void AggiornaCassaDopoFornitura()
        {
            // given
            IList<Item> Prodotti = new List<Item>
            {
                ItemFactory.CreaItem("Conjured Mana Cake", 10, 10, 10.1),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, 5.0),
            };

            SupplyService Supply = Substitute.For<SupplyService>(new List<Item> { });
            RetailService Retail = null;
            Supply.AcquistaRandom().Returns(Prodotti);
            GildedRose app = new GildedRose(new List<Item> { }, Retail, Supply);

            double CassaAttesa = app.Cassa;
            foreach (GenericItem Prodotto in Prodotti)
            {
                CassaAttesa -= Prodotto.Value * Prodotto.Quality;
            }

            // when
            app.AcquistaForniture();

            // then
            Assert.AreEqual(CassaAttesa, app.Cassa);
        }
    }
}
