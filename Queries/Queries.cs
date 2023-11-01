using System.Xml.Linq;

namespace Lab2
{
    public class Queries : IQueries
    {
        private readonly XmlContext _xmlContext;
        
        public Queries(XmlContext xmlContext)
        {
            _xmlContext = xmlContext;
            
        }

        private string filePath = "D:\\XmlLibrary\\";

        public IEnumerable<Employees> GetEmployees()
        {
            IEnumerable<Employees> employees = _xmlContext.files["employees"].Descendants("Employees")
                .Select(employee => new Employees
               (
                     employee.Element("LastName").Value,
                     employee.Element("FirstName").Value,
                     employee.Element("MiddleName").Value,
                     int.Parse(employee.Element("EmployeeId").Value),
                     employee.Element("RollNumber").Value,
                     employee.Element("Education").Value
                )
                {
                    DateOfBirth = DateTime.Parse(employee.Element("DateOfBirth").Value),
                    Specialty = employee.Element("Specialty").Value,
                    HireDate = DateTime.Parse(employee.Element("HireDate").Value),
                });
            return employees;
        }

        public IEnumerable<string> GetCompaniesName()
        {

            var query = _xmlContext.files["company"].Descendants("Company")
                                .Select(m => m.Element("Name").Value);
            return query;
        }

        public IEnumerable<Employees> GetAllEmployees()
        {

            IEnumerable<Employees> employees = _xmlContext.files["employees"].Descendants("Employees")
                .Select(employee => new Employees
                {
                    LastName = employee.Element("LastName").Value,
                    FirstName = employee.Element("FirstName").Value,
                    MiddleName = employee.Element("MiddleName").Value,
                    DateOfBirth = DateTime.Parse(employee.Element("DateOfBirth").Value),
                    EmployeeId = int.Parse(employee.Element("EmployeeId").Value),
                    RollNumber = employee.Element("RollNumber").Value,
                    Education = employee.Element("Education").Value,
                    Specialty = employee.Element("Specialty").Value,
                    HireDate = DateTime.Parse(employee.Element("HireDate").Value),
                });

            IEnumerable<Employees> employeesWithoutSalaries = _xmlContext.files["employeesWithoutEmployement"].Descendants("employee")
                .Select(employee => new Employees
                {
                    LastName = employee.Element("LastName").Value,
                    FirstName = employee.Element("FirstName").Value,
                    MiddleName = employee.Element("MiddleName").Value,
                    DateOfBirth = DateTime.Parse(employee.Element("DateOfBirth").Value),
                    EmployeeId = int.Parse(employee.Element("EmployeeId").Value),
                    RollNumber = employee.Element("RollNumber").Value,
                    Education = employee.Element("Education").Value,                   
                });

            IEnumerable<Employees> allEmployees = employees.Concat(employeesWithoutSalaries);

            return allEmployees;
        }

        public int GetEmployeesCountWithEducation(string education)
        {
  
            int commentCount = _xmlContext.files["employees"].Descendants("Employees")
                                    .Where(employee => (string?)employee.Element("Education") == education)
                                    .Count();

            return commentCount;
        }

        public IEnumerable<Employees> GetSortedEmployees(string sort)
        {
 
            var sortedEmployees = _xmlContext.files["employees"].Descendants("Employees")
            .OrderBy(employee => (string)employee.Element($"{sort}").Value)
            .Select(employee => new Employees
            {
                LastName = employee.Element("LastName").Value,
                FirstName = employee.Element("FirstName").Value,
                MiddleName = employee.Element("MiddleName").Value,
                DateOfBirth = DateTime.Parse(employee.Element("DateOfBirth").Value),
                EmployeeId = int.Parse(employee.Element("EmployeeId").Value),
                RollNumber = employee.Element("RollNumber").Value,
                Education = employee.Element("Education").Value,
                Specialty = employee.Element("Specialty").Value,
                HireDate = DateTime.Parse(employee.Element("HireDate").Value),
            });

            return sortedEmployees;
        }


        public IEnumerable<string> GetCompaniesStartWith(string symbol)
        {
            var companies = _xmlContext.files["company"].Descendants("Company")
            .Where(company => ((string?)company.Element("Name")).StartsWith(symbol))
                        .Select(m => m.Element("Name").Value);

            return companies;

        }

        public IEnumerable<Employement> GetEmployeesIdBiggerThan(int id)
        {
            var empSals = _xmlContext.files["employement"].Descendants("Employement")
            .Where(empSal => ((int?)empSal.Element("EmployeeId")) > id)
                        .Select(empSal => new Employement(0,0)
                        {
                            EmployeeId = int.Parse(empSal.Element("EmployeeId").Value),
                            CompanyId = int.Parse(empSal.Element("CompanyId").Value),

                        });

            return empSals;
        }


