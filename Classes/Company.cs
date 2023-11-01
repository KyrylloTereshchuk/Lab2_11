using System.Xml.Serialization;

namespace Lab2
{
    [Serializable, XmlRoot(CompanyName.Root)]
    public class Company
    {
        [XmlElement(ElementName = CompanyName.Name)]
        public string? Name { get; set; }
        [XmlElement(ElementName = CompanyName.Id)]
        public int Id { get; set; }

        public Company(string name, int Id)
        {
            Name = name;
            this.Id = Id;
        }
        public Company()
        {
        }

    }
}
