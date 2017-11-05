using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpCalculator;

namespace UT
{
    [TestClass]
    public class UnitTest1
    {
        CalcHttpServer calcHttpServer = new CalcHttpServer(0); 
        [DataTestMethod]
        [DataRow(2, 4, "+", "6")]
        [DataRow(22, 6, "-", "16")]
        [DataRow(5, 2, "*", "10")]
        [DataRow(10, 2, "/", "5")]
        [DataRow(10, 2, "f", "Err. Operation not supported")]
        public void Calcul(double num1, double num2, string opr,  string exp)
        {
            Assert.AreEqual(exp, calcHttpServer.Calculate(num1, num2, opr));
        }
    }
}
