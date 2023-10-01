using RPNCalcLib;

namespace RPNCalcTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 2)]
        [DataRow(3, 4)]
        [DataRow(-1, -2)]
        [DataRow(-3, -4)]
        [DataRow(double.MaxValue, double.MinValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void TestPush(double a, double b)
        {
            var calc = new RPNCalc();

            calc.Push(a);
            Assert.AreEqual(a, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Push(b);
            Assert.AreEqual(b, calc.X);
            Assert.AreEqual(a, calc.Y);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 2)]
        [DataRow(3, 4)]
        [DataRow(-1, -2)]
        [DataRow(-3, -4)]
        [DataRow(double.MaxValue, double.MinValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void TestDrop(double a, double b)
        {
            var calc = new RPNCalc();

            calc.Push(a).Push(b).Drop();
            Assert.AreEqual(a, calc.X);

            calc.Drop();
            Assert.AreEqual(0, calc.X);

            calc.Drop();
            Assert.AreEqual(0, calc.X);

        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 2)]
        [DataRow(3, 4)]
        [DataRow(-1, -2)]
        [DataRow(-3, -4)]
        [DataRow(double.MaxValue, double.MinValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void TestSwap(double a, double b)
        {
            var calc = new RPNCalc();

            calc.Push(a).Push(b).Swap();
            Assert.AreEqual(a, calc.X);
            Assert.AreEqual(b, calc.Y);

            calc.Swap();
            Assert.AreEqual(b, calc.X);
            Assert.AreEqual(a, calc.Y);

            calc.Drop();
            Assert.AreEqual(a, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Swap();
            Assert.AreEqual(0, calc.X);
            Assert.AreEqual(a, calc.Y);

        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 2)]
        [DataRow(3, 4)]
        [DataRow(-1, -2)]
        [DataRow(-3, -4)]
        [DataRow(double.MaxValue, double.MinValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void TestClear(double a, double b)
        {
            var calc = new RPNCalc();

            calc.Push(a).Clear();
            Assert.AreEqual(0, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Push(a).Push(b).Clear();
            Assert.AreEqual(0, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Clear().Clear().Clear();
            Assert.AreEqual(0, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Push(a).Push(b).Push(a).Push(b).Push(a).Push(b).Clear();
            Assert.AreEqual(0, calc.X);
            Assert.AreEqual(0, calc.Y);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 2)]
        [DataRow(3, 4)]
        [DataRow(-1, -2)]
        [DataRow(-3, -4)]
        [DataRow(double.MaxValue, double.MinValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void TestAdd(double a, double b)
        {
            var calc = new RPNCalc();

            calc.Push(a).Push(b).Add();
            Assert.AreEqual(a + b, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Add();
            Assert.AreEqual(a + b, calc.X);
            Assert.AreEqual(0, calc.Y);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 2)]
        [DataRow(3, 4)]
        [DataRow(-1, -2)]
        [DataRow(-3, -4)]
        [DataRow(double.MaxValue, double.MinValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void TestSubtract(double a, double b)
        {
            var calc = new RPNCalc();

            calc.Push(a).Push(b).Subtract();
            Assert.AreEqual(a - b, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Subtract();
            Assert.AreEqual(-1 * (a - b), calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Subtract();
            Assert.AreEqual((a - b), calc.X);
            Assert.AreEqual(0, calc.Y);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 2)]
        [DataRow(3, 4)]
        [DataRow(-1, -2)]
        [DataRow(-3, -4)]
        [DataRow(double.MaxValue, double.MinValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void TestMultiply(double a, double b)
        {
            var calc = new RPNCalc();

            calc.Push(a).Push(b).Multiply();
            Assert.AreEqual(a * b, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Push(a).Multiply();
            Assert.AreEqual(a * (a * b), calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Push(b).Multiply();
            Assert.AreEqual((a * b) * (a * b), calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Multiply();
            Assert.AreEqual(0, calc.X);
            Assert.AreEqual(0, calc.Y);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 0)]
        [DataRow(0, 1)]
        [DataRow(double.MaxValue, double.MinValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void TestDivide(double a, double b)
        {
            var calc = new RPNCalc();

            Assert.ThrowsException<DivideByZeroException>(() => calc.Divide());

            calc.Push(a).Push(b);
            if (b == 0)
            {
                Assert.ThrowsException<DivideByZeroException>(() => calc.Divide());
            }
            else
            {
                calc.Divide();
                Assert.AreEqual(a / b, calc.X);
                Assert.AreEqual(0, calc.Y);
            }

            calc.Push(b);
            if (b == 0)
            {
                Assert.ThrowsException<DivideByZeroException>(() => calc.Divide());
            }
            else
            {
                calc.Divide();
                Assert.AreEqual((a / b) / b, calc.X);
                Assert.AreEqual(0, calc.Y);
            }

            calc.Push(a);
            if (a == 0)
            {
                Assert.ThrowsException<DivideByZeroException>(() => calc.Divide());
            }
            else if (b != 0)
            {
                calc.Divide();
                Assert.AreEqual(((a / b) / b) / a, calc.X);
                Assert.AreEqual(0, calc.Y);
            }
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 2)]
        [DataRow(3, 0)]
        [DataRow(1, -2)]
        [DataRow(-3, 4)]
        [DataRow(double.MaxValue, double.MinValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void TestMod(double a, double b)
        {
            var calc = new RPNCalc();

            if (a == 0 || b == 0)
            {
                calc.Push(a).Push(b).Modulo();
                Assert.AreEqual(0, calc.X);
                Assert.AreEqual(0, calc.Y);
                return;
            }

            calc.Push(a).Push(b).Modulo();
            Assert.AreEqual(a % b, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Push(a).Modulo();
            Assert.AreEqual((a % b) % a, calc.X);
            Assert.AreEqual(0, calc.Y);

            calc.Modulo();
            Assert.AreEqual(0, calc.X);
            Assert.AreEqual(0, calc.Y);
        }
    }
}