using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    public class Customer
    {
        public string name = "Asit";
        public int age = 30;

        public virtual int OrderByName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }
            return 100;
        }

        public int OrderByName1(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Test Exception");
            }
            return 100;
        }
    }

    public class LoyalCustomer : Customer
    {
        public int Discount { get; set; }

        public LoyalCustomer()
        {
            Discount = 10;
        }

        public override int OrderByName(string name)
        {
            return 101;
        }
    }

    public static class CustomerFactory
    {
        public static Customer CreateCustomerInstance(int orderCount)
        {
            if (orderCount <= 100)
                return new Customer();
            else
                return new LoyalCustomer();

        }
    }
}
