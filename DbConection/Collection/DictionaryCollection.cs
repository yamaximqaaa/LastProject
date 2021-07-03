using Abstractions.Airport;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DbConection.Collection
{
    // --- interact with elements only by keys ---
    public class DictionaryCollection<T>: IEnumerable<KeyValuePair<string, T>> where T: IAirportObj
    {
        // Keys
        // Plane key     - is plane number
        // Passanger key - is passport number
        private Dictionary<string, T> collection;
        public T this[string key]
        {
            get { return collection[key]; }
            set { collection[key] = value; }
        }

        #region constructor

        public DictionaryCollection()
        {
            this.collection = new Dictionary<string, T>();
        }

        #endregion

        #region addDel

        public void Del(string key)
        {
            try
            {
                this.collection.Remove(key);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Incorect key!");
            }
        }

        public void Add(string key, T obj)
        {
            try
            {
                this.collection.Add(key, obj);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
        }
        #endregion

        #region print

        #region printOneObj

        public void PrintOne(string key)
        {
            //collection[key].Print(key);
        }

        #endregion
        
        public void PrintAll()
        {
            if(IsEmpy())
            {
                Console.Clear();
                Console.WriteLine("Collection is empty!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return;
            }
            else
            {
                var i = 0;
                foreach (KeyValuePair<string, T> item in collection)
                {
                    i++;
                    Console.WriteLine("===============================");
                    Console.WriteLine("             #{0}                ", i);
                    Console.WriteLine("===============================");
                    //item.Value.Print(item.Key);
                }
            }
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
        public bool ContainsKey(string key)
        {
            return collection.ContainsKey(key);
        }
        public bool ContainsValue(T value)
        {
            return collection.ContainsValue(value);
        }

        #endregion

        #region IEnumerable

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
        {
            return collection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        #endregion IEnumerator

       
    }
}
