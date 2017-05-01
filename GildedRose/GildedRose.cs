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

        public GildedRose(IList<Item> Items) 
        {
            this.Items = Items;
            Vendita = new RetailService(Items);
            Acquisto = new SupplyService(Items);
            Cassa = 10000.0;
        }

        // Costruttore usato per i test, accetta due Mock al posto del RetailService e del SupplyService
        public GildedRose(IList<Item> Items, RetailService Retail, SupplyService Supply)
        {
            this.Items = Items;
            Vendita = Retail;
            Acquisto = Supply;
            Cassa = 10000.0;
        }

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

        public void ServiClienti()
        {
            IList<Item> ProdottiVenduti = Vendita.GetProdottiVendutiOggi();

            foreach(GenericItem Prodotto in ProdottiVenduti)
            {
                Cassa += Prodotto.GetOfferPrice();
            }
        }

        public void AcquistaForniture()
        {
            Acquisto.ProponiOggetti();
            IList<Item> ProdottiAcquistati = Acquisto.AcquistaRandom();

            foreach (GenericItem Prodotto in ProdottiAcquistati)
            {
                Cassa -= Prodotto.GetPurchasePrice();
            }
        }
    }
}