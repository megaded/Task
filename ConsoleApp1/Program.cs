using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
         var result=   AreaCalculation.СalculatingAreaFigure(-1);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        static double test(params double[] sides)
        {
            if (sides[0] > sides[1] && sides[0] > sides[2])
                return (sides[1] * sides[2]) / 2;
            if (sides[1] > sides[0] && sides[1] > sides[2])
                return (sides[0] * sides[2]) / 2;
            return (sides[0] * sides[1]) / 2;
        }
    }
}
