using NUnit.Framework;
using System.Collections.Generic;
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
    public class RetailServiceTest
    {
        [TestCase]
        public void NumeroClientiTra5e10() {
            // given
            IList<Item> Items = new List<Item> { };
            RetailService app = new RetailService(Items);

            // when
            int NumeroClienti = app.GetNumeroClienti();

            // then
            Assert.GreaterOrEqual(NumeroClienti, 5);
            Assert.GreaterOrEqual(10, NumeroClienti);
        }

        [TestCase]
        public void NumeroOggettiTra2e6()
        {
            // given
            IList<Item> Items = new List<Item> { };
            RetailService app = new RetailService(Items);

            // when
            int NumeroOggetti = app.GetNumeroOggetti();

            // then
            Assert.GreaterOrEqual(NumeroOggetti, 2);
            Assert.GreaterOrEqual(6, NumeroOggetti);
        }

        [TestCase]
        public void VendiUnOggetto()
        {
            // given
            Item Prodotto = ItemFactory.CreaItem("Conjured Mana Cake", 0, 10);
            IList<Item> Items = new List<Item> { Prodotto };
            RetailService app = new RetailService(Items);

            // when
            IList<Item> OggettiVenduti = app.GetProdottiVendutiOggi();

            // then
            Assert.AreEqual(1, OggettiVenduti.Count);
            Assert.True(OggettiVenduti.Contains(Prodotto));
            Assert.AreEqual(0, Items.Count);
        }

        [TestCase]
        public void ProvaAComprareOggettoMancante()
        {
            // given
            Item Prodotto = ItemFactory.CreaItem("Prodotto Inesistente", 0, 10);
            IList<Item> Items = new List<Item> { Prodotto };
            RetailService app = new RetailService(Items);

            // when
            IList<Item> OggettiVenduti = app.GetProdottiVendutiOggi();

            // then
            Assert.AreEqual(0, OggettiVenduti.Count);
            Assert.AreEqual(1, Items.Count);
            Assert.True(Items.Contains(Prodotto));
        }
    }
}
