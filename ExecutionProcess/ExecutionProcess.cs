
namespace Lab2
{
    public class ExecutionProcess : IExecutionProcess
    {
          private readonly Menu _menu;
          private readonly XmlReaderValidator _xmlReaderValidator;

          public ExecutionProcess(Menu dictionary, XmlReaderValidator xmlReaderValidator)
          {
                _menu = dictionary;
                _xmlReaderValidator = xmlReaderValidator;
          }

        public void Process()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Menu\n");
            foreach (Enums.QueriesNames queryName in Enum.GetValues(typeof(Enums.QueriesNames)))
            {
                Console.WriteLine($"{(int)queryName}." + queryName);
            }

               while (true)
               {
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.Write("\nEnter command number (1-22) or 0 to exit: ");
                  Console.ResetColor();

                            var methods = _menu.MenuCreate();

                    if (int.TryParse(Console.ReadLine(), out int methodNumber) && methodNumber >= 0 && methodNumber <= 21 && methodNumber <= methods.Length)
                    {
                        _xmlReaderValidator.Execute();
                        methods[methodNumber]();
                    }

                    else
                    {
                         Console.WriteLine("Invalid input!");
                    }

               }

        }

    }

}
