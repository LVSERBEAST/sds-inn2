using Sds.Inn.DoNotChange;

namespace Sds.InnTests
{
    internal class TestItemProvider : IItemProvider
    {
        private IEnumerable<Item> _items;

        public TestItemProvider(IEnumerable<Item> items)
        {
            _items = items;
        }

        public IEnumerable<Item> GetItems()
        {
            return _items.ToArray();
        }
    }
}
