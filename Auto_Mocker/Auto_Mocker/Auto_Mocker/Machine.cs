namespace Auto_Mocker
{
    public class Machine
    {
        private IDeviceManager _deviceManager;
        private Iproduct _product;
        public Machine(IDeviceManager deviceManager,Iproduct product)
        {
            _deviceManager = deviceManager;
            _product = product;

        }
        public void RegisterNewDevice(Device device)
        {
            _deviceManager.AddedSucessfully = true;

            if (!_product.IsOutOfStock(device))
            {
                _deviceManager.Add(device);
            }

            _deviceManager.special = _deviceManager.IsSpecialProduct(device) ? "Special" : "Not Special";


        }


    }
}
