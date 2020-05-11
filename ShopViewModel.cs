using System;
using System.Collections.Generic;
public class ShopViewModel
{
    DbConnector connection;
    public Lsit<Customer> AllCustomers
    {
        get;
        set;
    }
    public List<Device> AllDevices
    {
        get;
        set;
    }
    public RelayCommands ApplyOperationCommand
    {
        get;
        set;
    }
    public Customer SelectedCustomer
    {
        get;
        set;
    }
    public Device SelectedDevice
    {
        get;
        set;
    }
    public ShopViewModel(DbConnector connector)
    {
        connection = connector;
        AllCustomers = connection.GetCustomers();
        AllDevices = connection.GetDevices();
    }
    public void applyOperation()
    {
        SalesHistory history = new SalesHistory();
        history.Buyer = SelectedCustomer;
        history.BoughtDevice = SelectedDevice;
        history.Date = DateTime.Now.ToString("dd.MM.yyyy");
        Customer customer = SelectedCustomer;
        customer.PersonalDiscount = Convert.ToDecimal(SelectedDevice.Price * 0.1);
        connection.AddHistory(history);
        connection.UpdateCustomer(customer);

    }
}