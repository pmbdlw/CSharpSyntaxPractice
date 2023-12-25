using CSharpTest.Delegate;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class GeneralDelegateTest
    {

        [Test]
        public void SumCalculateOptionTest()
        {
            var calcu = new GeneralDelegate();
            var optionList = new CalculateOptionTwoNumbers[] { calcu.Add, calcu.Subtract, calcu.Multiply, calcu.Divide };
            // Assert.AreEqual(40, calcu.SumCalculateOption(optionList, 5, 6));
            Assert.That(40, Is.EqualTo(calcu.SumCalculateOption(optionList, 5, 6)));
        }
    }
}