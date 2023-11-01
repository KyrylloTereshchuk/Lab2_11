
namespace Lab2
{
    class Program
    {
        static void Main()
        {
            Collections collections = new();
            XmlCreator xmlCreator = new(collections);
            XmlCreatorDesign xmlCreatorDesign = new();
            XmlConcat xmlConcat = new();
            PrintXml loadXml = new();          
            List<string> list = new List<string> { "employees", "salary", "company", "employement", "employeesWithoutEmployement", "Collections" };
            XmlContext xmlContext = new(list);
            XMLValidator xmlValidator = new XMLValidator(xmlContext);
            XmlWriters xmlWriters = new(xmlContext, xmlValidator, xmlConcat);
            Queries querys = new Queries(xmlContext);
            Commands commands = new Commands(querys);         
            CommandXmlWrite commandXmlWrite = new CommandXmlWrite(xmlCreatorDesign.GetSettings(), xmlWriters);
            Menu menu = new Menu(commands, commandXmlWrite, xmlConcat, loadXml);
            XmlReaderValidator xmlReaderValidator = new XmlReaderValidator();
            ExecutionProcess executionProcess = new ExecutionProcess(menu, xmlReaderValidator);

            executionProcess.Process();
        }

    }

}