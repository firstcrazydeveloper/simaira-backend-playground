using System;
using System.Collections.Generic;
using System.Linq;
using simaira_backend_playground.DataStructures.SortingAlgorithm.QuickSort;
using simaira_backend_playground.DataStructures.SortingAlgorithm.SimpleSorts.InsertSort;
using simaira_backend_playground.DataStructures.SortingAlgorithm.SimpleSorts.SelectionSort;
using simaira_backend_playground.UseCases.Animals.Abilities;
using simaira_backend_playground.UseCases.Animals.Classifications;
using simaira_backend_playground.UseCases.Animals.Visitors;

namespace simaira_backend_playground
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            #region Task 6: Tell all mammals to run (revisited)
            //Animals.All
            //    .OfClassification<Mammal>()
            //    .UseAbility<Run>((animal, run) =>
            //    {
            //        Console.WriteLine($"Scaring away {animal.Name}");
            //        Console.Write($"{animal.Name} Says");
            //        run.Start();
            //    });
            #endregion
            Selection sort = new Selection();
            var array = sort.InitialiseArray();
            Console.Write("Unsorted Array ");
            Console.Write("\n");
            for (int k = 0; k < array.Count; k++)
                Console.Write(array[k] + " ");
            Console.Write("\n");
            Console.WriteLine("**********Selection Sort**************************");           
            var sorted = sort.Sort(sort.InitialiseArray());
            Console.WriteLine("**********End Selection Sort**************************");

            Console.WriteLine("**********Insert Sort**************************");
            Insert sort2 = new Insert();
            var sorted2 = sort2.Sort(sort2.InitialiseArray());
            Console.WriteLine("**********End Insert Sort**************************");

            Console.WriteLine("**********Quick Sort**************************");
            Quick quick = new Quick();
            var sorted3 = quick.Sort(sort2.InitialiseArray(), 0 , sort2.InitialiseArray().Count-1);
            Console.WriteLine("**********End Quick Sort**************************");
            Console.ReadLine();
        }
    }
}
