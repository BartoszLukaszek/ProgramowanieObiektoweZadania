using System;

namespace Lab_1_Zadanie
{
    public class Ulamek
    {
        private readonly int _licznik;
        private readonly int _mianownik;
        public int Licznik
        {
            get { return _licznik; }
        }

        public int Mianownik
        {
            get { return _mianownik; }
        }

        public Ulamek(int licznik, int mianownik)
        {
            _licznik = licznik;
            _mianownik = mianownik;
        }

        public override string ToString()
        {
            return $"{Licznik}/{Mianownik}";
        }

        public static Ulamek operator +(Ulamek u1, Ulamek u2)
        {
            return new Ulamek(u1.Licznik * u2.Mianownik + u2.Licznik * u1.Mianownik, u1.Mianownik * u2.Mianownik);
        }

        public static Ulamek operator -(Ulamek u1, Ulamek u2)
        {
            return new Ulamek(u1.Licznik * u2.Mianownik - u2.Licznik * u1.Mianownik, u1.Mianownik * u2.Mianownik);
        }

        public static Ulamek operator *(Ulamek u1, Ulamek u2)
        {
            return new Ulamek(u1.Licznik * u2.Licznik, u1.Mianownik * u2.Mianownik);
        }

        public static Ulamek operator /(Ulamek u1, Ulamek u2)
        {
            return new Ulamek(u1.Licznik * u2.Mianownik, u1.Mianownik * u2.Licznik);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Ulamek ulamek = new Ulamek(7, 1);
            Ulamek ulamek2 = new Ulamek(1, 7);
            Ulamek a = ulamek + ulamek2;
            Ulamek b = ulamek - ulamek2;
            Ulamek c = ulamek * ulamek2;
            Ulamek d = ulamek / ulamek2;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
        }
    }
}
