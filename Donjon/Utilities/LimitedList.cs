using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon.Utilities
{
    public class LimitedList<T> : IEnumerable<T>
    {
        //hepp
        private List<T> list; // Constructorn does the init

        public int Capacity { get; }
        public bool IsFull => list.Count >= Capacity; // Change to property by removing ()
        public int Count => list.Count;


        public LimitedList(int capacity)
        {
            Capacity = capacity;
            list = new List<T>(capacity); // capacity, to be able to set size (not double allocation)
        }

        public bool Add(T item) // item == generic object
        {
            // Fail fast!
            if (IsFull) return false; // >= instead of ==, if there is a bug where a counter is too big
            list.Add(item);
            return true;
        }

        //private bool IsFull() => list.Count >= Capacity; // Change to property by removing ()

        public bool Remove(T item) => list.Remove(item);

        public IEnumerator<T> GetEnumerator()
        {
            ////Dummy, returns two empty lists
            //yield return default(T); //referenstyp: null, värdetyp: numerisk==0, etc
            //yield return default(T);

            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
