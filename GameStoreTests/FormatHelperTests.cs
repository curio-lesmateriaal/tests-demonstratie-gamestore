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
            decimal price = 500;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("500.00", formatted);
        }

        [TestMethod]
        public void FormatMoney_NegativeInteger()
        {
            decimal price = -500;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("-500.00", formatted);
        }

        [TestMethod]
        public void FormatMoney_PositiveDecimal()
        {
            decimal price = 234.56m;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("234.56", formatted);
        }

        [TestMethod]
        public void FormatMoney_NegativeDecimal()
        {
            decimal price = -234.56m;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("-234.56", formatted);
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
        public void FormatMoney_ThousandsSeparatorPositive()
        {
            decimal price = 12345.67m;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("12,345.67", formatted);
        }

        [TestMethod]
        public void FormatMoney_ThousandsSeparatorNegative()
        {
            decimal price = -12345.67m;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("-12,345.67", formatted);
        }

        [TestMethod]
        public void FormatMoney_MaxValue()
        {
            decimal price = decimal.MaxValue;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("79,228,162,514,264,337,593,543,950,335.00", formatted);
        }

        [TestMethod]
        public void FormatMoney_MinValue()
        {
            decimal price = decimal.MinValue;
            string formatted = FormatHelper.FormatMoney(price);
            Assert.AreEqual("-79,228,162,514,264,337,593,543,950,335.00", formatted);
        }
    }
}