using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
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
    public class SupplyServiceTest
    {
        [TestCase]
        public void NumeroOggettiTra40e60()
        {
            // given
            IList<Item> Items = new List<Item> { };
            SupplyService app = new SupplyService(Items);

            // when
            int NumeroOggetti = app.GetNumeroOggetti();

            // then
            Assert.GreaterOrEqual(NumeroOggetti, 40);
            Assert.GreaterOrEqual(60, NumeroOggetti);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void ProponiOggetti(int NumeroOggetti)
        {
            // given
            IList<Item> Items = new List<Item> { };
            SupplyService app = Substitute.For<SupplyService>(Items);
            app.GetNumeroOggetti().Returns(NumeroOggetti);

            // when
            app.ProponiOggetti();

            // then
            Assert.GreaterOrEqual(app.OggettiProposti.Count, NumeroOggetti);
            foreach (string Name in app.OggettiProposti.Select(o => o.Name).ToList())
            {
                CollectionAssert.Contains(ItemFactory.NomeProdotti, Name);
            }
        }
        
        [TestCase]
        public void CompraOggetto()
        {
            // given
            IList<Item> Prodotti = new List<Item>
            {
                ItemFactory.CreaItem("Sulfuras, Hand of Ragnaros", -1, 80, 0.0),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, 0.0),
            };
            IList<Item> Items = new List<Item> { };
            SupplyService app = Substitute.For<SupplyService>(Items);
            app.OggettiProposti = new List<Item>(Prodotti);

            // when
            app.CompraProdotto(Prodotti[0]);

            // then
            Assert.AreEqual(1, Items.Count);
            Assert.AreEqual(1, app.OggettiProposti.Count);
            CollectionAssert.Contains(Items, Prodotti[0]);
            CollectionAssert.Contains(app.OggettiProposti, Prodotti[1]);
        }

        [TestCase]
        public void CompraPiùOggetti()
        {
            // given
            IList<Item> Prodotti = new List<Item>
            {
                ItemFactory.CreaItem("Sulfuras, Hand of Ragnaros", -1, 80, 0.0),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, 0.0),
            };
            IList<Item> Items = new List<Item> { };
            SupplyService app = Substitute.For<SupplyService>(Items);
            app.OggettiProposti = new List<Item>(Prodotti);

            // when
            app.CompraProdotto(Prodotti[0]);
            app.CompraProdotto(Prodotti[1]);

            // then
            Assert.AreEqual(2, Items.Count);
            Assert.AreEqual(0, app.OggettiProposti.Count);
            CollectionAssert.Contains(Items, Prodotti[0]);
            CollectionAssert.Contains(Items, Prodotti[1]);
        }

        [TestCase]
        public void CompraOggettoCheNonEsiste()
        {
            // given
            IList<Item> Prodotti = new List<Item>
            {
                ItemFactory.CreaItem("Sulfuras, Hand of Ragnaros", -1, 80, 0.0),
                ItemFactory.CreaItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, 0.0),
            };
            Item ProdottoInesistente = ItemFactory.CreaItem("Prodotto inesistente", 5, 10, 0.0);
            IList<Item> Items = new List<Item> { };
            SupplyService app = Substitute.For<SupplyService>(Items);
            app.OggettiProposti = new List<Item>(Prodotti);

            // when
            app.CompraProdotto(ProdottoInesistente);

            // then
            Assert.AreEqual(0, Items.Count);
            CollectionAssert.Contains(app.OggettiProposti, Prodotti[0]);
            CollectionAssert.Contains(app.OggettiProposti, Prodotti[1]);
        }
    }
}
