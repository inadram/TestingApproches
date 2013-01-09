using System;

namespace HandMock
{
    public interface IConfigureSystem
    {
        bool CheckIfPrint(string logLevel);
    }
}