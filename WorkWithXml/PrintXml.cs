using System.Xml;
using System.Xml.Serialization;

namespace Lab2
{
    public class PrintXml : IPrintXml
    {
        private readonly string filePath = "D:\\XmlLibrary\\";

        public void LoadXmlFile()
        {
            string? fileName;
            Console.WriteLine("Enter xml file name:");
            fileName = Console.ReadLine();
            string fullPath = Path.Combine(filePath, fileName + ".xml");

            try
            {
                XmlDocument xmlDocument = new ();
                xmlDocument.Load(fullPath);

                XmlSerializer serializer = new (typeof(XmlDocument));

                using (StringWriter stringWriter = new ())
                {
                    using (XmlTextWriter xmlTextWriter = new (stringWriter))
                    {
                        xmlTextWriter.Formatting = Formatting.Indented;
                        serializer.Serialize(xmlTextWriter, xmlDocument);
                        Console.WriteLine(stringWriter.ToString());
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(" File not found");
            }
        }

    }
}
