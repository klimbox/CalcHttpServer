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
            CalcHttpServer calcServer = new CalcHttpServer("http://localhost:8080/");
            calcServer.Start();
            Console.ReadLine();
        }
    }
}
