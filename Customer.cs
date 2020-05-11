using System.Collections.Generic;
namespace ShopWPF
{
    public class Customer
    {
        public int Id
        {
            get;
            set;
        }
        public string Login
        {
            get;
            set;
        }
        public decimal PersonalDiscount
        {
            get;
            set;
        }
        public Customer ()
        { }
        public Customer (ind id, string login, decimal personalDiscount)
        {
            Id = id;
            Login = login;
            PersonalDiscount = personalDiscount;
        }

    }
}