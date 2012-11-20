// ***** Guidance generated code © Catharsis ***** //
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectBase.Tools;
using ProjectBase.Tools.Wiki;

namespace ProjectBase.Test.Wiki
{
    [TestClass]
    public class UrlTest : HttpContextTestBase
    {
        [TestMethod]
        public void UrlHttpOnly_OK()
        {
            var source = "[URL:http://wab.com/src.png]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><a href=\"http://wab.com/src.png\" title=\"http://wab.com/src.png\" >http://wab.com/src.png</a></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void UrlHttpAndText_OK()
        {
            var source = "[URL:http://wab.com/s_rc.png|TEXT:this is the path to source]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><a href=\"http://wab.com/s_rc.png\" title=\"http://wab.com/s_rc.png\" >this is the path to source</a></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void UrlAddressIsRecognized_OK()
        {
            var source = "[URL:https://abc.wab.com:555/way/id/this-is-it|TEXT:this is the path to source]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><a href=\"https://abc.wab.com:555/way/id/this-is-it\""
                    + " title=\"https://abc.wab.com:555/way/id/this-is-it\""
                    + " >this is the path to source</a></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void UrlAddressIsRecognized_FAIL()
        {
            var source = "[URL:https://abc.wab:com:555/way?id/thi&s-i?s-i:t_t&oo_Lo:ng|TEXT:this is the path to source]";
            var result = new WikiConverter().ConvertToHtml(source);
            Assert.IsTrue(result.IsEmpty(), "result was (instead of string empty):\r\n" + result);
        }

        [TestMethod]
        public void ShortTextFirstThenLongUrl_OK()
        {
            var source = "[URL:this is the path|https://abc.wab.com:555/way/id/this_is*the-path-too-long/src.png?a=1&d=2]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><a href=\"https://abc.wab.com:555/way/id/this_is*the-path-too-long/src.png?a=1&amp;d=2\""
                    + " title=\"https://abc.wab.com:555/way/id/this_is*the-path-too-long/src.png?a=1&amp;d=2\""
                    + " >this is the path</a></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void UrlLongHttpAndText_FAIL()
        {
            var source = "[URL:https://abc.wab.com:555/way/id/this_is_the_path_too_long/src.png?a=1&d=2 |TEXT:this is the path to source]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><a href=\"https://abc.wab.com:555/way/id/this_is_the_path_too_long/src.png?a=1&amp;d=2\""
                    + " title=\"https://abc.wab.com:555/way/id/this_is_the_path_too_long/src.png?a=1&amp;d=2\""
                    + " >this is the path to source</a></p>\r\n";
            Assert.IsFalse(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
            Assert.IsTrue(result.IsEmpty());
        }
        [TestMethod]
        public void UrlLongHttpAndText2_FAIL()
        {
            // too many tokens (more then 12) to see the ending |TEXT:
            var source = "[URL:https://abc.wab.com:555/way/:a:a:a:a:a:a:a:a:aid/this_is_the_path_too_long/src.png?a=1&d=2 |TEXT:this is the path to source]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><a href=\"https://abc.wab.com:555/way/:a:a:a:a:a:a:a:a:aid/this_is_the_path_too_long/src.png?a=1&amp;d=2\""
                    + " title=\"https://abc.wab.com:555/way/:a:a:a:a:a:a:a:a:aid/this_is_the_path_too_long/src.png?a=1&amp;d=2\""
                    + " >this is the path to source</a></p>\r\n";
            Assert.IsFalse(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
            Assert.IsTrue(result.IsEmpty());
        }

        [TestMethod]
        public void UrlLongHttpAndText2_OK()
        {
            var source = "[URL:\"https://abc.wab.com:555/way/:a:a:a:a:a:a:a:a:aid/this_is_the_path_too_long/src.png?a=1&d=2\" |TEXT:this is the path to source]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><a href=\"https://abc.wab.com:555/way/:a:a:a:a:a:a:a:a:aid/this_is_the_path_too_long/src.png?a=1&amp;d=2\""
                    + " title=\"https://abc.wab.com:555/way/:a:a:a:a:a:a:a:a:aid/this_is_the_path_too_long/src.png?a=1&amp;d=2\""
                    + " >this is the path to source</a></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void UrlQuotedText_OK()
        {
            var source = "[URL:\"https://abc.wab.com\" |TEXT:this is the path to source]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><a href=\"https://abc.wab.com\""
                    + " title=\"https://abc.wab.com\""
                    + " >this is the path to source</a></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void UrlQuotedDangerous_OK()
        {
            var source = "[URL:\"javascript:alert(1);a\"|TEXT:javascript]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><a href=\"/javascript:alert(1);a\""
                    + " title=\"/javascript:alert(1);a\""
                    + " >javascript</a></p>\r\n";
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
