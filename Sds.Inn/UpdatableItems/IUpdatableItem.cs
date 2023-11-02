using Sds.Inn.DoNotChange;

namespace Sds.Inn.UpdatableItems
{
    public interface IUpdatableItem
    {
        Item Item { get; set; }
        void Update();
    }
}