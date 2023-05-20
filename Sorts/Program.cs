using System;
using System.Security.Cryptography.X509Certificates;

namespace Sorts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 5, 2, 10, 1, 6, 799, 9, 44 };

            var sorts = new Sorts();

            //sorts.MergeSort(arr, 0, arr.Length - 1);

            //sorts.QuickSort(arr, 0, arr.Length - 1);

            //sorts.RadixSort(arr, arr.Length);

            //sorts.BubleSort(arr, arr.Length);

            //sorts.CountingSort(arr);

            //sorts.GnomeSort(arr, arr.Length); 

            //sorts.InsertionSort(arr, arr.Length);

            sorts.SelectionSort(arr, arr.Length);

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

            var kek = 0;
        }
    }
}
