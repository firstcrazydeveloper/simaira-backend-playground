using System;
using System.Collections.Generic;
using System.Linq;
using simaira_backend_playground.UseCases.Animals.Abilities;
using simaira_backend_playground.UseCases.Animals.Classifications;
using simaira_backend_playground.UseCases.Animals.Visitors;

namespace simaira_backend_playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Task 6: Tell all mammals to run (revisited)
            Animals.All
                .OfClassification<Mammal>()
                .UseAbility<Run>((animal, run) =>
                {
                    Console.WriteLine($"Scaring away {animal.Name}");
                    Console.Write($"{animal.Name} Says");
                    run.Start();
                });
            #endregion
            Console.ReadLine();
        }
    }
}
