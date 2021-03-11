namespace simaira_backend_playground.DataStructures.SortingAlgorithm.SimpleSorts.InsertSort
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Insert
    {
        public IList<int> InitialiseArray()
        {
            int[] array = new int[10] { 100, 50, 20, 40, 10, 60, 80, 70, 90, 30 };
            return array;
        }

        public IList<int> Sort(IList<int> array)
        {
            for (int i = 1; i < array.Count; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                        j--;
                    }
                    else
                        break;
                }
                Console.Write("Iteration " + i.ToString() + ": ");
                for (int k = 0; k < array.Count; k++)
                    Console.Write(array[k] + " ");
                Console.Write("\n");
                //Console.Write("/*** " + (i + 1).ToString() + " numbers from the begining of the array are input and they are sorted ***/\n");    
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
