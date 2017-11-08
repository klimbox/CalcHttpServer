
using HttpCalculator;
using NUnit.Framework;

namespace UT
{
    [TestFixture]
    public class UnitTest1
    {
        CalcHttpServer calcHttpServer = new CalcHttpServer(0); 
        [TestCase(2, 4, "+", "6")]
        [TestCase(22, 6, "-", "16")]
        [TestCase(5, 2, "*", "10")]
        [TestCase(10, 2, "/", "5")]
        [TestCase(10, 2, "f", "Err. Operation not supported")]
        [Test]
        public void Calcul(double num1, double num2, string opr,  string exp)
        {
            Assert.AreEqual(exp, calcHttpServer.Calculate(num1, num2, opr));
        }
    }
}
