using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class RetailService
    {
        // Costanti usate per stabilire i limiti dei generatori di numeri casuali
        private static readonly int MIN_CLIENTI = 5;
        private static readonly int MAX_CLIENTI = 10;
        private static readonly int MIN_OGGETTI = 2;
        private static readonly int MAX_OGGETTI = 6;

        private Random Rand;
        private IList<Item> Items;
        
        /// <summary>
        /// Costruttore che costruisce un servizio Retail per la vendita di prodotti ai clienti.
        /// </summary>
        /// <param name="Items">La lista di elementi presenti nella locanda.</param>
        public RetailService(IList<Item> Items)
        {
            this.Items = Items;
            Rand = new Random(new DateTime().Millisecond);
        }

        /// <summary>
        /// Metodo che restituisce il numero di clienti che entrano nella locanda in un giorno.
        /// Il metodo usa una funzione random per creare un numero casuale di ingressi nella locanda.
        /// </summary>
        /// <returns>Il numero di clienti entrati nella locanda nella giornata in corso</returns>
        public virtual int GetNumeroClienti()
        {
            return Rand.Next(MIN_CLIENTI, MAX_CLIENTI);
        }

        /// <summary>
        /// Metodo che restituisce il numero di oggetti che un cliente entrato nella locanda decide di comprare.
        /// Il metodo usa una funzione random per creare un numero casuale di oggetti da richiedere.
        /// </summary>
        /// <returns>Il numero di oggetti richiesto dal cliente</returns>
        public virtual int GetNumeroOggetti()
        {
            return Rand.Next(MIN_OGGETTI, MAX_OGGETTI);
        }

        /// <summary>
        /// Metodo che restituisce la lista di oggetti venduti nella giornata odierna.
        /// Per ogni cliente entrato in locanda, la lista include tutti gli oggetti richiesti dal cliente e disponibili nella locanda.
        /// </summary>
        /// <returns>La lista di elementi richiesti dai clienti entrati nella locanda nella giornata odierna</returns>
        public virtual IList<Item> GetProdottiVendutiOggi()
        {
            IList<Item> ProdottiVenduti = new List<Item>();

            // Ottieni un numero casuale che indichi quanti clienti sono entrati oggi nel negozio
            int NumClienti = GetNumeroClienti();
            while (NumClienti > 0)
            {
                // Per ogni cliente, ottieni un numero casuale che indichi quandi prodotti sono stati richiesti dal cliente
                int NumProdotti = GetNumeroOggetti();

                while (NumProdotti > 0)
                {
                    // Per ogni prodotto, scegli un nome a caso dalla lista dei prodotti che i clienti pososno richiedere
                    // e cerca un prodotto con quel nome
                    string ProdottoRichiesto = ItemFactory.GetNomeProdottoRandom(Rand);
                    Item Prodotto = Items.FirstOrDefault(o => o.Name == ProdottoRichiesto);

                    if (Prodotto != null)
                    {
                        // Se esiste un prodotto col nome uguale a quello richiesto dal cliente
                        // aggiungilo alla lista dei prodotti venduti e toglilo dalla lista dei
                        // prodotti disponibili per la vendita.
                        ProdottiVenduti.Add(Prodotto);
                        Items.Remove(Prodotto);
                    }

                    NumProdotti--;
                }

                NumClienti--;
            }

            return ProdottiVenduti;
        }
    }
}
