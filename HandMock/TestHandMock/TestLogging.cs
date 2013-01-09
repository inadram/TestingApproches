using NUnit.Framework;
using HandMock;

namespace HandMockTest
{
    
    [TestFixture]
    class TestLogging
    {
        [Test]
        public void Given_Logging_was_called()
        {
            var printer = new _printer();
            var configure = new _configure();
            var machine = new Machine(printer, configure);
            machine.Action("blah blah blah ....", "Print");
            Assert.That(printer.PrintWasCalled());
        }
    }
}
