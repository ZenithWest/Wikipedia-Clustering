using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiki;

namespace WikiTest
{
    [TestClass]
    public class WikiCollectionTests
    {
        WikiCollection wikiCollection;

        [TestInitialize]
        public void Initialize()
        {
            // Set up test variables
            wikiCollection = new WikiCollection();
            wikiCollection.ParseXML(@"WikiTestData.xml");

            wikiCollection.ExtractTokens();
        }

        [TestMethod]
        public void Test_TFIDFValues()
        {
            // Set up test variables
            //WikiCollection wikiCollection = new WikiCollection();
           // wikiCollection.ParseXML(@"WikiTestData.xml");

           // wikiCollection.ExtractTokens();

            // Verify test results
            Assert.AreNotEqual(wikiCollection, null, "Error initializing WikiCollection.");
            Assert.AreNotEqual(wikiCollection.wikiPages.Count, 0, "Error initializing WikiCollection.");
            Assert.AreNotEqual(wikiCollection.inverseTokens.Keys.Count, 0, "Error initializing WikiCollection.");
            
        }

        [TestMethod]
        public void Test_Doc1Values()
        {
            // Set up test variables
            //WikiCollection wikiCollection = new WikiCollection();
            //wikiCollection.ParseXML(@"WikiTestData.xml");
            WikiPage page = wikiCollection.wikiPages[0];
            //wikiCollection.ExtractTokens();

            // Verify test results - testing tf values
            Assert.AreEqual(page.TF_IDF_Vector["the"].TF, 2, .01, "'the' TF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["brown"].TF, 1, .01, "'brown' TF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["cow"].TF, 1, .01, "'cow' TF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["jump"].TF, 1, .01, "'jump' TF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["over"].TF, 1, .01, "'over' TF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["moon"].TF, 1, .01, "'moon' TF correct for doc 1");


            // Verify test results - testing df values
            Assert.AreEqual(page.TF_IDF_Vector["the"].DF, 2, .01, "'the' DF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["brown"].DF, 1, .01, "'brown' DF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["cow"].DF, 2, .01, "'cow' DF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["jump"].DF, 1, .01, "'jump' DF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["over"].DF, 1, .01, "'over' DF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["moon"].DF, 1, .01, "'moon' DF correct for doc 1");

            // Verify test results - testing tf-idf values
            Assert.AreEqual(page.TF_IDF_Vector["the"].TF_IDF, .4364, .01, "'the' TF-IDF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["brown"].TF_IDF, .4364, .01, "'brown' TF-IDF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["cow"].TF_IDF, .2182, .01, "'cow' TF-IDF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["jump"].TF_IDF, .4364, .01, "'jump' TF-IDF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["over"].TF_IDF, .4364, .01, "'over' TF-IDF correct for doc 1");
            Assert.AreEqual(page.TF_IDF_Vector["moon"].TF_IDF, .4364, .01, "'moon' TF-IDF correct for doc 1");

        }
    }
}
