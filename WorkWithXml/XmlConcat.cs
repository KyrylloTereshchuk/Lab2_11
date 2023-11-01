using System.Xml.Linq;

namespace Lab2
{
    public class XmlConcat : IXmlConcat
    {
        private string filePath = "D:\\XmlLibrary2\\";
        public void ConcatXmlFiles()
        {
            string[] fileNames = { filePath + "employees.xml", filePath + "company.xml", filePath + "salary.xml", 
                filePath + "employement.xml"};

            XElement root = new ("Collections");

            foreach (string fileName in fileNames)
            {
                XDocument doc = XDocument.Load(fileName);

                root.Add(doc.Root.Elements());
            }
            root.Save(filePath + "Collections.xml");

            Console.WriteLine("Successfull");
        }
    }
}
