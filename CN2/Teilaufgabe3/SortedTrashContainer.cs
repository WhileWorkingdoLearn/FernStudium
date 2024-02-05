using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teilaufgabe3
{
    public class SortedTrashContainer<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _TrashContainer;
     
        private int _Capacity;

        private int _Count;

        public SortedTrashContainer(int capacity)
        {
            if(capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
            _TrashContainer = new T[capacity];
            _Capacity = capacity;
            _Count = 0;
        }

        public int Capacity
        {
            get { return _Capacity; }
        }

        public int Count
        {
            get { return _Count; }
        }

        public bool isFull
        {
            get { return _Count == _Capacity; }
        }
         
        public void Clear() {
               for(int  i = 0; i < _Capacity;i++)
            {
               _TrashContainer[i] = default(T);
 
            }
            _Count = 0;
        }

        public void Add(T item) {
            if (_Count > _Capacity) throw new InvalidOperationException(nameof(_Count));
            _TrashContainer[_Count] = item;            
            Array.Sort<T>(_TrashContainer,0,_Count);          
            _Count++;         
        }

        public T Remove() {
            
            if (_Count < 1) throw new InvalidOperationException(nameof(_Count));
            
           T item  = (T) _TrashContainer[_Count-1];
            _TrashContainer[_Count-1] = default(T);
            _Count--;
            return item; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0;i < _TrashContainer.Length;i++)
            {
               // Console.WriteLine(_TrashContainer[i].ToString());
                yield return  _TrashContainer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
