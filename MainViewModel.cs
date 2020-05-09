public class MainViewModel
{
    public List<Device> AllDevices{get;set;}
    public MainViewModel(DbConnector connector)
    {
        AllDevices = connector.GetDevice();
    }
    
    
}