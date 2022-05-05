using System;

namespace Lab2_Zadanie
{
    internal class Program
    {
        //Zadanie 1
        static void Main(string[] args)
        {
            double[][] macieze =
            {
                new double[] {106,244,55},
                new double[] {123,384,215},
                new double[] {255,284,152},
                new double[] {5,233,126},
                new double[] {89,25,3},
                new double[] {2612,662,2552},
                new double[] {266,294,366},
            };

            IAggreagate aggreagate = new DoubleAggreagate(macieze);
            IIterator iterator = aggreagate.createIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.GetNext());
            }
        }

        interface IAggreagate
        {
            IIterator createIterator();
        }
        interface IIterator
        {
            bool HasNext();
            string GetNext();
        }

        class DoubleAggreagate : IAggreagate
        {
            internal double[][] macieze;

            public DoubleAggreagate(double[][] names)
            {
                this.macieze = names;
            }

            public IIterator createIterator()
            {
                return new StringIterrator(this);
            }
        }

        class StringIterrator : IIterator
        {
            private DoubleAggreagate aggreagate;
            private int currentIndex = 0;
            public StringIterrator(DoubleAggreagate aggreagate)
            {
                this.aggreagate = aggreagate;
                this.currentIndex = aggreagate.macieze.Length;
            }

            public string GetNext()
            {
                int _index = currentIndex;
                Array.Sort(aggreagate.macieze[_index]);
                return $"{aggreagate.macieze[_index][0]} {aggreagate.macieze[_index][1]} {aggreagate.macieze[_index][2]}";
            }

            public bool HasNext()
            {
                currentIndex--;
                return currentIndex >= 0;
            }
        }

    }
}
