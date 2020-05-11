using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShopWPF {

    public class DbConnector {
        public OleDbConnection con;

        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DeviceShop.accdb";
        public DbConnector () {
            con = new OleDbConnection (connectionString);

        }
        public void AddCustomer (Cutomer customer) {
            OleDbCommand command = con.CreateCommand ();
            con.Open ();
            command.CommandText = "Insert into Customers([CustomerLogin],[PersonalDiscount]) Values('" + customer.CustomerLogin + "','" + flower.PersonalDiscount + "";
            command.Connection = con;
            command.ExecuteNonQuery ();
            con.Close ();
        }
        public void AddDevice (Device device) {
            OleDbCommand command = con.CreateCommand ();
            con.Open ();
            //TODO: Rewrite next string;
            command.CommandText = "Insert into Devices([DeviceName],[DeviceType],[DevicePrice]) Values('" + device.Name + "','" + device.Type + "','" + device.Price + "'" + "";
            command.Connection = con;
            command.ExecuteNonQuery ();
            con.Close ();
        }
        public void AddHistory (SalesHistory history) {
            OleDbCommand command = con.CreateCommand ();
            con.Open ();
            //TODO: Rewrite next string;
            command.CommandText = $"Insert into History([BuyerId],[DeviceId],[BuyDate]) Values ('{history.Buyer.Id}','{history.BoughtDevice.Id}','{history.Date}')";
            command.Connection = con;
            command.ExecuteNonQuery ();
            con.Close ();
        }
        public List<Device> GetDevices () {
            con.Open ();
            List<Device> devices = new List<Device> ();
            string query = "Select * from Devices";
            OleDbCommand command = new OleDbCommand (query, con);
            OleDbDataReader reader = command.ExecuteReader ();

            while (reader.Read ()) {
                devices.Add (new Device (Convert.ToInt32 (reader[0]), reader[1].ToString (), (DevicesTypes) reader[2], Convert.ToDecimal (reader[3])));
            }
            reader.Close ();
            con.Close ();
            return devices;
        }
        public List<Flower> GetCustomers () {
            con.Open ();
            List<Flower> flowers = new List<Flower> ();
            string query = "Select * from Customers";
            OleDbCommand command = new OleDbCommand (query, con);
            OleDbDataReader reader = command.ExecuteReader ();
            while (reader.Read ()) {
                flowers.Add (new Customer (Convert.ToInt32 (reader[0]), reader[1].ToString (), Convert.ToDecimal (reader[2])));
            }
            reader.Close ();
            con.Close ();
            return flowers;
        }
        public Device GetDevice (int id) {
            con.Open ();
            Device device = new Device ();
            string query = "Select * from Devices where id = " + id + "";
            OleDbCommand command = new OleDbCommand (query, con);
            OleDbDataReader reader = command.ExecuteReader ();
            while (reader.Read ()) {
                device = new Device (Convert.ToInt32 (reader[0]), reader[1].ToString (), (DevicesTypes) reader[2], Convert.ToDecimal (reader[3]));
            }
            reader.Close ();
            con.Close ();
            return device;
        }
        public Customer GetCustomer (int id) {
            con.Open ();
            Customer customer = new Customer ();
            string query = "Select * from Customers where id = " + id + "";
            OleDbCommand command = new OleDbCommand (query, con);
            OleDbDataReader reader = command.ExecuteReader ();
            while (reader.Read ()) {
                device = new Customer (Convert.ToInt32 (reader[0]), reader[1].ToString (), Convert.ToDecimal (reader[2]));
            }
            reader.Close ();
            con.Close ();
            return device;
        }
        public List<SalesHistory> GetHistory () {
            con.Open ();
            List<SalesHistory> histories = new List<SalesHistory> ();
            string query = "Select * from History";
            OleDbCommand command = new OleDbCommand (query, con);
            OleDbDataReader reader = command.ExecuteReader ();
            while (reader.Read ()) {
                Customer newCustomer = GetCustomer (reader[1]);
                Device newDevice = GetDevice (reader[2]);
                histories.Add (new SalesHistory (Convert.ToInt32 (reader[0]), newCustomer, newDevice, reader[3]));
            }
            reader.Close ();
            con.Close ();
            return histories;
        }
        public void RemoveCustomer (Customer customer) {
            OleDbCommand command = con.CreateCommand ();
            con.Open ();
            string query = "Delete * from  Customers  where Id=" + customer.Id + "";
            command.CommandText = query;
            command.Connection = con;
            command.ExecuteNonQuery ();
            con.Close ();
        }
        public void RemoveDevice (Device device) {
            OleDbCommand command = con.CreateCommand ();
            con.Open ();
            string query = "Delete * from  Devices  where Id=" + device.Id + "";
            command.CommandText = query;
            command.Connection = con;
            command.ExecuteNonQuery ();
            con.Close ();

        }
        public void UpdateCustomer (Customer customer) {
            OleDbCommand command = con.CreateCommand ();
            con.Open ();
            string query = "Update Customers set CustomerLogin ='" + customer.Login + " where Id=" + customer.Id + "";
            command.CommandText = query;
            command.Connection = con;
            command.ExecuteNonQuery ();
            con.Close ();
        }
        public void UpdateDevice (Device device) {

            OleDbCommand command = con.CreateCommand ();
            con.Open ();
            string query = "Update Devices set DeviceName ='" + device.Login + "DeviceType =" + device.Type + "DevicePrice =" + device.Price + " where Id=" + customer.Id + "";
            command.CommandText = query;
            command.Connection = con;
            command.ExecuteNonQuery ();
            con.Close ();

        }
    }
}