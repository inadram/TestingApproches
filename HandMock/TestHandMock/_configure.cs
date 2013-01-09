using HandMock;

namespace HandMockTest
{
    public class _configure : IConfigureSystem
    {
        public bool CheckIfPrint(string logLevel)
        {
            return true;
        }
    }
}