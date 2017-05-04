using System;
using GildedRose.Prodotti;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        readonly IList<Item> Items;
        readonly RetailService Vendita;
        readonly SupplyService Acquisto;

        public double Cassa { get; private set; }

        /// <summary>
        /// Costruttore per la classe GildedRose che gestisce l'intera locanda.
        /// </summary>
        /// <param name="Items">Lista di items presenti nella locanda all'avvio.</param>
        public GildedRose(IList<Item> Items) 
        {
            this.Items = Items;
            Vendita = new RetailService(Items);
            Acquisto = new SupplyService(Items);
            Cassa = 10000.0;
        }

        /// <summary>
        /// Costruttore usato per i test, accetta due Mock al posto del RetailService e del SupplyService.
        /// </summary>
        /// <param name="Items">Lista di items presenti nella locanda all'avvio.</param>
        /// <param name="Retail">Servizio che gestisce la parte di vendita ai clienti</param>
        /// <param name="Supply">Servizio che gestisce la parte di acquisto dei fornitori</param>
        public GildedRose(IList<Item> Items, RetailService Retail, SupplyService Supply)
        {
            this.Items = Items;
            Vendita = Retail;
            Acquisto = Supply;
            Cassa = 10000.0;
        }
        
        /// <summary>
        /// Metodo che aggiornala qualità di ogni oggetto presente nella locanda.
        /// Deve essere richiamato dopo ogni giorno.
        /// </summary>
        public void UpdateQuality()
        {
            foreach(Item Item in Items)
            {
                // Aggiorna la quality di tutti i prodotti
                (Item as GenericItem).UpdateQuality();

                // Aggiorna la sellin di tutti i prodotti
                (Item as GenericItem).UpdateSellIn();
            }
        }

        /// <summary>
        /// Metodo che serve i clienti che si presentano nel negozio nell'arco di una giornata.
        /// Recupera la lista dei prodotti venduti nel giorno e aggiorna lo stato della cassa.
        /// </summary>
        public void ServiClienti()
        {
            IList<Item> ProdottiVenduti = Vendita.GetProdottiVendutiOggi();

            foreach(Item Prodotto in ProdottiVenduti)
            {
                Cassa += (Prodotto as GenericItem).GetOfferPrice();
            }
        }

        /// <summary>
        /// Metodo che acquista i prodotti da un fornitore.
        /// I prodotti sono acquistati in modo casuale al momento...
        /// Recupera la lista dei prodotti che si desidera acquistare e aggiorna lo stato della cassa.
        /// </summary>
        public void AcquistaForniture()
        {
            Acquisto.ProponiOggetti();
            IList<Item> ProdottiAcquistati = Acquisto.AcquistaRandom();

            foreach (Item Prodotto in ProdottiAcquistati)
            {
                Cassa -= (Prodotto as GenericItem).GetPurchasePrice();
            }
        }

        public void StampaItems()
        {
            Console.WriteLine("name, sellIn, quality");
            foreach (Item Prodotto in Items)
            {
                Console.WriteLine(Prodotto.Name + ", " + Prodotto.SellIn + ", " + Prodotto.Quality);
            }
            Console.WriteLine("");
        }
    }
}