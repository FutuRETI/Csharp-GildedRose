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
        private IList<string> NomeProdotti;

        // Quando usato in modo "normale" il random è creato un un seed dipendente dall'orario di esecuzione
        public RetailService(IList<Item> Items)
        {
            this.Items = Items;
            this.NomeProdotti = GetProductNames();
            this.Rand = new Random(new DateTime().Millisecond);
        }
        
        // Questo costruttore permette di passare un seme al generatore di numeri casuali in modo da poter
        // rendere ripetibile un'esecuzione per i test.
        public RetailService(IList<Item> Items, IList<string> NomeProdotti, int RandomSeed)
        {
            this.Items = Items;
            this.NomeProdotti = NomeProdotti;
            this.Rand = new Random(RandomSeed);
        }

        public int GetNumeroClienti()
        {
            int RandomVal = Rand.Next();
            return MIN_CLIENTI + (RandomVal % (MAX_CLIENTI - MIN_CLIENTI));
        }

        public int GetNumeroOggetti()
        {
            int RandomVal = Rand.Next();
            return MIN_OGGETTI + (RandomVal % (MAX_OGGETTI - MIN_OGGETTI));
        }

        // Restituisce la lista dei nomi di prodotti che i clienti possono voler richiedere
        public virtual IList<string> GetProductNames()
        {
            return Items.Select(o => o.Name).ToList();
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
                    string ProdottoRichiesto = NomeProdotti[Rand.Next(NomeProdotti.Count)];
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
