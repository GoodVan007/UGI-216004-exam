using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse;

namespace Storage
{
    public class LimitedWarehouseWithMarkingAdapter : IStorageWithMarking
    {
        LimitedWareHouseWithMarking storageWithMarking;

        public LimitedWarehouseWithMarkingAdapter(LimitedWareHouseWithMarking warehouse)
        {
            storageWithMarking = warehouse;
        }
        public void Add(IMarked item)
        {
            if (item is IMarked markedtem)
                storageWithMarking.Push(item);
        }

        public bool Contains(IMarked item)
        {
            if (item is IMarked markedItem)
                return storageWithMarking.IsKeep(item);
            return false;
        }

        public void Remove(IMarked item)
        {
            if (item is IMarked markedItem)
                storageWithMarking.Delete(item);
        }
    }
}
