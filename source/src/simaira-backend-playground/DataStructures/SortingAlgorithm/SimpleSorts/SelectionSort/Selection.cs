namespace simaira_backend_playground.DataStructures.SortingAlgorithm.SimpleSorts.SelectionSort
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Selection
    {
        public IList<int> InitialiseArray()
        {
            int[] array = new int[10] { 100, 50, 20, 40, 10, 60, 80, 70, 90, 30 };            
            return array;
        }

        public IList<int> Sort(IList<int> array)
        {
            int tmp, min_key;

            for (int j = 0; j < array.Count - 1; j++)
            {
                min_key = j;

                for (int k = j + 1; k < array.Count; k++)
                {
                    if (array[k] < array[min_key])
                    {
                        min_key = k;
                    }
                }

                tmp = array[min_key];
                array[min_key] = array[j];
                array[j] = tmp;
            }

            return array;
        }

        public void PrintArray(IList<int> array, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
