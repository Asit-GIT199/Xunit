using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Calculations.Tests
{
    public class TestDataShare
    {
        public static IEnumerable<object[]> IsOddorEvenExternalData
        {
            get
            {
                var allLines = File.ReadAllLines("IsOddEvenTestData.txt");
                return allLines.Select(x =>
                {
                    var splitLine = x.Split(',');
                    return new object[] { int.Parse(splitLine[0]), bool.Parse(splitLine[1]) };
                });
            }
        }
    }
}
