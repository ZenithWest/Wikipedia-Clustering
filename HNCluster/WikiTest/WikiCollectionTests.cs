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

            int i = 0;



        }
    }
}
