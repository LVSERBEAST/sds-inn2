using Sds.Inn.DoNotChange;
using Sds.Inn.UpdatableItems.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sds.Inn.UpdatableItems
{
    public class ItemTypeDictionary : IItemTypeDictionary
    {
        public IDictionary<string, Type> ItemTypes { get; set; } = new Dictionary<string, Type>()
        {
            {"+5 Dexterity Vest", typeof(Default)},
            {"Aged Brie", typeof(AgedBrie)},
            {"Elixir of the Mongoose", typeof(Default)},
            {"Sulfuras", typeof(Sulfuras)},
            {"Backstage passes", typeof(BackstagePasses)},
            {"Conjured", typeof(Conjured)},
        };
    }
}
