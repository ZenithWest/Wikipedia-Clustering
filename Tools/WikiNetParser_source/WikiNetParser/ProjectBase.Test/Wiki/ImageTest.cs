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
    public class ImageTest : HttpContextTestBase
    {
        [TestMethod]
        public void ImageWithoutAttributes_OK()
        {
            var source = "[IMG:src.png]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><img src=\"/src.png\" alt=\"/src.png\" style=\"\" /></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void ImageWidth_OK()
        {
            var source = "[IMG:http://wab.com/src.png | WIDTH:100px ]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><img src=\"http://wab.com/src.png\" alt=\"http://wab.com/src.png\" style=\"width: 100px;\" /></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void ImageWidthFloat_OK()
        {
            var source = "[IMG:http://wab.com/src.png |WIDTH:50px |FLOAT:right ]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><img src=\"http://wab.com/src.png\" alt=\"http://wab.com/src.png\" style=\"width: 50px;float: right;\" /></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void ImageFloat_OK()
        {
            var source = "[IMG:http://wab.com/src.png|FLOAT:right ]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><img src=\"http://wab.com/src.png\" alt=\"http://wab.com/src.png\" style=\"float: right;\" /></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void ImageHeightFloat_OK()
        {
            var source = "[IMG:http://wab.com/src.png| HEIGHT: 100px|FLOAT:right]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><img src=\"http://wab.com/src.png\" alt=\"http://wab.com/src.png\" style=\"height: 100px;float: right;\" /></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void ImageFloatHeightWidth_OK()
        {
            var source = "[IMG:http://wab.com/src.png|FLOAT:right | HEIGHT: 100px|WIDTH:50px]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><img src=\"http://wab.com/src.png\" alt=\"http://wab.com/src.png\" style=\"float: right;height: 100px;width: 50px;\" /></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void ImageHeightWidth_OK()
        {
            var source = "[IMG:http://wab.com/src.png | HEIGHT: 100px|WIDTH:50px]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><img src=\"http://wab.com/src.png\" alt=\"http://wab.com/src.png\" style=\"height: 100px;width: 50px;\" /></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
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
