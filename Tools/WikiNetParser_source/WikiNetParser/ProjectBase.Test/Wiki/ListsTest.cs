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
    public class ListsTest : TestBase
    {
        [TestMethod]
        public void ListLIWithInnerLI_OK()
        {
            var source = "[LI\r\n"
                + "first row\r\n"
                + "[LI\r\n"
                + "inner [B:list is bold]\r\n"
                + "the link to[URL:http://catarsa.com]\r\n"
                + "LI]\r\n"
                + "LI]\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<ul>\r\n<li>first row<ul>\r\n"
                + "<li>"
                + "inner <b>list is bold</b></li>\r\n"
                + "<li>the link to<a href=\"http://catarsa.com\" title=\"http://catarsa.com\" >http://catarsa.com</a></li>\r\n"
                + "</ul>\r\n</li>\r\n"
                + "</ul>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void NumberedListWithInnerUnorderedList_OK()
        {
            var source = "* first [B:item]\r\n"
                       + "* second\r\n"
                       + "** [BLUE:next] item\r\n\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<ul>\r\n<li>first <b>item</b></li>\r\n"
                + "<li>second<ul>\r\n"
                + "<li>"
                + "<span style=\"color:Blue;\" >next</span> item</li>\r\n"
                + "</ul>\r\n</li>\r\n"
                + "</ul>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void NumberedListWithInnerList_OK()
        {
            var source = "# first [B:item]\r\n"
                       + "## [BLUE:second] item\r\n\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<ol>\r\n<li>first <b>item</b><ol>\r\n"
                + "<li>"
                + "<span style=\"color:Blue;\" >second</span> item</li>\r\n"
                + "</ol>\r\n</li>\r\n"
                + "</ol>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void ListWithInnerList_OK()
        {
            var source = "* first [B:item]\r\n"
                       + "** [BLUE:second] item\r\n\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<ul>\r\n<li>first <b>item</b><ul>\r\n"
                + "<li>"
                + "<span style=\"color:Blue;\" >second</span> item</li>\r\n"
                + "</ul>\r\n</li>\r\n"
                + "</ul>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void ListLI_OK()
        {
            var source = "[LI\r\n"
                + "first item\r\n"
                + "second item\r\n"
                + "LI]\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<ul>\r\n<li>first item</li>\r\n"
                + "<li>second item</li>\r\n"
                + "</ul>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void ListNUM_OK()
        {
            var source = "[NUM \r\n"
                + "[SAMP:first is sample] item\r\n"
                + "second link is [URL:catarsa.com|http://catarsa.com]\r\n"
                + "NUM]\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<ol>\r\n<li><samp>first is sample</samp> item</li>\r\n"
                + "<li>second link is <a href=\"http://catarsa.com\" title=\"http://catarsa.com\" >catarsa.com</a></li>\r\n"
                + "</ol>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void ListWithAsterix_OK()
        {
            var source = "* first [B:item]\r\n"
                       + "* [BLUE:second] item\r\n\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<ul>\r\n<li>first <b>item</b></li>\r\n"
                + "<li><span style=\"color:Blue;\" >second</span> item</li>\r\n"
                + "</ul>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void ListWithHash_OK()
        {
            var source = "# first [I:item]\r\n"
                       + "# [PURPLE:second] item\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<ol>\r\n<li>first <i>item</i></li>\r\n"
                + "<li><span style=\"color:Purple;\" >second</span> item</li>\r\n"
                + "</ol>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
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
