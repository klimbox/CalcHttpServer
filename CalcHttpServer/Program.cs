using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcHttpServer calcServer = new CalcHttpServer("http://localhost:8370/");
            calcServer.Start();
            Console.ReadLine();
        }
    }
}
