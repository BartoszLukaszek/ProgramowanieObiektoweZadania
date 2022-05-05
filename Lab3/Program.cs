using System;

namespace Lab3
{
    //class Stack<t> where T:Student
    class Stack<T>
    {
        private T[] _arr = new T[10];
        private int _last = -1;
        public void Push(T item)
        {
            _arr[++_last] = item;
        }

        public T Pop()
        {
            return _arr[_last--];
        }
    }
    class Student
    {
        public int Egzam { get; set; }

        public T GetReward<T>(T reward)
        {
            if (Egzam > 50)
            {
                return reward;
            }
            else
            {
                return default;
            }
        }
    }

    class Prymu : Student
    {

    }
    class Program
    {

        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            Stack<string> stackString = new Stack<string>();
            Stack<Prymu> stackStudent = new Stack<Prymu>();
            stack.Push(12);
            stack.Push(13);
            stack.Push(14);
            Console.WriteLine( stack.Pop());
            Console.WriteLine( stack.Pop());
            Console.WriteLine( stack.Pop());


            Student student = new Student() { Egzam = 55};
            var reward = student.GetReward(100);
            Console.WriteLine(reward);

            ValueTuple<string, decimal, int> product = ValueTuple.Create("Laptop", 2000m, 5);
            (string, decimal, int) laptop = ("Laptop", 2000m, 5);
            Console.WriteLine(product==laptop);
            product.Item1 = "cell phone";
            Console.WriteLine(product);
            (string name, decimal price, int count) tuple = laptop;
            Console.WriteLine(tuple.name);
            tuple = (name: "laptop", price: 5000m,count:5);
        }
    }
}
