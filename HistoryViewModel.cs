namespace ShopWPF
{


    public class HistoryViewModel
    {
        public DbConnector connection;
        public List<SalesHistory> AllHistory
        {
            get;
            set;
        }
        public HistoryViewModel(DbConnector connector)
        {
            connection = connection;
            AllHistory = connection.GetHistory();

        }
    }
}