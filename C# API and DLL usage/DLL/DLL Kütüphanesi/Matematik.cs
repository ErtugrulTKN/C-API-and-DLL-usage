using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Kütüphanesi
{
    public class Matematik
    {
        public class Dörtİşlem
        {
            public static double topla(double a, double b)
            {
                return a + b;
            }

            public static double çıkar(double a, double b)
            {
                 
                return a - b;
            }

            public static double çarp(double a, double b)
            {
                return a * b;
            }

            public static double böl(double a, double b)
            {
                return a / b;
            }
        }

        public class Geometri
        {
            public static double dikdörtgenAlan(double x, double y)
            {
                return x * y;
            }

            public static double daireAlan(double r)
            {
                return Math.PI * Math.Pow(r, 2);
            }
        }
    }
}
