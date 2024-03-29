namespace Auto_Mocker
{
    public interface IDeviceManager
    {
        void Add(Device device);
        bool AddedSucessfully { get; set; }
        string special { get; set; }
        bool IsSpecialProduct(Device device);
    }
}