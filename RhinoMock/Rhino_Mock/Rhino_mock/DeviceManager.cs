namespace Rhino_mock
{
    public class DeviceManager:IDeviceManager    
    {
        public void Add(Device device)
        {
        }

        public bool AddedSucessfully { get; set; }
        public string special { get; set; }
        public bool IsSpecialProduct(Device device)
        {
            return  false;
        }
    }
}