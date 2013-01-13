namespace Auto_Mocker
{
    public interface Iproduct
    {
        bool IsOutOfStock(Device device);
        string Name { get; set; }
    }

    public class product : Iproduct
    {
        public bool IsOutOfStock(Device device)
        {
            return false;
        }

        public string Name
        {
            get { return null; }
            set { }
        }
    }
}