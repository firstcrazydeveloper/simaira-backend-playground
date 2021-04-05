using System;
using System.Collections.Generic;
using System.Linq;
using simaira_backend_playground.CSharp;
using simaira_backend_playground.DataStructures.SortingAlgorithm.QuickSort;
using simaira_backend_playground.DataStructures.SortingAlgorithm.SimpleSorts.InsertSort;
using simaira_backend_playground.DataStructures.SortingAlgorithm.SimpleSorts.SelectionSort;
using simaira_backend_playground.UseCases.Animals.Abilities;
using simaira_backend_playground.UseCases.Animals.Classifications;
using simaira_backend_playground.UseCases.Animals.Visitors;
using simaira_backend_playground.UseCases.Calculators;

namespace simaira_backend_playground
{
    class Program
    {
        static void Main(string[] args)
        {

            Calculator calc = new Calculator();
            calc.SetInput(Convert.ToString(9));
            Console.WriteLine(calc.GetHistory());
            calc.SetInput("-");
            Console.Clear();
            Console.WriteLine(calc.GetHistory());
            calc.SetInput(Convert.ToString(4));
            Console.Clear();
            Console.WriteLine(calc.GetHistory());
            calc.SetInput("+");
            Console.Clear();
            Console.WriteLine(calc.GetHistory());
            calc.SetInput(Convert.ToString(2));
            Console.Clear();
            Console.WriteLine(calc.GetHistory());
            calc.SetInput("-");
            Console.Clear();
            Console.WriteLine(calc.GetHistory());
            Console.WriteLine(calc.Result);

            Console.ReadLine();
        }

        static void ObjectScenarion()
        {
            Parent parent = new Parent();
            Child child = new Child();
            Parent pChild = new Child();

            Parent parent2 = new Parent();
            parent2 = child;

            Parent parent3 = new Parent();
            parent3 = pChild;

            // Parent
            Console.WriteLine();
            Console.WriteLine("*****************Parent**************************");
            parent.SimpleParentMethod();
            parent.ParentMethod();
            parent.VirtualParentMethod();

            // child
            Console.WriteLine();
            Console.WriteLine("*****************Child**************************");
            child.SimpleParentMethod();
            child.ParentMethod();
            child.VirtualParentMethod();
            child.SimpleChildMethod();



            // parent >> child
            Console.WriteLine();
            Console.WriteLine("*****************Parent p= new Child()**************************");
            pChild.SimpleParentMethod();
            pChild.ParentMethod();
            pChild.VirtualParentMethod();
            // pChild.SimpleChildMethod(); >> even parent have new child but object can not get child method only parent behaviour is there

            // child
            Console.WriteLine();
            Console.WriteLine("******************Parent parent2= new Parent(), parent2 = child**************************");
            parent2.SimpleParentMethod();
            parent2.ParentMethod();
            parent2.VirtualParentMethod();
            // parent2.SimpleChildMethod(); >> even parent have new child but object can not get child method only parent behaviour is there
        }

        static void BirdsScenario()
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
            var sorted3 = quick.Sort(sort2.InitialiseArray(), 0, sort2.InitialiseArray().Count - 1);
            Console.WriteLine("**********End Quick Sort**************************");
            Console.ReadLine();
        }
    }
}
