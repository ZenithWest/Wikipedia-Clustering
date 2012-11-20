// ***** Guidance generated code © Catharsis ***** //
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProjectBase.Tools.Wiki;

namespace ProjectBase.Test.Wiki
{
    [TestClass]
    public class PlainTextTest : TestBase
    {
        [TestMethod]
        public void SimpleText_MoreLines_OK()
        {
            var source = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, \r\n"
                + " sed do eiusmod tempor incididunt ut labore et \r\n"
                + "dolore magna aliqua. Ut enim ad minim veniam, ";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, </p>\r\n"
                + "<p> sed do eiusmod tempor incididunt ut labore et </p>\r\n"
                + "<p>dolore magna aliqua. Ut enim ad minim veniam, </p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void Unicode_MoreLines_OK()
        {
            var source = "Nejelo se na Jitřenku, jelo se na tábor. Na opravdický tábor. \r\n"
                + " Zvláštní družina, sestavená ze starších členů oddílu \r\n"
                + "- byli to Vlasatka, Kulich, Kutilka a Modrásek - ";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>Nejelo se na Jitřenku, jelo se na t&#225;bor. Na opravdick&#253; t&#225;bor. </p>\r\n"
                + "<p> Zvl&#225;štn&#237; družina, sestaven&#225; ze starš&#237;ch členů odd&#237;lu </p>\r\n"
                + "<p>- byli to Vlasatka, Kulich, Kutilka a Modr&#225;sek - </p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void SimpleText_OneLine_OK()
        {
            var source = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, ";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, </p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void Unicode_OneLine_OK()
        {
            var source = "Nejelo se na Jitřenku, jelo se na tábor. Na opravdický tábor. ";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>Nejelo se na Jitřenku, jelo se na t&#225;bor. Na opravdick&#253; t&#225;bor. </p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        public void _OK()
        {
            var source = "";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "";
            Assert.IsTrue(source.Equals(expected, StringComparison.Ordinal));
        }
        #region Additional test attributes

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext) { }

        [ClassCleanup]
        public static void MyClassCleanup() { }

        [TestInitialize]
        public override void MyTestInitialize() { base.MyTestInitialize(); }

        [TestCleanup]
        public override void MyTestCleanup() { base.MyTestCleanup(); }
        #endregion Additional test attributes
    }
}
