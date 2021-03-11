namespace simaira_backend_playground.DataStructures.SortingAlgorithm.QuickSort
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Quick
    {
        public IList<int> InitialiseArray()
        {
            int[] array = new int[10] { 100, 50, 20, 40, 10, 60, 80, 70, 90, 30 };
            return array;
        }

        public IList<int> Sort(IList<int> array, int start, int end)
        {
            if (start < end)
            {
                //stores the position of pivot element
                int piv_pos = partition(array, start, end);
                Sort(array, start, piv_pos - 1);    //sorts the left side of pivot.
                Sort(array, piv_pos + 1, end); //sorts the right side of pivot.                
            }

            return array;
        }
        public int partition(IList<int> array, int start, int end)
        {
            int i = start - 1;
            int piv = array[end];            //make the last element as pivot element.
            for (int j = start; j <= end - 1; j++)
            {
                /*rearrange the array by putting elements which are less than pivot
                   on left side and which are greater than pivot on right side. */

                if (array[j] <= piv)
                {
                    i++;
                    swap(array, i, j);
                }
            }

            swap(array, end, i + 1);  //put the pivot element in its proper place.            
            return i + 1;                      //return the position of the pivot
        }
        public void swap(IList<int> arr, int source, int target)
        {
            int temp = arr[source];
            arr[source] = arr[target];
            arr[target] = temp;
        }
    }
}
