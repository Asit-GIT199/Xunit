using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    public class Calculator
    {
        public List<int> fiboNumber = new List<int>(){ 1,1,2,3,5,8,13,21};

        
        public int Add(int a, int b)
        {
            return a + b;
        }
        public double AddDouble(double a, double b)
        {
            return a + b;
        }
    }
}
