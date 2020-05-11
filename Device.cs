namespace ShopWPF
{
    public class Device
    {
        public ind Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public DevicesNames Type
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public Device ()
        {

        }

        public Device (ind id, string name, DevicesNames type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}