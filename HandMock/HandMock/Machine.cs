using System;
using HandMock;

namespace HandMock
{
    public class Machine
    {
        private readonly IPrinter _printer;
        private readonly IConfigureSystem _systemConfiguration;

        public Machine(IPrinter printer, IConfigureSystem systemConfiguration)
        {
            _printer = printer;

            _systemConfiguration = systemConfiguration;
        }

        public void Action(string message, string Type)
        {

            if (_systemConfiguration.CheckIfPrint(Type))
            {
                 _printer.Print(message);
            }
            else
            {
                //do something else
            }

        }
    }
}
