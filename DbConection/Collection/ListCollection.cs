using Abstractions.Airport;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Collection
{
    public class ListCollection<T> : IEnumerable<T> where T : IAirportObj
    {
        private List<T> collection = new List<T>();

        public T this[int index]                  // how it named???
        {
            get { return collection[index]; }
            set { collection[index] = value; }
        }

        #region addDel

        public bool Del(T value)
        {
            return this.collection.Remove(value);
        }

        public void Add(T obj)
        {

            this.collection.Add(obj);

        }
        #endregion

        #region checkMethod

        public bool IsEmpy()
        {
            if (collection.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool ContainsValue(T value)
        {
            return collection.Contains(value);
        }

        #endregion

        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }


        #endregion IEnumerator

        #region Print

        public void Print()
        {
            foreach (var item in collection)
            {
                item.Print();
            }
        }

        #endregion
    }
}
