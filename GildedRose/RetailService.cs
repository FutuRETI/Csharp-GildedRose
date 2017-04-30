using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class RetailService
    {
        private static readonly int MIN_CLIENTI = 5;
        private static readonly int MAX_CLIENTI = 10;
        private static readonly int MIN_OGGETTI = 2;
        private static readonly int MAX_OGGETTI = 6;

        private Random Rand;
        private IList<Item> Items;

        public RetailService(IList<Item> Items)
        {
            this.Items = Items;
            Rand = new Random(new DateTime().Millisecond);
        }

        public virtual int GetNumeroClienti()
        {
            int RandomVal = Rand.Next();
            return MIN_CLIENTI + (RandomVal % (MAX_CLIENTI - MIN_CLIENTI));
        }

        public virtual int GetNumeroOggetti()
        {
            int RandomVal = Rand.Next();
            return MIN_OGGETTI + (RandomVal % (MAX_OGGETTI - MIN_OGGETTI));
        }

        public List<Item> GetProdottiVendutiOggi()
        {
            List<Item> ProdottiVenduti = new List<Item>();

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
