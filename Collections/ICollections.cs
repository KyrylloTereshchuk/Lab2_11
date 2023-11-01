
namespace Lab2
{
    public interface ICollections
    {

        IEnumerable<Employees> Employees { get; }
        IEnumerable<Employees> EmployeesWithoutEmployement { get; }
        IEnumerable<Employement> Employements { get; }
        IEnumerable<Salary> Salary { get; }
        IEnumerable<Company> Companies { get; }
    }
}
