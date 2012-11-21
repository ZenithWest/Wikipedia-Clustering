using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiki;

namespace WikiTest
{
    [TestClass]
    public class WikiCollectionTests
    {
        [TestMethod]
        public void Test_TFIDFValues()
        {
            // Set up test variables
            WikiCollection wikiCollection = new WikiCollection();
            wikiCollection.ParseXML(@"WikiTestData.xml");

            wikiCollection.ExtractTokens();

            // Verify test results
            Assert.AreNotEqual(wikiCollection, null, "Error initializing WikiCollection.");
            Assert.AreNotEqual(wikiCollection.wikiPages.Count, 0, "Error initializing WikiCollection.");
            Assert.AreNotEqual(wikiCollection.inverseTokens.Keys.Count, 0, "Error initializing WikiCollection.");
        }
    }
}
