using Sds.Inn.DoNotChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sds.Inn.UpdatableItems
{
    public class UpdatableItem : IUpdatableItem
    {
        public UpdatableItem(Item item)
        {
            Item = item;
        }
        public Item Item { get; set; }

        public virtual void Update()
        {
            var quality = Item.Quality;
        }
    }
}
