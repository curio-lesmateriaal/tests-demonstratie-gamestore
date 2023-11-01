using GameStore;
using System.Globalization;

namespace GameStoreTests
{
    [TestClass]
    public class FormatHelperTests
    {
        [TestInitialize]
        public void Initialize()
        {
            // Force the culture to use American notation decimal separator for these tests
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
        }

        [TestMethod]
        public void FormatMoney_Zero()
        {
            decimal price = 0;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("0.00", formatted);
        }

        [TestMethod]
        public void FormatMoney_PositiveInteger()
        {
            decimal price = 1000;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("1000.00", formatted);
        }

        [TestMethod]
        public void FormatMoney_NegativeInteger()
        {
            decimal price = -1000;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("-1000.00", formatted);
        }

        [TestMethod]
        public void FormatMoney_PositiveDecimal()
        {
            decimal price = 1234.56m;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("1234.56", formatted);
        }

        [TestMethod]
        public void FormatMoney_NegativeDecimal()
        {
            decimal price = -1234.56m;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("-1234.56", formatted);
        }

        [TestMethod]
        public void FormatMoney_RoundingUp()
        {
            decimal price = 12.999m;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("13.00", formatted);
        }

        [TestMethod]
        public void FormatMoney_RoundingDown()
        {
            decimal price = 12.001m;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("12.00", formatted);
        }

        [TestMethod]
        public void FormatMoney_MaxValue()
        {
            decimal price = decimal.MaxValue;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("79228162514264337593543950335.00", formatted);
        }

        [TestMethod]
        public void FormatMoney_MinValue()
        {
            decimal price = decimal.MinValue;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("-79228162514264337593543950335.00", formatted);
        }
    }
}