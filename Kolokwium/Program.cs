using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Kolokwium
{


    public static Complex operator / (Complex c, double d)
    {
        if (d == 0)
        {
            throw new DivideByZeroException();
        }

        return new Complex() { Re = c.Re / d, Im = c.Im / d };
    }


    public static bool operator >(Complex c1, Complex c2)
    {
        return c1.Re > c2.Re && c1.Im > c2.Im;
    }

    public static bool operator <(Complex c1, Complex c2)
    {
        return c1.Re < c2.Re && c1.Im < c2.Im;
    }
}
