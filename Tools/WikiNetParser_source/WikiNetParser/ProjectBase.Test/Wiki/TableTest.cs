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
    public class TableTest : TestBase
    {
        [TestMethod]
        public void TableWithEOF_OK()
        {
            var source = "|| heading1 || heading2 \r\n"
                + "| ara [RED:barva] | |H1 not a heading";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n"
                + "<thead><tr><td>heading1 </td><td>heading2 </td></tr></thead>\r\n"
                + "<tbody>\r\n<tr><td>ara <span style=\"color:Red;\" >barva</span> </td>"
                + "<td>|H1 not a heading</td></tr>\r\n</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void TableWithNotAHeading_OK()
        {
            var source = "|| heading1 || heading2 \r\n"
                + "| ara [RED:barva] | |H1 not a heading \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n"
                + "<thead><tr><td>heading1 </td><td>heading2 </td></tr></thead>\r\n"
                + "<tbody>\r\n<tr><td>ara <span style=\"color:Red;\" >barva</span> </td>"
                + "<td>|H1 not a heading </td></tr>\r\n</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void TableWithLongUrl_OK()
        {
            var source = "|| heading1 || heading2 \r\n"
                + "| ara [NAME:barva] | noci je [URL:click here|http://catarsa.com?my=1&your=2] \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n"
                + "<thead><tr><td>heading1 </td><td>heading2 </td></tr></thead>\r\n"
                + "<tbody>\r\n<tr><td>ara <a name=\"barva\" ></a> </td>"
                + "<td>noci je <a href=\"http://catarsa.com?my=1&amp;your=2\" title=\"http://catarsa.com?my=1&amp;your=2\" >click here</a> </td></tr>\r\n"
                + "</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void TableWithUrl_OK()
        {
            var source = "|| heading1 || heading2 \r\n"
                + "| ara [NAME:barva] | noci je [URL:http://catarsa.com] \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n"
                + "<thead><tr><td>heading1 </td><td>heading2 </td></tr></thead>\r\n"
                + "<tbody>\r\n<tr><td>ara <a name=\"barva\" ></a> </td>"
                + "<td>noci je <a href=\"http://catarsa.com\" title=\"http://catarsa.com\" >http://catarsa.com</a> </td></tr>\r\n"
                + "</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void TableWithBoldText_OK()
        {
            var source = "|| heading1 || heading2 \r\n"
                + "| ara barva | noci je *boldie* \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n"
                + "<thead><tr><td>heading1 </td><td>heading2 </td></tr></thead>\r\n"
                + "<tbody>\r\n<tr><td>ara barva </td><td>noci je <b>boldie</b> </td></tr>\r\n</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void TableWith2Head_OK()
        {
            var source = "|| heading1 || heading2 \r\n"
                + "|| subheading1 | subheading2 \r\n"
                + "| bar header h1 || de header h2 \r\n"
                + "| ara barva | noci je [B:boldie] \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n"
                + "<thead><tr><td>heading1 </td><td>heading2 </td></tr></thead>\r\n"
                + "<thead><tr><td>subheading1 </td><td>subheading2 </td></tr></thead>\r\n"
                + "<tbody>\r\n<tr><td>bar header h1 </td><td>de header h2 </td></tr>\r\n"
                + "<tr><td>ara barva </td><td>noci je <b>boldie</b> </td></tr>\r\n</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }
        [TestMethod]
        public void TableWithHeadAndDoubledVLINE_OK()
        {
            var source = "|| heading1 || heading2 \r\n"
                + "| bar header h1 || de header h2 \r\n"
                + "| ara barva | noci je [B:boldie] \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n"
                + "<thead><tr><td>heading1 </td><td>heading2 </td></tr></thead>\r\n"
                + "<tbody>\r\n<tr><td>bar header h1 </td><td>de header h2 </td></tr>\r\n"
                + "<tr><td>ara barva </td><td>noci je <b>boldie</b> </td></tr>\r\n</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void TableWithHead_OK()
        {
            var source = "|| heading1 | heading2 \r\n"
                + "| bar header h1 | de header h2 \r\n"
                + "| ara barva | noci je [B:boldie] \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n"
                + "<thead><tr><td>heading1 </td><td>heading2 </td></tr></thead>\r\n"
                + "<tbody>\r\n<tr><td>bar header h1 </td><td>de header h2 </td></tr>\r\n"
                + "<tr><td>ara barva </td><td>noci je <b>boldie</b> </td></tr>\r\n</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void Table_OK()
        {
            var source = "| bar header h1 | de header h2 \r\n"
                + "| ara barva | noci je [B:boldie] \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<table>\r\n<tbody>\r\n"
                + "<tr><td>bar header h1 </td><td>de header h2 </td></tr>\r\n"
                + "<tr><td>ara barva </td><td>noci je <b>boldie</b> </td></tr>\r\n"
                + "</tbody></table>\r\n";
            Assert.IsTrue(result.Equals(expected, StringComparison.Ordinal), "RESULT:\r\n" + result + "\r\n EXPECTED:\r\n" + expected);
        }

        [TestMethod]
        public void NOTTable_OK()
        {
            var source = "notTable | header1 | header2 \r\n";
            var result = new WikiConverter().ConvertToHtml(source);
            var expected = "<p>notTable | header1 | header2 </p>\r\n";
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
