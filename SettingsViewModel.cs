using System.Collections.Generic;
public class SettingsViewModel
{
    DbConnector connection;
    public List<Customers> AllCustomers { get; set; }
    public List<Device> AllDevices { get; set; }
    public Customer SelectedCustomer { get; set; }
    public Device SelectedDevice { get; set; }
    public string NewCustomerlogin { get; set; }
    public string NewDeviceName { get; set; }
    public DevicesNames NewDeviceType { get; set; }
    public string NewDevicePrice { get; set; }
    public string UpdatedCustomerLogin { get; set; }
    public string UpdatedCustomerDiscount { get; set; }
    public string UpdatedDeviceName { get; set; }
    public string UpdatedDevicePrice { get; set; }
    public RelayCommands AddNewCustomerCommand { get; set; }
    public RelayCommands AddNewDeviceCommand { get; set; }
    public RelayCommands RemoveCustomerCommand { get; set; }
    public RelayCommands RemoveDeviceCommand { get; set; }
    public RelayCommands UpdateCustomerCommand { get; set; }
    public RelayCommands UpdateDeviceCommand { get; set; }
    public SettingsViewModel(DbConnector connector)
    {
        connection.connector;
        AllCustomers = connector.GetCustomers();
        AllDevices = connector.GetDevices();
        AddNewCustomerCommand(addNewCustomer,Can);
        AddNewDeviceCommand(addNewDevice,Can);
        RemoveCustomerCommand(removeCustomer,Can);
        RemoveDeviceCommand(removeDevice,Can);
        UpdateCustomerCommand(updateCustomer,Can);
        UpdateDeviceCommand(updateDevice,Can);

    }
    public void addNewCustomer()
    {
        Customer customer = new Customer();
        customer.Id = 21;
        customer.Login = NewCustomerlogin;
        customer.PersonalDiscount = 0.0;
        connection.AddCustomer(customer);
        AllCustomers = null;
        AllCustomers = connection.GetCustomers();

    }
    public void addNewDevice()
    {
        Device device = new Device();
        device.Id = 21;
        device.Name = NewDevicePrice;
        device.Type = NewDeviceType;
        device.Price = NewDevicePrice;
        AllDevices = null;
        AllDevices = connection.GetDevices();
    }
    public void removeCustomer()
    {
        connection.RemoveCustomer(SelectedCustomer);
        AllCustomers = null;
        AllCustomers = connection.GetCustomers();

    }
    public void removeDevice()
    {
        connection.RemoveDevice(SelectedDevice);
        AllCustomers = null;
        AllCustomers = connection.GetCustomers();
    }
    public void updateCustomer()
    {
        Customer updatedCustomer = SelectedCustomer;
        updateCustomer.Login = UpdatedCustomerLogin;
        connection.UpdateCustomer(updatedCustomer);
        AllCustomers = null;
        AllCustomers = connection.GetCustomers();
    }
    public void updateDevice()
    {
        Device updatedDevice = SelectedDevice;
        updatedDevice.Name = UpdatedDeviceName;
        updatedDevice.Price = UpdatedDevicePrice;
        connection.UpdateDevice(updatedDevice);
        AllDevices = null;
        AllDevices = connection.GetDevices();
    }
    public bool Can()
    {
        return true;
    }
}