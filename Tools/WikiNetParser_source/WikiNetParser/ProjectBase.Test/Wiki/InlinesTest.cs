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
    public class InlinesTest : HttpContextTestBase
    {
        [TestMethod]
        public void CsharpKeyWordsAsText_OK()
        {
            var source = "a class is null and void \r\n"
                       + "string readonly Where id name\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>a class is null and void </p>\r\n"
                + "<p>string readonly Where id name</p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void CsharpKeyWordsAsCode_OK()
        {
            var source = "[CODE class is null CODE]\r\n"
                       + "[HTML title id name HTML]\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<code class=\"code\" >\r\n"
                + " <span class=\"base\" >class</span> <span class=\"spcl\" >is</span> <span class=\"spcl\" >null</span> <br />\r\n</code>\r\n"
                + "<code class=\"html\" >\r\n"
                + " <span class=\"html\" >title</span> <span class=\"html\" >id</span> <span class=\"html\" >name</span> <br />\r\n</code>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void CsharpKeyWordsHTML_OK()
        {
            var source = "[HTML href style type HTML]\r\n"
                       + "[CODE foreach break Guid CODE]\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<code class=\"html\" >\r\n"
                + " <span class=\"html\" >href</span> <span class=\"html\" >style</span> <span class=\"html\" >type</span> <br />\r\n</code>\r\n"
                + "<code class=\"code\" >\r\n"
                + " <span class=\"flw\" >foreach</span> <span class=\"flw\" >break</span> <span class=\"type\" >Guid</span> <br />\r\n</code>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void Heading1AndHeading3_OK()
        {
            var source = "|H1 a class is [|]H2 null and void \r\n"
                       + "|H3 string readonly [|]H4 Where id name\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<h1>\r\na class is |H2 null and void </h1>\r\n"
                + "<h3>\r\nstring readonly |H4 Where id name</h3>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void Paragraph1AndParagraph3_OK()
        {
            var source = "|P1 a class is null and void \r\n"
                       + "|P3 string readonly Where id name\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p class=\"p1\" >\r\na class is null and void </p>\r\n"
                + "<p class=\"p3\" >\r\nstring readonly Where id name</p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void CiteAndBlockQuote_OK()
        {
            var source = "|CITE a class is null bardar and void \r\n"
                       + "|BQ string  bardarreadonly Where id name\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<cite class=\"cite\" >\r\na class is null bardar and void </cite>\r\n"
                + "<blockquote class=\"bq\" >\r\nstring&nbsp;&nbsp;bardarreadonly Where id name</blockquote>\r\n";
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
