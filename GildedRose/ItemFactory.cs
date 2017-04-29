using GildedRose.Prodotti;

namespace GildedRose
{
    public static class ItemFactory
    {
        public static Item CreaItem(string Name, int SellIn, int Quality)
        {
            switch (Name)
            {
                case "Aged Brie":
                    return new AgedBrie { Name = Name, SellIn = SellIn, Quality = Quality };
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras { Name = Name, SellIn = SellIn, Quality = Quality };
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new Backastage { Name = Name, SellIn = SellIn, Quality = Quality };
                case "Conjured Mana Cake":
                    return new Conjured { Name = Name, SellIn = SellIn, Quality = Quality };
                default:
                    return new GenericItem { Name = Name, SellIn = SellIn, Quality = Quality };
            }
        }
    }
}
