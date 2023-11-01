using System.Xml.Serialization;

namespace Lab2
{
    [Serializable, XmlRoot(SalaryName.Root)]
    public  class Salary
    {
        [XmlElement(ElementName = SalaryName.EmployeeId)]
        public int EmployeeId { get; set; }

        [XmlElement(ElementName = SalaryName.MonthlySalaries)]
        public List<decimal>? Salaries { get; set; }

        public Salary(int employeeId)
        {
            EmployeeId = employeeId;
            Salaries = new List<decimal>();
        }
        public Salary()
        {
        }
    }
}
