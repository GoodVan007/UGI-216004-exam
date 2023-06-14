using NUnit.Framework.Interfaces;
using Storage;
using Warehouse;

namespace StorageUnitTestProject
{
    [TestFixture]
    public class StorageUnitTests
    {
        MarkedProduct productA = new MarkedProduct("A", new Size(4, 5, 6), 2.1, 9785922100205);
        Product productB = new Product("B", new Size(1, 2, 3), 1.5);
        
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

        [Test]
        public void LimitedWareHouseWithMarkingTest()
        {
            var storageWithMarking = new LimitedWarehouseWithMarkingAdapter(storageLWM);

            AssertStorageAddDeleteWithMarking(storageWithMarking, productA);
            //AssertStorageAddDeleteWithMarking(storageWithMarking, productB); - не реализует IMarked,
            //пока я не знаю как сделать, чтобы все работало - оставляю так.
            // Иначе говоря, Product B - не маркированный, а в этом хранилище только маркированные,
                   // из-за чего мы не можем компилировать код
        }

        [Test]
        public void UnlimitedWarehouseWithMarkingTest()
        {
            var storageWithMarking = new UnlimitedWarehouseWithmarkingAdapter(storageUWM);

            AssertStorageAddDeleteWithMarking(storageWithMarking, productA);
            //AssertStorageAddDeleteWithMarking(storageWithMarking, productB); - Аналогично
        }

        void AssertStorageAddDelete(IStorage storage, object item)
        {
            storage.Add(item);
            Assert.IsTrue(storage.Contains(item));

            storage.Remove(item);
            Assert.IsFalse(storage.Contains(item));
        }
        void AssertStorageAddDeleteWithMarking(IStorageWithMarking storage, IMarked item)
        {
            storage.Add(item);
            Assert.IsTrue(storage.Contains(item));

            storage.Remove(item);
            Assert.IsFalse(storage.Contains(item));
        }
    }
}
