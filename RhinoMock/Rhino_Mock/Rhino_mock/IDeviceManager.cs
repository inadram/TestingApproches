using System.Collections.Generic;

namespace Rhino_mock
{
    public interface IDeviceManager
    {
        void Add(Device device);
        bool AddedSucessfully { get; set; }
        string special  { get; set; }
        bool IsSpecialProduct (Device device);
        void AddAll(List<Device> devices);
    }

   
}