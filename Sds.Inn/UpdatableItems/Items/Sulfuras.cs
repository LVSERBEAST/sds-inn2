using Sds.Inn.DoNotChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sds.Inn.UpdatableItems.Items
{
    public class Sulfuras : IUpdatableItem
    {
        public Sulfuras(IUpdatableItem updatebleItem)
        {
            Item = updatebleItem.Item;
        }
        public Item Item { get; set; }

        public void Update()
        {
            --Item.SellIn;
        }
    }
}