        public IEnumerable<string> GetEmployeesSalariesId()
        {

            XDocument employeesXml = XDocument.Load(filePath + "employees.xml");
            XDocument salaryXml = XDocument.Load(filePath + "salary.xml");
            XDocument employeesSalariesXml = XDocument.Load(filePath + "employeesSalaries.xml");

            IEnumerable<XElement> employeesElements = employeesXml.Descendants("Employees");
            IEnumerable<XElement> salaryElements = salaryXml.Descendants("Salary");
            IEnumerable<XElement> employeesSalariesElements = employeesSalariesXml.Descendants("employeeSalaries");

            var combinedTable = from employeesSalaries in employeesSalariesElements
                                join employee in employeesElements on (int?)employeesSalaries.Element("EmployeeId") equals (int?)employee.Element("EmployeeId")
                                join salary in salaryElements on (int?)employeesSalaries.Element("SalaryId") equals (int?)salary.Element("EmployeeId")
                                select new
                                {
                                    EmployeeName = (string?)employee.Element("LastName"),
                                    SalaryId = (string?)salary.Element("EmployeeId")
                                };

            return combinedTable.Select(x => $"Employee: {x.EmployeeName}, Salary Id: {x.SalaryId}");
        }

        public IEnumerable<string> GetSpecificRollNumbers(string symbols)
        {
  
            var rollNumbers = _xmlContext.files["employees"].Descendants("Employees")
                                .Where(c => c.Element("RollNumber").Value.Contains(symbols))
                                .Select(c => c.Element("RollNumber").Value)
                                .ToList();

            return rollNumbers;
        }

        public string? GetYoungestEmployee()
        {
 
            var employeesName = _xmlContext.files["employees"].Descendants("Employees")
                .OrderByDescending(m => DateTime.Parse(m.Element("DateOfBirth").Value ) )
                .Select(m => m.Element("FirstName")?.Value)
                .FirstOrDefault();

            return employeesName;
        }

        public IEnumerable<Employees> GetEmployeesFromTo(int min, int max)
        {
            var employees = _xmlContext.files["employees"].Descendants("Employees")                
                .SkipWhile(element => int.Parse(element.Element("EmployeeId").Value) < min)
                .TakeWhile(element => int.Parse(element.Element("EmployeeId").Value) <= max)
                .Select(employee => new Employees
                {
                    LastName = employee.Element("LastName").Value,
                    FirstName = employee.Element("FirstName").Value,
                    MiddleName = employee.Element("MiddleName").Value,
                    DateOfBirth = DateTime.Parse(employee.Element("DateOfBirth").Value),
                    EmployeeId = int.Parse(employee.Element("EmployeeId").Value),
                    RollNumber = employee.Element("RollNumber").Value,
                    Education = employee.Element("Education").Value,
                    Specialty = employee.Element("Specialty").Value,
                    HireDate = DateTime.Parse(employee.Element("HireDate").Value),
                });

            return employees;
        }

        public IEnumerable<string> GetEmployementEmployees()
        {
            XDocument employeestXml = XDocument.Load(filePath + "employees.xml");
            XDocument salary = XDocument.Load(filePath + "salary.xml");

            IEnumerable<XElement> employeesElements = employeestXml.Descendants("Employees");
            IEnumerable<XElement> salaryElements = salary.Descendants("Salary");


            var query = (from employees in employeesElements
                         join salaries in salaryElements
                         on (int?)employees.Element("EmployeeId") equals (int?)salaries.Element("EmployeeId")
                         select new
                         {
                             LastName = (string?)employees.Element("LastName")
                         }).Distinct();

            return query.Select(x => $"Lastname: {x.LastName}");
        }

       

        public Employement[] GetEmployeesArray()
        {
            var employement = _xmlContext.files["employement"].Descendants("Employement")
                .Select(employeesSalary => new Employement(0, 0)
                {

                    EmployeeId = int.Parse(employeesSalary.Element("EmployeeId").Value),
                    CompanyId = int.Parse(employeesSalary.Element("CompanyId").Value),
                })
                .ToArray();

            return employement;
        }

        public string GetAllRollNumbers()
        {

            var allRoll = _xmlContext.files["employees"].Descendants("Employees")
                                    .Aggregate(new Employees(), (total, current) =>
                                    {
                                        total.RollNumber += current.Element("RollNumber").Value + " ";
                                        return total;
                                    });

            return allRoll.RollNumber;
        }


        public string GetFirstEmployeeWithIdBiggerThan(int employeeId)
        {

            var employee = _xmlContext.files["employees"].Descendants("Employees")
                .FirstOrDefault(m => (int?)m.Element("EmployeeId") > employeeId);

            if (employee == null) { return "Such an employee doesn`t exist"; }
            return employee.ToString();

        }


        public IEnumerable<string> GetIdByName()
        {
            var employeesXml = XDocument.Load(filePath + "employees.xml");
            var employeesElements = employeesXml.Descendants("Employees");

            var rollNumbersXml = XDocument.Load(filePath + "salary.xml");
            var rollNumbersElements = rollNumbersXml.Descendants("Salary");

            var query = from employee in employeesElements
                        join salary in rollNumbersElements
                            on (int?)employee.Element("EmployeeId") equals (int?)salary.Element("EmployeeId")
                        group salary by (string?)employee.Element("FirstName") into grouped
                        select new
                        {
                            FirstName = grouped.Key,
                            RollNumbers = grouped.Select(s => (string?)s.Element("EmployeeId")).Distinct()
                        };

            return query.Select(result => $"{result.FirstName}: {string.Join(", ", result.RollNumbers)}");
        }



    }
}
