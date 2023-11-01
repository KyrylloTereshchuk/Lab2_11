
namespace Lab2
{
    public interface IQueries
    {
        public IEnumerable<Employees> GetEmployees();
        public IEnumerable<string> GetCompaniesName();
        public IEnumerable<Employees> GetAllEmployees();
        public int GetEmployeesCountWithEducation(string education);
        public IEnumerable<Employees> GetSortedEmployees(string sort);
        public IEnumerable<string> GetCompaniesStartWith(string symbol);
        public IEnumerable<Employement> GetEmployeesIdBiggerThan(int id);
        public IEnumerable<string> GetEmployeesSalariesId();
        public IEnumerable<string> GetSpecificRollNumbers(string symbols);
        public string? GetYoungestEmployee();
        public IEnumerable<Employees> GetEmployeesFromTo(int min, int max);
        public IEnumerable<string> GetEmployementEmployees();
        public Employement[] GetEmployeesArray();
        public string GetAllRollNumbers();
        public string GetFirstEmployeeWithIdBiggerThan(int employeeId);
        public IEnumerable<string> GetIdByName();
    }
}
