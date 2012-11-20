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
    public class TagTest : HttpContextTestBase
    {
        [TestMethod]
        public void Tag_OK()
        {
            var source = "<a href=\"#myname\">abc</a>";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><span class=\"tag\" >&lt;a href=&quot;#myname&quot;"
                + "&gt;</span>abc<span class=\"tag\" >&lt;/a&gt;</span></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void TagElement2Lines_OK()
        {
            var source = "<a href=\"#myname\"\r\n type=\"myType\">\r\n  abc</a>";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><span class=\"tag\" >&lt;a href=&quot;#myname&quot;"
                + "\r\n<br /> type=&quot;myType&quot;&gt;</span></p>\r\n"
                + "<p>&nbsp;&nbsp;abc<span class=\"tag\" >&lt;/a&gt;</span></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void Tag2Lines_OK()
        {
            var source = "<a href=\"#myname\">\r\n  abc</a>";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><span class=\"tag\" >&lt;a href=&quot;#myname&quot;"
                + "&gt;</span></p>\r\n"
                + "<p>&nbsp;&nbsp;abc<span class=\"tag\" >&lt;/a&gt;</span></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void TagInXML_OK()
        {
            var source = "[XML<a href=\"#myname\">abc</a>XML]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<code class=\"xml\" >\r\n"
                + "<span class=\"tag\" ><span class=\"smbl\" >&lt;</span>a href<span class=\"smbl\" >=</span>"
                + "<span class=\"qtd\" >&quot;#myname&quot;</span><span class=\"smbl\" >&gt;</span></span>"
                + "abc<span class=\"tag\" ><span class=\"smbl\" >&lt;/</span>a<span class=\"smbl\" >&gt;</span></span><br />\r\n"
                + "</code>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void TagInHTML_OK()
        {
            var source = "[HTML <a href=\"#myname\">abc</a> \r\nHTML]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<code class=\"html\" >\r\n"
                + " <span class=\"tag\" ><span class=\"smbl\" >&lt;</span>a "
                + "<span class=\"html\" >href</span><span class=\"smbl\" >=</span>"
                + "<span class=\"qtd\" >&quot;#myname&quot;</span><span class=\"smbl\" >&gt;</span></span>"
                + "abc<span class=\"tag\" ><span class=\"smbl\" >&lt;/</span>a<span class=\"smbl\" >&gt;</span></span> <br />\r\n"
                + "</code>\r\n";
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
