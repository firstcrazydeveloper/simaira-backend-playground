namespace simaira_backend_playground.DesignPatterns.Structural.Composite
{
    using System;

    public class TeamMember : Employee
    {
        // Constructor

        public TeamMember(string name, double salary)
          : base(name, salary)
        {
        }

        public override void Add(Employee employee)
        {
            Console.WriteLine(
              "Cannot add to a leaf node");
        }

        public override void Remove(Employee employee)
        {
            Console.WriteLine(
              "Cannot add to a leaf node");
        }

        public override string GetData()
        {
            return "Name: " + _name + "\tSalary: " + _salary.ToString("N2");
        }
    }
}
