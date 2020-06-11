using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Check_valid_for_Insurance()
        {
            var customer = new Customer();
            Assert.InRange(customer.age, 25, 40);
        }
        [Fact]
        public void GetOrderByName_Notnull()
        {
            var customer = new Customer();
            Assert.Throws<ArgumentException>(()=> customer.OrderByName(null));
            Assert.Throws<ArgumentException>(() => customer.OrderByName(""));
        }

        [Fact]
        public void GetOrderByName_Notnull_exceptionDetails()
        {
            var customer = new Customer();
            //Assert.Throws<ArgumentException>(() => customer.OrderByName(null));
            var exceptionDetails= Assert.Throws<ArgumentException>(() => customer.OrderByName1(""));
            Assert.Equal("Test Exception", exceptionDetails.Message);
        }

        [Fact]//Check the type of instance 
        public void LoyalCustomerOrderGreaterThanHundred()
        {
           var customerFactory =  CustomerFactory.CreateCustomerInstance(102);
            Assert.IsType(typeof(LoyalCustomer), customerFactory);
        }

        [Fact]//Check the discount for the loyal customer
        public void LoyalCustomerDiscountisTenOrNot()
        {
            var customerFactory = CustomerFactory.CreateCustomerInstance(102);
            var customerdiscount = Assert.IsType<LoyalCustomer>(customerFactory);
            Assert.Equal(10,customerdiscount.Discount);


        }
    }
}
