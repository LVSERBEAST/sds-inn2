using Sds.Inn.DoNotChange;
using Sds.Inn.UpdatableItems;
using Sds.Inn.UpdatableItems.Items;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sds.Inn;

public class Inventory : IInventory
{
    private readonly IItemProvider _itemProvider;
    private readonly IItemTypeDictionary _itemDictionary;

    public Inventory(IItemProvider itemProvider, IItemTypeDictionary itemDictionary)
    {
        _itemProvider = itemProvider;
        _itemDictionary = itemDictionary;
    }

    public virtual void UpdateQuality()
    {
        var items = _itemProvider.GetItems().ToArray();

        foreach (var item in items)
        {       
            Type itemType = _itemDictionary.ItemTypes[item.Name];
            UpdatableItem updatableItem = new(item);
            var itemInstance = Activator.CreateInstance(itemType, updatableItem) as IUpdatableItem;
            itemInstance?.Update();
        }
    }
}