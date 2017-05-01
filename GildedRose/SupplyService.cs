using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class SupplyService
    {
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

        public SupplyService(IList<Item> Items)
        {
            this.Items = Items;
            Rand = new Random(new DateTime().Millisecond);
        }

        public virtual int GetNumeroOggetti()
        {
            int RandomVal = Rand.Next();
            return MIN_OGGETTI + (RandomVal % (MAX_OGGETTI - MIN_OGGETTI));
        }

        public void ProponiOggetti()
        {
            OggettiProposti = new List<Item>();

            // Ottieni un numero casuale che indichi quanti oggetti sono presenti nella lista di acquisto
            int NumOggetti = GetNumeroOggetti();
            while (NumOggetti > 0)
            {
                // Genera un oggetto a caso a aggiungilo alla lista degli oggetti della lista di acquisto
                string Name = ItemFactory.GetNomeProdottoRandom(Rand);
                int SellIn = MIN_SELLIN + (Rand.Next() % (MAX_SELLIN - MIN_SELLIN));
                int Quality = MIN_QUALITY + (Rand.Next() % (MAX_QUALITY - MIN_QUALITY));
                double Value = (MIN_VALUE * 100 + (Rand.Next() % (MAX_VALUE - MIN_VALUE) * 100)) / 100;

                OggettiProposti.Add(ItemFactory.CreaItem(Name, SellIn, Quality, Value));
                NumOggetti--;
            }
        }

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
