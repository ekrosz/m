using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public class Sorts
    {
        #region Сортировка слиянием
        //Пространственная сложность алгоритма сортировки слиянием составляет O(N) 
        //Временная сложность алгоритма сортировки слиянием составляет O(N*log N)
        private void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            var arrayLeft = new int[n1];
            var arrayRight = new int[n2];

            for (int i = 0; i < n1; i++)
                arrayLeft[i] = arr[left + i];

            for (int j = 0; j < n2; j++)
                arrayRight[j] = arr[middle + 1 + j];
            
            int i1 = 0;
            int j1 = 0;
            int k = left;

            while (i1 < n1 && j1 < n2)
            {
                if (arrayLeft[i1] <= arrayRight[j1])
                {
                    arr[k] = arrayLeft[i1];
                    i1++;
                }

                else
                {
                    arr[k] = arrayRight[j1];
                    j1++;
                }

                k++;
            }

            while (i1 < n1) 
            {
                arr[k] = arrayLeft[i1];
                i1++;
                k++;
            }

            while (j1 < n2)
            {
                arr[k] = arrayRight[j1];
                j1++;
                k++;
            }
        }

        public void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }
        }
        #endregion

        #region Быстрая сортировка
        //пространственная сложность алгоритма быстрой сортировки составляет O(N logN)
        public int[] QuickSort(int[] arr, int left, int right)
        {
            var i = left;
            var j = right;
            var pivot = arr[left];

            while (i < j)
            {
                while (arr[i] < pivot)
                {
                    i++;
                }

                while (arr[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(arr, left, j);
            }

            if (i < right)
            {
                QuickSort(arr, i, right);
            }

            return arr;
        }
        #endregion

        #region Поразрядная сортировка
        //Пространственная сложность O(n)
        //временная сложность O(d*n) , где d — количество цифр в наибольшем числе, а n — количество элементов в массиве. 
        private int MaxVal(int[] arr, int size)
        {
            var maxVal = arr[0];

            for (int i = 1; i < size; i++)
                if (arr[i] > maxVal)
                    maxVal = arr[i];

            return maxVal;
        }

        private void Sort(int[] arr, int size, int exponent)
        {
            var outputArr = new int[size];
            var occurences = new int[10];

            for (int i = 0; i < 10; i++)
                occurences[i] = 0;

            for (int i = 0; i < size; i++)
                occurences[(arr[i] / exponent) % 10]++;

            for (int i = 1; i < 10; i++)
                occurences[i] += occurences[i - 1];

            for (int i = size - 1; i >= 0; i--)
            {
                outputArr[occurences[(arr[i] / exponent) % 10] - 1] = arr[i];
                occurences[(arr[i] / exponent) % 10]--;
            }
            for (int i = 0; i < size; i++)
                arr[i] = outputArr[i];
        }
        public int[] RadixSort(int[] arr, int size)
        {
            var maxVal = MaxVal(arr, size);

            for (int exponent = 1; maxVal / exponent > 0; exponent *= 10)
                Sort(arr, size, exponent);

            return arr;
        }
        #endregion

        #region Сортировка пузырьком
        // Сложность O(n^2)
        public int[] BubleSort(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            return arr;
        }
        #endregion

        #region Сортировка подсчетом
        //Сложность O(1 + n) или O(n)
        private int GetMaxVal(int[] arr, int size)
        {
            int maxVal = arr[0];

            for (int i = 1; i < size; i++)
            {
                if (arr[i] > maxVal)
                {
                    maxVal = arr[i];
                }
            }

            return maxVal;
        }

        public int[] CountingSort(int[] arr)
        {
            var size = arr.Length;
            var maxVal = GetMaxVal(arr, size);
            var occurensec = new int[maxVal + 1];

            for (int i = 0; i < maxVal + 1; i++)
                occurensec[i] = 0;

            for (int i = 0; i < size; i++)
                occurensec[arr[i]]++;

            for (int i = 0, j = 0; i < maxVal + 1; i++)
            {
                while (occurensec[i] > 0)
                {
                    arr[j] = i;
                    j++;
                    occurensec[i]--;
                }
            }
            return arr;
        }
        #endregion

        #region Гномья сортировка
        public int[] GnomeSort(int[] arr, int size)
        {
            int i = 0;

            while (i < size)
            {
                if (i == 0)
                    i++;

                if (arr[i] >= arr[i - 1])
                {
                    i++;
                }

                else 
                {
                    int temp = arr[i];
                    arr[i] = arr[i-1];
                    arr[i - 1] = temp;
                    i--;
                }
            }

            return arr;
        }
        #endregion

        #region Сортировка вставками
        public int[] InsertionSort(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }

            return arr;
        }
        #endregion

        #region Сортировка выбором
        public int[] SelectionSort(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < size; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            return arr;
        }
        #endregion
    }
}
