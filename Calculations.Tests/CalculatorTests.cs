using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void TestAdd()
        {
            Assert.True(true);
        }

        [Fact]
        public void Add_Two_int_results_int()
        {
            var calc = new Calculator();
            var result = calc.Add(1,2);
            Assert.Equal(3,result);
        }

        [Fact]
        public void Add_Two_double_results_double()
        {
            var calc = new Calculator();
            //var result = calc.AddDouble(1.3, 2.5);
            //Assert.Equal(3.8, result);

            var result = calc.AddDouble(1.37, 2.52);
            Assert.Equal(3.9, result,1);//adding precision value
        }

        [Fact]
        public void FN_LN_results_FullName()
        {
            var name = new Name();            

            var result = name.FullName("Asit","Mohanty");
            Assert.StartsWith("Asit", result);
            Assert.EndsWith("Mohanty", result);
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);//regular expression

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result));

        }

        //Testing a collection
        [Fact]
        [Trait("Category","Fibo")]
        public void Fibo_Does_not_Include_Zero()
        {
            var calc = new Calculator();
            Assert.All(calc.fiboNumber, n => Assert.NotEqual(0,n));
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void Fibo_Include_Thirteen()
        {
            var calc = new Calculator();
            Assert.Contains(13,calc.fiboNumber);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void Fibo_Doesnot_Include_Four()
        {
            var calc = new Calculator();
            Assert.DoesNotContain(4, calc.fiboNumber);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void Check_Collction_fiboNumber()
        {
            var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13,21 };
            var calc = new Calculator();
            Assert.Equal(expectedCollection, calc.fiboNumber);
        }
        
    }
}
