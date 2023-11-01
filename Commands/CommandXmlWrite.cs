using System.Xml;

namespace Lab2
{
    public class CommandXmlWrite : ICommandXmlWrite
    {
        private readonly XmlWriterSettings settings;
        private readonly XmlWriters xmlWriters;

        public CommandXmlWrite(XmlWriterSettings settings, XmlWriters xmlxmlWriters)
        {
            this.settings = settings;
            this.xmlWriters = xmlxmlWriters;
        }

        private string? s;
        private int num;

        public void WriteXmlEmployees()
        {
            Console.WriteLine("Enter employees number:");
            s = Console.ReadLine();

            if (int.TryParse(s, out num))
            {
                xmlWriters.WriteEmployees(settings, num);
            }
            else
            {
                Console.WriteLine("Invalis value!");
            }           
        }

        public void WriteXmlCompany()
        {
            Console.WriteLine("Enter companies number:");
            s = Console.ReadLine();

            if (int.TryParse(s, out num))
            {
                xmlWriters.WriteCompany(settings, num);
            }
            else
            {
                Console.WriteLine("Invalis value!");
            }           
        }

        public void WriteXmlEmployement()
        {
            Console.WriteLine("Enter employements number:");
            s = Console.ReadLine();

            if (int.TryParse(s, out num))
            {
                xmlWriters.WriteEmployement(settings, num);
            }
            else
            {
                Console.WriteLine("Invalis value!");
            }           
        }

        public void WriteXmlSalary()
        {
            Console.WriteLine("Enter salaries number:");
            s = Console.ReadLine();

            if (int.TryParse(s, out num))
            {
                xmlWriters.WriteSalary(settings, num);
            }
            else
            {
                Console.WriteLine("Invalis value!");
            }          
        }

    }
}
