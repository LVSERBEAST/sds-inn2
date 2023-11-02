using Sds.Inn.DoNotChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sds.Inn.UpdatableItems.Items
{
    public class Conjured : IUpdatableItem
    {
        public Conjured(IUpdatableItem updatebleItem)
        {
            Item = updatebleItem.Item;
        }

        public Item Item { get; set; }

        public void Update()
        {
            var quality = Item.Quality;

            if (Item.SellIn > 0)
            {
                if (quality > 1)
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
                if (quality > 3)
                {
                    quality -= 4;
                }
                else
                {
                    quality = 0;
                }
            }

            Item.Quality = quality;
            --Item.SellIn;
        }
    }
}
