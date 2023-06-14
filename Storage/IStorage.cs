using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse;

namespace Storage
{
    public interface IStorage
    {
        void Add(object item);
        void Remove(object item);
        bool Contains(object item);
    }
    public interface IStorageWithMarking
    {
        void Add(IMarked item);
        bool Contains(IMarked item);
        void Remove(IMarked item);
    }
}
