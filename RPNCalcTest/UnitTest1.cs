using RPNCalcLib;

namespace RPNCalcTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            var calc = new RPNCalc();
            calc.push(5).push(7).add();
            Assert.AreEqual(12, calc.x);
            Assert.AreEqual(0, calc.y);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 2)]
        [DataRow(3, 4)]
        [DataRow(double.MaxValue, double.MinValue)]
        public void TestPush(double a, double b) {
            var calc = new RPNCalc();

            calc.push(a);
            Assert.AreEqual(a, calc.x);
            Assert.AreEqual(0, calc.y);

            calc.push(b);
            Assert.AreEqual(b, calc.x);
            Assert.AreEqual(a, calc.y);
        }

        [TestMethod]
        public void TestSubtract() {
            var calc = new RPNCalc();
            calc.push(5).push(7).subtract();
            Assert.AreEqual(-2, calc.x);
            Assert.AreEqual(0, calc.y);
        }
    }
}