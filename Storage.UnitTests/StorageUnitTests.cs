using Storage;
using Warehouse;

namespace StorageUnitTestProject
{
    [TestFixture]
    public class StorageUnitTests
    {
        MarkedProduct productA = new MarkedProduct("A", new Size(4, 5, 6), 2.1, 9785922100205);
        Product productB = new Product("B", new Size(1, 2, 3), 1.5);
        //удаляем продукт Б, так как нарушается принцип LSP
        // Продукт Б не реализует интерфейс IMarked

        LimitedWarehouse storageLW = new LimitedWarehouse(5);
        LimitedWareHouseWithMarking storageLWM = new LimitedWareHouseWithMarking(8);
        UnlimitedWarehouse storageUW = new UnlimitedWarehouse();
        UnlimitedWarehouseWithMarking storageUWM = new UnlimitedWarehouseWithMarking();

        [Test]
        public void LimitedWarehouseTest()
        {
            var storage = new LimitedWarehouseAdapter(storageLW);

            AssertStorageAddDelete(storage, productA);
            AssertStorageAddDelete(storage, productB);
        }

        [Test]
        public void UnlimitedWarehouseTest()
        {
            var storage = new UnlimitedWarehouseAdapter(storageUW);

            AssertStorageAddDelete(storage, productA);
            AssertStorageAddDelete(storage, productB);
        }

        //[Test]
        //public void LimitedWareHouseWithMarkingTest()
        //{
        //    var storage = new LimitedWarehouseWithMarkingAdapter(storageLWM);

        //    AssertStorageAddDelete(storage, productA);
        //    AssertStorageAddDelete(storage, productB);
        //}

        //[Test]
        //public void UnlimitedWarehouseWithMarkingTest()
        //{
        //    var storage = new UnlimitedWarehouseWithmarkingAdapter(storageUWM);

        //    AssertStorageAddDelete(storage, productA);
        //    AssertStorageAddDelete(storage, productB);
        //}

        void AssertStorageAddDelete(IStorage storage, object item)
        {
            storage.Add(item);
            Assert.IsTrue(storage.Contains(item));

            storage.Remove(item);
            Assert.IsFalse(storage.Contains(item));
        }
    }
}
