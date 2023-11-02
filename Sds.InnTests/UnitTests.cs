using Sds.Inn;
using Sds.Inn.DoNotChange;
using Sds.Inn.UpdatableItems;

namespace Sds.InnTests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 20, 19)]
        [InlineData("Elixir of the Mongoose", 5, 7, 6)]
        public void Default_OneLessDay_EqualsQualityMinusOne(string name, int sellIn, int quality, int expected)
        {
            Item item = new(name, sellIn, quality);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(expected, item.Quality);
        }

        [Theory]
        [InlineData("+5 Dexterity Vest", 0, 20, 18)]
        [InlineData("Elixir of the Mongoose", 0, 7, 5)]
        public void DefaultSellinZero_OneLessDay_EqualsQualityMinusTwo(string name, int sellIn, int quality, int expected)
        {
            Item item = new(name, sellIn, quality);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(expected, item.Quality);
        }

        [Fact]
        public void AgedBrie_OneLessDay_EqualsQualityPlusOne()
        {
            Item item = new("Aged Brie", 2, 0);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void AgedBrieAtZeroDays_OneLessDay_EqualsQualityPlusOne()
        {
            Item item = new("Aged Brie", 0, 0);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            // ORIGINAL CODE INCREASES BY 2, VERIFY THIS IS EXPECTED
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void Sulfuras_OneLessDay_EqualsSameQuality()
        {
            Item item = new("Sulfuras", 0, 80);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void BackstagePassesOverTenDays_OneLessDay_EqualsQualityPlusOne()
        {
            Item item = new("Backstage passes", 15, 20);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(21, item.Quality);
        }


        [Fact]
        public void BackstagePassesBetweenTenAndFiveDays_OneLessDay_EqualsQualityPlusTwo()
        {
            Item item = new("Backstage passes", 10, 20);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void BackstagePassesAtFiveDays_OneLessDay_equals_plus_3_quality()
        {
            Item item = new("Backstage passes", 5, 20);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void BackstagePassesAtZeroDays_OneLessDay_EqualsZeroQuality()
        {
            Item item = new("Backstage passes", 0, 20);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(0, item.Quality);
        }

        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 0, 0)]
        [InlineData("Elixir of the Mongoose", 5, 0, 0)]
        [InlineData("Backstage passes", 0, 10, 0)]
        [InlineData("Conjured", 5, 0, 0)]
        [InlineData("Conjured", 0, 3, 0)]
        [InlineData("Conjured", 5, 1, 0)]
        public void Quality_IsNever_Negative(string name, int sellIn, int quality, int expected)
        {
            Item item = new(name, sellIn, quality);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            // DOESN'T HANDLE ALREADY NEGATIVE QUALITY VALUES
            Assert.Equal(expected, item.Quality);
        }

        [Theory]
        [InlineData("Backstage passes", 15, 50, 50)]
        [InlineData("Aged Brie", 7, 50, 50)]
        public void Quality_IsNever_OverFifty(string name, int sellIn, int quality, int expected)
        {
            Item item = new(name, sellIn, quality);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            // ORIGINAL CODE BROKEN FOR BACKSTAGE PASSES
            Assert.Equal(expected, item.Quality);
        }

        [Fact]
        public void Conjured_OneLessDay_EqualsQualityMinusTwo()
        {
            Item item = new("Conjured", 3, 6);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(4, item.Quality);
        }

        [Fact]
        public void ConjuredAtZeroDays_OneLessDay_EqualsQualityMinusFour()
        {
            Item item = new("Conjured", 0, 6);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(2, item.Quality);
        }

        [Fact]
        public void ConjuredQualityOne_OneLessDay_QualityEqualsZero()
        {
            Item item = new("Conjured", 0, 1);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void ConjuredAtZeroDaysQualityThree_OneLessDay_QualityEqualsZero()
        {
            Item item = new("Conjured", 0, 3);
            TestItemProvider testItemProvider = new(new List<Item> { item });
            ItemTypeDictionary itemDictionary = new ItemTypeDictionary();
            Inventory inventory = new(testItemProvider, itemDictionary);

            inventory.UpdateQuality();

            Assert.Equal(0, item.Quality);
        }
    }
}