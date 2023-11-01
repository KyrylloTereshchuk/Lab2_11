using System.Text;
using System.Xml;

namespace Lab2
{
    public class XmlCreatorDesign
    {
        public XmlWriterSettings GetSettings()
        {
            Console.OutputEncoding = Encoding.UTF8;

            XmlWriterSettings settings = new ();
            settings.Indent = true;

            return settings;
        }
    }
}
