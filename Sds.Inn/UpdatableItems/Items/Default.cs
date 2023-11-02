using Sds.Inn.DoNotChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sds.Inn.UpdatableItems.Items
{
    public class Default : IUpdatableItem
    {
        public Default(IUpdatableItem updatebleItem)
        {
            Item = updatebleItem.Item;
        }
        public Item Item { get; set; }

        public void Update()
        {
            var quality = Item.Quality;

            if (Item.SellIn > 0)
            {
                if (Item.Quality > 0)
                {
                    --quality;
                }
            }
            else if (Item.SellIn <= 0)
            {
                if (Item.Quality > 1)
                {
                    quality -= 2;
                }
                else
                {
                    quality = 0;
                }
            }
            else
            {
                quality = 0;
            }

            Item.Quality = quality;
            --Item.SellIn;
        }
    }
}
