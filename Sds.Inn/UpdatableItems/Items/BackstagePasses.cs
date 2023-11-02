using Sds.Inn.DoNotChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sds.Inn.UpdatableItems.Items
{
    public class BackstagePasses : IUpdatableItem
    {
        public BackstagePasses(IUpdatableItem updatebleItem)
        {
            Item = updatebleItem.Item;
        }
        public Item Item { get; set; }

        public void Update()
        {
            var quality = Item.Quality;

            if (Item.SellIn > 0 && quality < 50)
            {
                ++quality;

                if (Item.SellIn < 11 && quality < 50)
                {
                    ++quality;
                }

                if (Item.SellIn < 6 && quality < 50)
                {
                    ++quality;
                }
            }
            else if (Item.SellIn <= 0)
            {
                quality = 0;
            }

            Item.Quality = quality;
            --Item.SellIn;
        }
    }
}
