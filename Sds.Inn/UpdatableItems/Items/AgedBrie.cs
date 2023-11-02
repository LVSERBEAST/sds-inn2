using Sds.Inn.DoNotChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sds.Inn.UpdatableItems.Items
{
    public class AgedBrie : IUpdatableItem
    {
        public AgedBrie(IUpdatableItem updatebleItem)
        {
            Item = updatebleItem.Item;
        }
        public Item Item { get; set; }

        public void Update()
        {
            var quality = Item.Quality;

            if (quality < 50)
            {
                ++Item.Quality;
            }

            --Item.SellIn;
        }
    }
}
