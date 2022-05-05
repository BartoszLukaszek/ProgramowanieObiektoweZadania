using System;
using System.Collections.Generic;

namespace Lab6
{
    class Student: IComparable<Student>
    {
        public string Name { get; set; }
        public int Ects { get; set; }

        public int CompareTo(Student other)
        {
            if (Name.CompareTo(other.Name) == 0)
            {
                return Ects.CompareTo(other.Ects);
            }
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            Console.WriteLine("Student Equals");
            return obj is Student student &&
                   Name == student.Name &&
                   Ects == student.Ects;
        }

        public override int GetHashCode()
        {
            Console.WriteLine("Student Hashcode");
            return HashCode.Combine(Name, Ects);
        }


    }
    class Program
    {

        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("ewa");
            names.Add("adam");
            names.Add("karol");

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            
            Console.WriteLine(names.Contains("adam"));
            Console.WriteLine("--------------");

            ICollection<Student> Students = new List<Student>();
            Students.Add(new Student() { Name="Adam",Ects=20});
            Students.Add(new Student() { Name="Ewa",Ects=55});
            Students.Add(new Student() { Name="Karol",Ects=15 });
            Students.Remove(new Student() { Name = "Adam", Ects = 20 });
            foreach (var item in Students)
            {
                Console.WriteLine($"{item.Name} {item.Ects}");
            }
            Console.WriteLine(Students.Contains(new Student() { Name = "Adam", Ects = 20 }));

            List<Student> list = (List<Student>)Students;
            Console.WriteLine(list[0]);
            list.Insert(1, new Student() { Name = "Tomasz", Ects = 20 });
            foreach (var item in Students)
            {
                Console.WriteLine($"{item.Name} {item.Ects}");
            }
            Console.WriteLine(list.IndexOf(new Student() { Name = "Karol", Ects = 15 }));
            list.RemoveAt(0);

            Console.WriteLine("---------------SET-----------------------");
            ISet<string> set = new HashSet<string>();
            set.Add("Ewa");
            set.Add("Karol");
            set.Add("Adam");
            set.Add("Adam");
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            ISet<Student> studentGroup = new HashSet<Student>();
            studentGroup.Add(new Student() { Name = "Adam", Ects = 20 });
            studentGroup.Add(new Student() { Name = "Ewa", Ects = 55 });
            studentGroup.Add(new Student() { Name = "Karol", Ects = 15 });
            studentGroup.Add(new Student() { Name = "Adam", Ects = 125 });
            foreach (var item in studentGroup)
            {
                Console.WriteLine(item.Name +" " + item.Ects);
            }
            studentGroup.Contains(new Student() { Name = "Adam", Ects = 20 });
            //studentGroup.Remove(new Student() { Name = "Karol", Ects = 15 });
            studentGroup = new SortedSet<Student>(studentGroup);
            foreach (var item in studentGroup)
            {
                Console.WriteLine(item.Name + " " + item.Ects);
            }

            Console.WriteLine("---------------------------------------------");
            Dictionary<Student, string> phoneBook = new Dictionary<Student, string>();
            phoneBook[list[0]] = "123456789";
            phoneBook[list[1]] = "987654321";
            Console.WriteLine(phoneBook.Keys);
            if (phoneBook.ContainsKey(list[0])) {
                Console.WriteLine("ma");
            }
            else
            {
                Console.WriteLine("nie ma");
            }
            foreach (var item in phoneBook)
            {
                Console.WriteLine(item.Key.Name+" " +item.Value);
            }

            string[] arr = { "adam", "karol", "ewa", "ewa", "ania", "karol", "adam", "adam" };
            //oblicz ile razy wstepuje każde imie imin w tablic
            Dictionary<string, int> counters = new Dictionary<string, int>();
            foreach (var item in arr)
            {
                if (counters.ContainsKey(item))
                {
                    counters[item] += 1;
                }
                else
                {
                    counters[item] = 1;
                }
            }
            foreach (var item in counters)
            {
                Console.WriteLine(item.Key+": "+item.Value);
            }
        }
    }
}
