using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class SupplyService
    {
        // Costanti usate per stabilire i limiti dei generatori di numeri casuali
        private static readonly int MIN_OGGETTI = 40;
        private static readonly int MAX_OGGETTI = 60;
        private static readonly int MIN_SELLIN = 10;
        private static readonly int MAX_SELLIN = 20;
        private static readonly int MIN_QUALITY = 10;
        private static readonly int MAX_QUALITY = 50;
        private static readonly int MIN_VALUE = 10;
        private static readonly int MAX_VALUE = 50;

        private Random Rand;
        private IList<Item> Items;
        public IList<Item> OggettiProposti;

        /// <summary>
        /// Costruttore che costruisce un servizio Supply per l'acquisto di prodotti da fornitori.
        /// </summary>
        /// <param name="Items">La lista di elementi presenti nella locanda.</param>
        public SupplyService(IList<Item> Items)
        {
            this.Items = Items;
            Rand = new Random(new DateTime().Millisecond);
        }

        /// <summary>
        /// Metodo che restituisce il numero di oggetti offerti da un fornitore.
        /// Il metodo usa una funzione random per creare un numero casuale di oggetti disponibili.
        /// </summary>
        /// <returns>Il numero di oggetti offerti dal fornitore per l'acquisto</returns>
        public virtual int GetNumeroOggetti()
        {
            return Rand.Next(MIN_OGGETTI, MAX_OGGETTI);
        }

        /// <summary>
        /// Metodo che crea una lista di prodotti offerti dal fornitore.
        /// Questo metodo genera un numero casuale di elementi e aggiorna lo stato del servizio supply in modo da includere
        /// tutti e soli gli oggetti offerti dal fornitore.
        /// </summary>
        public void ProponiOggetti()
        {
            OggettiProposti = new List<Item>();

            // Ottieni un numero casuale che indichi quanti oggetti sono presenti nella lista di acquisto
            int NumOggetti = GetNumeroOggetti();
            while (NumOggetti > 0)
            {
                // Genera un oggetto a caso a aggiungilo alla lista degli oggetti della lista di acquisto
                string Name = ItemFactory.GetNomeProdottoRandom(Rand);
                int SellIn = Rand.Next(MIN_SELLIN, MAX_SELLIN);
                int Quality = Rand.Next(MIN_QUALITY, MAX_QUALITY);
                double Value = (double) Rand.Next(MIN_VALUE * 100 , MAX_VALUE * 100) / 100;

                OggettiProposti.Add(ItemFactory.CreaItem(Name, SellIn, Quality, Value));
                NumOggetti--;
            }
        }

        /// <summary>
        /// Metodo che permette di acquistare un prodotto dal fornitore.
        /// </summary>
        /// <param name="Prodotto">Il prodotto che si desidera acquistare.</param>
        public void CompraProdotto(Item Prodotto)
        {
            // Se il prodotto è realmente tra quelli disponibili, acquistalo
            // eliminandolo dagli oggetti proposti e includendolo in quelli a dispoizione (lista Items)
            if (OggettiProposti.Contains(Prodotto))
            {
                OggettiProposti.Remove(Prodotto);
                Items.Add(Prodotto);
            }
        }
        
        /// <summary>
        /// Metodo che, per tutti i prodotti offerti dal fornitore, decide in modo casuale se acquistare o meno
        /// il prodotto.
        /// </summary>
        /// <returns>La lista degi prodotti acquistati.</returns>
        public virtual IList<Item> AcquistaRandom()
        {
            // Scorro tutti gli oggetti proposti e, in modo random, decido se comprarli o meno.
            IList<Item> OggettiDaComprare = new List<Item>();
            foreach(Item Oggetto in OggettiProposti)
            {
                if (Rand.Next() % 2 == 1)
                {
                    OggettiDaComprare.Add(Oggetto);
                }
            }

            // Per tutti gli oggetti da comprare richiaam il metodo CompraProdotto.
            foreach(Item Oggetto in OggettiDaComprare)
            {
                CompraProdotto(Oggetto);
            }

            return OggettiDaComprare;
        }
    }
}
