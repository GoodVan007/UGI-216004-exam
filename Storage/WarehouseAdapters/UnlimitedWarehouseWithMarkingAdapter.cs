using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse;

namespace Storage
{
    public class UnlimitedWarehouseWithmarkingAdapter : IStorageWithMarking
    {
        UnlimitedWarehouseWithMarking storageWithMarking;

        public UnlimitedWarehouseWithmarkingAdapter(UnlimitedWarehouseWithMarking warehouse)
        {
            storageWithMarking = warehouse;
        }
        public void Add(IMarked item)
        {
            //if (item is IMarked markedItem)
                storageWithMarking.Put(item);
        }

        public bool Contains(IMarked item)
        {
            if (item is IMarked markedItem)
                return storageWithMarking.IsKeep(item);

            return false;
        }

        public void Remove(IMarked item)
        {
            //if (item is IMarked markedItem)
                storageWithMarking.Drop(item);
        }
    }
}
