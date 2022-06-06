using System;
using System.Collections.Generic;
using System.Linq;

public class ProgramBase
{
    public static void Main(string[] args)
    {
        Complex a = new Complex() { Re = 3d, Im = 2d };
        double factor = 5.0d;
        int points = 0;
        if ((a * factor).Re == 15 && (a * factor).Im == 10 && (factor * a).Re == 15 && (factor * a).Im == 10
            && (5 * new Complex() { Re = 1, Im = -5 }).Im == -25)
        {
            Console.WriteLine("Zadanie 1: Ok");
            points++;
        }
        if (new Complex() { Re = 1, Im = 2 } == new Complex() { Re = 1, Im = 2 } &&
            !(new Complex() { Re = 1, Im = 2 } == new Complex() { Re = 1, Im = 3 }))
        {
            Console.WriteLine(("Zadanie 2: Ok"));
            points++;
        }

        if (new Complex() { Re = 1, Im = 2 }.Equals(new Complex() { Re = 1, Im = 2 }) &&
            !new Complex() { Re = 1, Im = 2 }.Equals(new Complex() { Re = 1, Im = 3 }))
        {
            Console.WriteLine(("Zadanie 3: Ok"));
            points++;
        }

        List<Complex> list = new List<Complex>()
        {
            new Complex() {Re = -1, Im = 1},
            new Complex() {Re = 2, Im = -2},
            new Complex() {Re = 3, Im = -3},
            new Complex() {Re = -4, Im = 4},
            new Complex() {Re = -1, Im = 0},
            new Complex() {Re = 0, Im = 2},
        };
        Task4(list);
        if (list[0] == new Complex() { Re = -1, Im = 0 } && list[1] == new Complex() { Re = -1, Im = 1 } &&
            list[5] == new Complex() { Re = -4, Im = 4 })
        {
            Console.WriteLine(("Zadanie 4: Ok"));
            points++;
        }
        var result1 = Task5(list).ToList();
        var result2 = Task5(Enumerable.Repeat<Complex>(new Complex() { Re = 3, Im = 4 }, 2)).ToList();
        if (result1.Count == 2 && result1.Contains(2.8284271247461903) && result1.Contains(4.242640687119285)
            && result2.Count == 2 && result2.Contains(5))
        {
            Console.WriteLine(("Zadanie 5: Ok"));
            points++;
        }
        Console.WriteLine($"Suma punktów: {points}");
    }
}