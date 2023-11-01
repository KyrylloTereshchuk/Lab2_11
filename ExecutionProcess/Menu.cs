
namespace Lab2
{
    public class Menu
    {
        private readonly ICommands _Commands;
        private readonly ICommandXmlWrite _CommandXmlWrite;
        private readonly IXmlConcat _XmlConcat;
        private readonly IPrintXml _LoadXml;
        public Menu(ICommands command, ICommandXmlWrite commandXmlWrite, IXmlConcat xmlConcat, IPrintXml loadXml)
        {
            _Commands = command;
            _CommandXmlWrite = commandXmlWrite;
            _XmlConcat = xmlConcat;
            _LoadXml = loadXml;
        }

            public Action[] MenuCreate()
            {
                Action[] methods = new Action[]
                {
                        () => _Commands.Exit(),

                       () => _CommandXmlWrite.WriteXmlEmployees(),
                       () => _CommandXmlWrite.WriteXmlCompany(),
                       () => _CommandXmlWrite.WriteXmlEmployement(),
                       () => _CommandXmlWrite.WriteXmlSalary(),

                       () => _XmlConcat.ConcatXmlFiles(),

                       () => _LoadXml.LoadXmlFile(),

                       () => _Commands.Command1(),
                       () => _Commands.Command2(),
                       () => _Commands.Command3(),
                       () => _Commands.Command4(),
                       () => _Commands.Command5(),
                       () => _Commands.Command6(),
                       () => _Commands.Command7(),
                       () => _Commands.Command8(),
                       () => _Commands.Command9(),
                       () => _Commands.Command10(),
                       () => _Commands.Command11(),
                       () => _Commands.Command12(),
                       () => _Commands.Command13(),
                       () => _Commands.Command14(),
                       () => _Commands.Command15(),
                       () => _Commands.Command16(),
                };
                return methods;
            }

    }
}

