using DependencyInjectionExample.Interface;

namespace DependencyInjectionExample.Implementation
{
    class ContractEmployee : IEmployee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ContractEmployee()
        { }

        public ContractEmployee(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public decimal GetMinimumSalary()
        {
            return 1111;
        }
    }
}
