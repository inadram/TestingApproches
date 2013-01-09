using HandMock;

namespace HandMockTest
{
    public class _printer : IPrinter
    {
        private bool isCalled = false;
        public string Print(string messageToScrub)
        {
            isCalled = true;
            return string.Empty;
        }

        public bool PrintWasCalled()
        {
            return isCalled;
        }
    }
}