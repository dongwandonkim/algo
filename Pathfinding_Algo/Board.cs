using System;
using System.Collections.Generic;

namespace Pathfinding_Algo
{
    public class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];

        public int Count = 0; // real usage data
        public int Capacity { get { return _data.Length; } }// reserved data

        public void Add(T item)
        {
            // check if enough room available
            if (Count >= Capacity)
            {
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _data[i];
                }
                _data = newArray;
            }

            //
            _data[Count] = item;
            Count++;
        }

        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[Count - 1] = default(T);

            Count--;
        }
    }

    public class Board
    {
        public int[] _data = new int[25];
        public MyList<int> _data2 = new MyList<int>();
        public LinkedList<int> _data3 = new LinkedList<int>();

        public Board()
        {
        }

        public void ListInitialize()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);
        }
    }
}

