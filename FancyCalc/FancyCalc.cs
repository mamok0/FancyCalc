using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FancyCalc
{
    public class FancyCalcEnguine
    {

        public double Add(int a, int b)
        {
            return (double)a + b;
        }


        public double Subtract(int a, int b)
        {
            return (double)a - b;
        }


        public double Multiply(int a, int b)
        {
            return (double)a * b;
        }

        //generic calc method. usage: "10 + 20"  => result 30
        public double Culculate(string expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            char[] expressionsSymbols = { '+', '-', '/', '*' };
            char expr = '0';
            for (int i = 0; i < expression.Length; i++)
            {
                for(int j=0; j<expressionsSymbols.Length; j++)
                {
                    if (expression[i] == expressionsSymbols[j])
                        expr = expression[i];
                }
            }
            string[] numbers_string = expression.Trim().Split(expr);
            IEnumerable<double> nums_double = numbers_string.Select(num => Convert.ToDouble(num));
            double answer = 0;
            switch(expr)
            {
                case '+': answer = nums_double.First() + nums_double.Last(); break;
                case '-': answer = nums_double.First() - nums_double.Last(); break;
                case '*': answer = nums_double.First() * nums_double.Last(); break;
                case '/': answer = nums_double.First() / nums_double.Last(); break;
            }
            return answer;
        }
    }
}
