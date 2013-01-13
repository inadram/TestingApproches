using System.Collections.Generic;

namespace Rhino_mock
{
   public class Machine
    {
        private IDeviceManager _deviceManager;
        public Machine(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }
        public void RegisterNewDevice(Device device)
        {
            _deviceManager.Add(device);
            _deviceManager.AddedSucessfully = true;

            _deviceManager.special = _deviceManager.IsSpecialProduct(device) ? "Special" : "Not Special";
        }

        public void SetupAndRegisterNewDevice(int id,string name)
        {
            Device device=new Device(){Id = id,Name = name};
            _deviceManager.Add(device);
            _deviceManager.AddedSucessfully = true;

            _deviceManager.special = _deviceManager.IsSpecialProduct(device) ? "Special" : "Not Special";
        }

       public void RegisterDevices(List<Device> devices)
       {
           _deviceManager.AddAll(devices);
       }
    }
}
