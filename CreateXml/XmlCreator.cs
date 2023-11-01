
namespace Lab2
{
    public class XmlCreator
    {
        private readonly Collections _collections;
        private readonly XmlSerializer<Company> xmlSerializer = new("D:\\XmlLibrary\\company.xsd", "D:\\XmlLibrary\\company.xml");
        private readonly XmlSerializer<Employees> xmlSerializer2 = new("D:\\XmlLibrary\\employees.xsd", "D:\\XmlLibrary\\employees.xml");
        private readonly XmlSerializer<Salary> xmlSerializer3 = new("D:\\XmlLibrary\\salary.xsd", "D:\\XmlLibrary\\salary.xml");
        private readonly XmlSerializer<Employement> xmlSerializer4 = new("D:\\XmlLibrary\\employement.xsd", "D:\\XmlLibrary\\employement.xml");
        public XmlCreator(Collections collection)
        {
            _collections = collection;
            CreateXmlDocs();
        }

        public void CreateXmlDocs()
        {
            xmlSerializer2.SerializeDoc((List<Employees>)_collections.Employees);
            xmlSerializer.SerializeDoc((List<Company>)_collections.Companies);
            xmlSerializer3.SerializeDoc((List<Salary>)_collections.Salary);
            xmlSerializer4.SerializeDoc((List<Employement>)_collections.Employements);
        }
    }
}
