using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lab2
{
    public class XmlSerializer<T>
    {
        private readonly string _xsd;
        private readonly string _doc;

        public XmlSerializer(string xsd, string doc)
        {
            _doc = doc;
            _xsd = xsd;
        }
        public void SerializeDoc(List<T> variables)
        {
            using (XmlWriter writer = XmlWriter.Create(_doc))
            {
                XmlSerializer serializer = new (typeof(List<T>));
                serializer.Serialize(writer, variables);
            }
        }
        public List<T>? DeserializeDoc()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            List<T>? variables = new List<T>();
            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.Schemas.Add(null, _xsd);

            using (FileStream fileStream = new FileStream(_doc, FileMode.Open))
            {
                try
                {
                    variables = (List<T>?)serializer.Deserialize(fileStream);
                }
                catch (XmlSchemaValidationException)
                {
                    throw new XmlSchemaValidationException();
                }
            }

            return variables;
        }

    }
}
