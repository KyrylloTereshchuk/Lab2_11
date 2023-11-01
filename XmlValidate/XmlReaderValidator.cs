
namespace Lab2
{
    public class XmlReaderValidator
    {
        private readonly XmlSerializer<Company> xmlSerializer = new("D:\\XmlLibrary\\company.xsd", "D:\\XmlLibrary\\company.xml");
        private readonly XmlSerializer<Employees> xmlSerializer2 = new("D:\\XmlLibrary\\employees.xsd", "D:\\XmlLibrary\\employees.xml");
        private readonly XmlSerializer<Salary> xmlSerializer3 = new("D:\\XmlLibrary\\salary.xsd", "D:\\XmlLibrary\\salary.xml");
        private readonly XmlSerializer<Employement> xmlSerializer4 = new("D:\\XmlLibrary\\employement.xsd", "D:\\XmlLibrary\\employement.xml");

        public void Execute()
        {
            ValidateEmployee();
            ValidateCompany();
            ValidateEmployement();
            ValidateSalary();
        }

        private void ValidateEmployee()
        {
            var x = xmlSerializer2.DeserializeDoc();
        }
        private void ValidateCompany()
        {            
            var x = xmlSerializer.DeserializeDoc();
        }
        private void ValidateSalary()
        {        
            var x = xmlSerializer3.DeserializeDoc();
        }
        private void ValidateEmployement()
        {
            var x = xmlSerializer4.DeserializeDoc();
        }
    }
}
