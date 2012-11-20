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
    public class CodePlexStyleTest : HttpContextTestBase
    {
        [TestMethod]
        public void CodePlexStyleBold_OK()
        {
            var source = "a *classREDclassfirst item* b\r\n"
                       + "*second item*\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>a <b>classREDclassfirst item</b> b</p>\r\n"
                + "<p><b>second item</b></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void CodePlexStyleItalic_OK()
        {
            var source = "a _first item_ b\r\n"
                       + "_second item_\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>a <i>first item</i> b</p>\r\n"
                + "<p><i>second item</i></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void CodePlexStyleBoldButField_OK()
        {
            var source = "a _REDclassmy _first item b\r\n"
                       + "second item_\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>a _REDclassmy _first item b</p>\r\n"
                + "<p>second item_</p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void CodePlexStyleItalicButField_OK()
        {
            var source = "a *REDclassmy *first item b\r\n"
                       + "second item*\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>a *REDclassmy *first item b</p>\r\n"
                + "<p>second item*</p>\r\n";
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
