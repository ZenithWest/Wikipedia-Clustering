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
    public class StyleTest : HttpContextTestBase
    {
        [TestMethod]
        public void StyleUnderLineAndSupInList_OK()
        {
            var source = "# first [U:item]\r\n"
                       + "# [SUP:second] item\r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<ol>\r\n<li>first <ins>item</ins></li>\r\n"
                + "<li><sup>second</sup> item</li>\r\n"
                + "</ol>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal)
                , "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void StyleVarAndSampInTable_OK()
        {
            var source = "| bar [SAMP:header *h1] | [VAR:de _header] h2 \r\n"
                + "| ara barva | noci je [SUB:boldie] \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n<tbody>\r\n"
                + "<tr><td>bar <samp>header *h1</samp> </td>"
                + "<td><var>de _header</var> h2 </td></tr>\r\n"
                + "<tr><td>ara barva </td><td>noci je <sub>boldie</sub> </td></tr>\r\n</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void StyleStrikeURL_OK()
        {
            var source = "do not [S:[URL: click here|#home]]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>do not <del><a href=\"#home\" title=\"#home\" > click here</a></del></p>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void StyleBoldItalic_OK()
        {
            var source = "[B:bold * txt] ne [I: text _italic]";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p><b>bold * txt</b> ne <i> text _italic</i></p>\r\n";
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
