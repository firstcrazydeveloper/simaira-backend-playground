namespace simaira_backend_playground.DesignPatterns.Structural.Composite
{
    public abstract class Employee
    {
        protected string _name;
        protected double _salary;

        public Employee(string name, double salary)
        {
            this._name = name;
            this._salary = salary;
        }

        public abstract void Add(Employee employee);
        public abstract void Remove(Employee employee);
        public abstract string GetData();
    }
}
