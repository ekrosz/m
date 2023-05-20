using System;

namespace Structures
{
    public class HashTable
    {
        private int[][] _hashMap;

        private const int EmptyValue = -999;

        private const double MaxFullnessRate = 0.8;

        public HashTable(int size)
        {
            _hashMap = new int[size][];

            for (var i = 0; i < size; i++)
            {
                _hashMap[i] = new int[1];
                _hashMap[i][0] = EmptyValue;
            }
        }

        public void Add(int value)
        {
            CheckFullnessAndResize();

            AddValue(_hashMap, value);
        }

        public void Remove(int value)
        {
            var index = HashFunction(value, _hashMap.Length);

            var i = 0;

            while (index + i < _hashMap.Length && _hashMap[index + i][0] != value)
            {
                i++;
            }

            if (index + i == _hashMap.Length)
            {
                Console.WriteLine("Value not found.");
                return;
            }

            _hashMap[index + i][0] = EmptyValue;
        }

        public void Display()
        {
            for (int i = 0; i < _hashMap.Length; i++)
            {
                Console.WriteLine($"{i} --> {_hashMap[i][0]}");
            }
        }

        private int HashFunction(int value, int size)
        {
            return (Math.Abs(value) * 13 + 17 >> 2) % size;
        }

        private void AddValue(int[][] hashMap, int value)
        {
            var index = HashFunction(value, hashMap.Length);

            if (hashMap[index][0] == EmptyValue)
            {
                hashMap[index][0] = value;
                return;
            }

            var i = 1;

            while (index + i < hashMap.Length && hashMap[index + i][0] != EmptyValue)
            {
                i++;
            }

            if (index + i == hashMap.Length)
            {
                Console.WriteLine("Bad hash function!");
                return;
            }

            hashMap[index + i][0] = value;
        }

        private void CheckFullnessAndResize()
        {
            var counter = 0;

            foreach (var arr in _hashMap)
            {
                if (arr[0] != EmptyValue)
                {
                    counter++;
                }
            }

            if (counter / (double)_hashMap.Length <= MaxFullnessRate)
            {
                return;
            }

            var newSize = _hashMap.Length * 2;
            var tempHashMap = new int[newSize][];

            for (var i = 0; i < newSize; i++)
            {
                tempHashMap[i] = new int[1];
                tempHashMap[i][0] = EmptyValue;
            }

            for (var i = 0; i < _hashMap.Length; i++)
            {
                AddValue(tempHashMap, _hashMap[i][0]);
            }

            _hashMap = tempHashMap;
        }
    }
}
