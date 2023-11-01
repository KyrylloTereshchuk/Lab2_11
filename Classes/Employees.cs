using System.Xml.Serialization;

namespace Lab2
{
    [Serializable, XmlRoot(EmployeesName.Root)]
    public class Employees
    {
        [XmlElement(ElementName = EmployeesName.LastName)]
        public string LastName { get; set; }

        [XmlElement(ElementName = EmployeesName.FirstName)]
        public string FirstName { get; set; }

        [XmlElement(ElementName = EmployeesName.MiddleName)]
        public string MiddleName { get; set; }

        [XmlElement(ElementName = EmployeesName.DateOfBirth)]
        public DateTime? DateOfBirth { get; set; }

        [XmlElement(ElementName = EmployeesName.EmployeeId)]
        public int EmployeeId { get; set; }

        [XmlElement(ElementName = EmployeesName.RollNumber)]
        public string RollNumber { get; set; }

        [XmlElement(ElementName = EmployeesName.Education)]
        public string Education { get; set; }

        [XmlElement(ElementName = EmployeesName.Specialty)]
        public string? Specialty { get; set; }

        [XmlElement(ElementName = EmployeesName.HireDate)]
        public DateTime? HireDate { get; set; }

        public Employees(string lastName, string firstName, string middleName, 
                        int employeeId, string rollNumber, string education)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            EmployeeId = employeeId;
            RollNumber = rollNumber;
            Education = education;
        }
        public Employees()
        {
        }

        public override string ToString()
        {
            return string.Format(
                $"Last name: {this.LastName};" +
                $" First name: {this.FirstName};" +
                $" Middle name: {this.MiddleName}\n" +
                $"Date of birthday: {this.DateOfBirth};\n" +
                $" Employee Id: {this.EmployeeId};" +
                $" Card Id: {this.RollNumber};\n" +
                $" Education: {this.Education};" +
                $" Specialty: {this.Specialty};\n" +
                $" Hire date: {this.HireDate};\n"
                );
        }
    }
}
