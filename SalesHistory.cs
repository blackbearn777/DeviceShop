namespace ShopWPF
{
    public class SalesHistory
    {
        public int Id{get;set;}
        public Customer Buyer { get; set; }
        public Device BoughtDevice { get; set; }
        public string Date { get; set; }
        public SalesHistory()
        {
            
        }

        public SalesHistory(int id, Customer buyer, Device boughtDevice, string date)
        {
            Id = id;
            Buyer = buyer;
            BoughtDevice = boughtDevice;
            Date = date;
        }
    }
}