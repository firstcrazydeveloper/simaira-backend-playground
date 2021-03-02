namespace simaira_backend_playground.DesignPatterns.Structural.Composite
{
    using System.Collections.Generic;
    using System.Text;

    public class TeamLead : Employee
    {
        private readonly ICollection<Employee> _teamMembers ;
        public TeamLead(string name, double salary)
          : base(name, salary)
        {
            _teamMembers = new List<Employee>();
        }

        public override void Add(Employee employee)
        {
            _teamMembers.Add(employee);
        }

        public override void Remove(Employee employee)
        {
            _teamMembers.Remove(employee);
        }

        public override string GetData()
        {
            StringBuilder sbEmployee = new StringBuilder();

            foreach (Employee memeber in _teamMembers)
            {
                sbEmployee.Append(memeber.GetData() + "\n");

            }

            return sbEmployee.ToString();

        }
    }
}
