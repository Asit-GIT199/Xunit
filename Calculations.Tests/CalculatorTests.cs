using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Tests
{
    public class CalculatorFixture
    {
        public Calculator calc = new Calculator();
    }


    //if a class in XUnit is implemented the IDisposable interface then 
    //it will automatically call the IDisposable interface and memory will be dispose
    public class CalculatorTests : IClassFixture<CalculatorFixture>, IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly CalculatorFixture _calculatorFixture;
        private readonly MemoryStream memoryStream;
        public CalculatorTests(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _calculatorFixture = calculatorFixture;
            _testOutputHelper.WriteLine("Constructor");

            memoryStream = new MemoryStream();
        }

        [Fact]
        public void TestAdd()
        {
            Assert.True(true);
        }

        [Fact]
        public void Add_Two_int_results_int()
        {
            //var calc = new Calculator();
            var calc = _calculatorFixture.calc;
            var result = calc.Add(1,2);
            Assert.Equal(3,result);
        }

        [Fact]
        public void Add_Two_double_results_double()
        {
            //var calc = new Calculator();
            var calc = _calculatorFixture.calc;
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
            _testOutputHelper.WriteLine("Fibo_Does_not_Include_Zero");
            //var calc = new Calculator();
            var calc = _calculatorFixture.calc;
            Assert.All(calc.fiboNumber, n => Assert.NotEqual(0,n));
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void Fibo_Include_Thirteen()
        {
            _testOutputHelper.WriteLine("Fibo_Include_Thirteen");
            //var calc = new Calculator();
            var calc = _calculatorFixture.calc;
            Assert.Contains(13,calc.fiboNumber);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void Fibo_Doesnot_Include_Four()
        {
            _testOutputHelper.WriteLine("Fibo_Doesnot_Include_Four");
            //var calc = new Calculator();
            var calc = _calculatorFixture.calc;
            Assert.DoesNotContain(4, calc.fiboNumber);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void Check_Collction_fiboNumber()
        {
            _testOutputHelper.WriteLine("Check_Collction_fiboNumber");
            var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13,21 };
            //var calc = new Calculator();
            var calc = _calculatorFixture.calc;
            Assert.Equal(expectedCollection, calc.fiboNumber);
        }

        [Fact]
        public void Is_GivenOddvlue_ReturnsTrue()
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(5);
            Assert.True(result);
        }

        [Fact]
        public void Is_GivenOddvlue_ReturnsFalse()
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(8);
            Assert.False( result);
        }

        [Theory]
        [InlineData(1,true)]
        [InlineData(5, true)]
        [InlineData(8, false)]
        public void Is_GivenOddvlue_Returns_True_Or_False(int value, bool expected)
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]        
        [MemberData(nameof(TestDataShare.IsOddorEvenExternalData), MemberType = typeof(TestDataShare))]        
        public void Is_GivenOddvlue_Returns_True_Or_False_From_ExternalFile(int value, bool expected)
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [IsOddOrEvenData]
        public void Is_GivenOddvlue_Returns_True_Or_False_From_CustomAttribute(int value, bool expected)
        {
            var calc = _calculatorFixture.calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            memoryStream.Close();
        }
    }
}
