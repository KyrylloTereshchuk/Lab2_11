using System.Xml;
using System.Xml.Linq;


namespace Lab2
{
    public class XmlWriters
    {
        private readonly XmlContext _xmlContext;
        private readonly XMLValidator _xmlValidator;
        private XmlConcat _xmlConcat;

        public XmlWriters( XmlContext xmlContext, XMLValidator xMLValidator, XmlConcat xmlConcat)
        {
            _xmlContext = xmlContext;
            _xmlValidator = xMLValidator;
            _xmlConcat = xmlConcat;
        }

        private string filePath = "D:\\XmlLibrary\\";

        public void WriteEmployees(XmlWriterSettings settings, int num)
        {


            XDocument xmlDoc;
            using (XmlWriter writer = XmlWriter.Create(filePath + "employees.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("employees");

                for (int i = 0; i < num; i++)
                {
                    Employees employee = new Employees();
                    employee = _xmlValidator.ValidateEmployee(employee);

                    writer.WriteStartElement("employee");
                    writer.WriteElementString("LastName", employee.LastName);
                    writer.WriteElementString("FirstName", employee.FirstName);
                    writer.WriteElementString("MiddleName", employee.MiddleName);
                    writer.WriteElementString("DateOfBirth", employee.DateOfBirth?.ToString("yyyy-MM-dd"));
                    writer.WriteElementString("EmployeeId", (i + 1).ToString());
                    writer.WriteElementString("RollNumber", employee.RollNumber);
                    writer.WriteElementString("Education", employee.Education);
                    writer.WriteElementString("Specialty", employee.Specialty);
                    writer.WriteElementString("HireDate", employee.HireDate?.ToString("yyyy-MM-dd"));
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                xmlDoc = XDocument.Load(filePath + "employees.xml");
            }

            _xmlContext.files["employees"] = xmlDoc;
            _xmlConcat.ConcatXmlFiles();
        }


        public void WriteCompany(XmlWriterSettings settings, int num)
        {


            XDocument xmlDoc;
            using (XmlWriter writer = XmlWriter.Create(filePath + "company.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("companies");

                for (int i = 0; i < num; i++)
                {
                    Company company = new Company("", 0);                 

                    writer.WriteStartElement("company");
                    Console.WriteLine("Enter companies name:");
                    writer.WriteElementString("Name", Console.ReadLine());
                    Console.WriteLine("Enter companies Id:");
                    writer.WriteElementString("Id", Console.ReadLine());

                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                xmlDoc = XDocument.Load(filePath + "company.xml");
            }

            _xmlContext.files["company"] = xmlDoc;
            _xmlConcat.ConcatXmlFiles();
        }



      
        public void WriteEmployement(XmlWriterSettings settings, int num)
        {
            using (XmlWriter writer = XmlWriter.Create(filePath + "employement.xml", settings))
            {


                writer.WriteStartDocument();
                writer.WriteStartElement("employements");
                for (int i = 0; i < num; i++)
                {

                    Employement employement = new Employement(1, 1);
                    employement = _xmlValidator.ValidateEmployement(employement);

                    writer.WriteStartElement("employement");
                    writer.WriteElementString("EmployeeId", employement.EmployeeId.ToString());
                    writer.WriteElementString("CompanyId", employement.CompanyId.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                XDocument xmlDoc = XDocument.Load(filePath + "employement.xml");

                _xmlContext.files["employement"] = xmlDoc;
                _xmlConcat.ConcatXmlFiles();
            }

        }



        public void WriteSalary(XmlWriterSettings settings, int num)
        {


            XDocument xmlDoc;
            using (XmlWriter writer = XmlWriter.Create(filePath + "salary.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("salaries");

                for (int i = 0; i < num; i++)
                {
                    Salary salary = new Salary(0);
                    salary = _xmlValidator.ValidateSalary(salary);

                    writer.WriteStartElement("salary");
                    writer.WriteElementString("EmployeeId", salary.EmployeeId.ToString());

                    Console.WriteLine("Enter salaries count:");
                    string? count = Console.ReadLine();
                    if (int.TryParse(count, out int value))
                    {
                        for (int j = 0; j < value; j++)
                        {                           
                            int salariesValue = _xmlValidator.IntValidate();
                            writer.WriteElementString("value", salariesValue.ToString());
 
                        }
                    }

                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                xmlDoc = XDocument.Load(filePath + "salary.xml");
            }

            _xmlContext.files["salary"] = xmlDoc;
            _xmlConcat.ConcatXmlFiles();
        }
    }
}
