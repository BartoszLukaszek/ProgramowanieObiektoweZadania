using System;

namespace Lab7
{
    delegate double Operation(double a, double b);
    class Program
    {
        static double Addiction(double x, double y)
        {
            return x + y;
        }
        static double Mul(double x, double y)
        {
            return x * y;
        }

        static void Main(string[] args)
        {
            Operation add = Addiction;
            double result = add.Invoke(3, 5);
            Console.WriteLine(result);
            add = Mul;
            double result2 = add.Invoke(3, 5);
            Console.WriteLine(result2);
            Func<double, double, double> Operator = Addiction; //alternatywa dla delegate
            Func<double, double, double> Div = delegate (double x, double y)
            {
                return x / y;
            };

            Func<int> RandomInt = delegate ()
            {
                return new Random().Next(100);
            };

            Console.WriteLine(RandomInt.Invoke());
            Predicate<int> InRangeFrom0To100 = delegate (int x)
            {
                return x >= 0 && x <= 100;
            };
            Console.WriteLine(InRangeFrom0To100.Invoke(45));

            Func<int,int,int,bool> InRange= delegate (int value,int min, int max)
            {
                return value >= min && value <= max;
            };
            Console.WriteLine(InRange.Invoke(20,5,20));

            Action<string> Print = delegate (string text)
            {
                Console.WriteLine(text);
            };
            Print.Invoke("hej");

            Operation addLabda = (a, b) => a + b;
            Console.WriteLine(addLabda.Invoke(1,2));

            Func<double, double, double> DivLambda = (x, y) =>
            {
                if (y != 0)
                {
                    return x / y;
                }
                else
                {
                    throw new Exception("y is zero");
                }
            };

            Predicate<string> ThreeCharacters = (text) => text.Length == 3;

            Action<string> PrintLambda = text => Console.WriteLine(text.ToUpper());

            PrintLambda.Invoke("hej");            


        }
    }
}
