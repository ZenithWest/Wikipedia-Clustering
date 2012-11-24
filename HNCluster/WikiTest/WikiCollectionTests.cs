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
        public void Test_Doc1_TFIDF()
        {
            // Set up test variables
            //WikiCollection wikiCollection = new WikiCollection();
            //wikiCollection.ParseXML(@"WikiTestData.xml");
            WikiPage page = wikiCollection.wikiPages[0];
            //wikiCollection.ExtractTokens();

            // Verify test results - testing tf values
				Assert.AreEqual(page.tf_IDF_Vec["the"].TF, 2, .01, "'the' TF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["brown"].TF, 1, .01, "'brown' TF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["cow"].TF, 1, .01, "'cow' TF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["jump"].TF, 1, .01, "'jump' TF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["over"].TF, 1, .01, "'over' TF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["moon"].TF, 1, .01, "'moon' TF incorrect for doc 1");


            // Verify test results - testing df values
				Assert.AreEqual(page.tf_IDF_Vec["the"].DF, 2, .01, "'the' DF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["brown"].DF, 1, .01, "'brown' DF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["cow"].DF, 2, .01, "'cow' DF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["jump"].DF, 1, .01, "'jump' DF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["over"].DF, 1, .01, "'over' DF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["moon"].DF, 1, .01, "'moon' DF incorrect for doc 1");

            // Verify test results - testing tf-idf values
				Assert.AreEqual(page.tf_IDF_Vec["the"].TF_IDF, .4364, .01, "'the' TF-IDF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["brown"].TF_IDF, .4364, .01, "'brown' TF-IDF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["cow"].TF_IDF, .2182, .01, "'cow' TF-IDF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["jump"].TF_IDF, .4364, .01, "'jump' TF-IDF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["over"].TF_IDF, .4364, .01, "'over' TF-IDF incorrect for doc 1");
				Assert.AreEqual(page.tf_IDF_Vec["moon"].TF_IDF, .4364, .01, "'moon' TF-IDF incorrect for doc 1");

        }

        [TestMethod]
        public void Test_Doc2_TFIDF()
        {
            // Set up test variables
            //WikiCollection wikiCollection = new WikiCollection();
            //wikiCollection.ParseXML(@"WikiTestData.xml");
            WikiPage page = wikiCollection.wikiPages[1];
            //wikiCollection.ExtractTokens();

            // Verify test results - testing tf values
				Assert.AreEqual(page.tf_IDF_Vec["milk"].TF, 1, .01, "'milk' TF incorrect for doc 2");
				Assert.AreEqual(page.tf_IDF_Vec["is"].TF, 1, .01, "'is' TF incorrect for doc 2");
				Assert.AreEqual(page.tf_IDF_Vec["good"].TF, 1, .01, "'good' TF incorrect for doc 2");


            // Verify test results - testing df values
				Assert.AreEqual(page.tf_IDF_Vec["milk"].DF, 1, .01, "'milk' DF incorrect for doc 2");
				Assert.AreEqual(page.tf_IDF_Vec["is"].DF, 2, .01, "'is' DF incorrect for doc 2");
				Assert.AreEqual(page.tf_IDF_Vec["good"].DF, 1, .01, "'good' DF incorrect for doc 2");

            // Verify test results - testing tf-idf values
				Assert.AreEqual(page.tf_IDF_Vec["milk"].TF_IDF, .6667, .01, "'milk' TF-IDF incorrect for doc 2");
				Assert.AreEqual(page.tf_IDF_Vec["is"].TF_IDF, .3333, .01, "'is' TF-IDF incorrect for doc 2");
				Assert.AreEqual(page.tf_IDF_Vec["good"].TF_IDF, .6667, .01, "'good' TF-IDF incorrect for doc 2");

        }

        [TestMethod]
        public void Test_Doc3_TFIDF()
        {
            // Set up test variables
            //WikiCollection wikiCollection = new WikiCollection();
            //wikiCollection.ParseXML(@"WikiTestData.xml");
            WikiPage page = wikiCollection.wikiPages[2];
            //wikiCollection.ExtractTokens();

            // Verify test results - testing tf values
				Assert.AreEqual(page.tf_IDF_Vec["i"].TF, 1, .01, "'i' TF correct for doc 3");
				Assert.AreEqual(page.tf_IDF_Vec["am"].TF, 1, .01, "'am' TF correct for doc 3");
				Assert.AreEqual(page.tf_IDF_Vec["veri"].TF, 1, .01, "'veri' TF correct for doc 3");
				Assert.AreEqual(page.tf_IDF_Vec["tire"].TF, 1, .01, "'tire' TF correct for doc 3");

            // Verify test results - testing df values
				Assert.AreEqual(page.tf_IDF_Vec["i"].DF, 1, .01, "'i' DF correct for doc 3");
				Assert.AreEqual(page.tf_IDF_Vec["am"].DF, 1, .01, "'am' DF correct for doc 3");
				Assert.AreEqual(page.tf_IDF_Vec["veri"].DF, 1, .01, "'veri' DF correct for doc 3");
				Assert.AreEqual(page.tf_IDF_Vec["tire"].DF, 2, .01, "'tire' DF correct for doc 3");

            // Verify test results - testing tf-idf values
				Assert.AreEqual(page.tf_IDF_Vec["i"].TF_IDF, .5547, .01, "'i' TF-IDF correct for doc 3");
				Assert.AreEqual(page.tf_IDF_Vec["am"].TF_IDF, .5547, .01, "'am' TF-IDF correct for doc 3");
				Assert.AreEqual(page.tf_IDF_Vec["veri"].TF_IDF, .5547, .01, "'veri' TF-IDF correct for doc 3");
				Assert.AreEqual(page.tf_IDF_Vec["tire"].TF_IDF, .2774, .01, "'tire' TF-IDF correct for doc 3");

        }

        [TestMethod]
        public void Test_Doc4_TFIDF()
        {
            // Set up test variables
            //WikiCollection wikiCollection = new WikiCollection();
            //wikiCollection.ParseXML(@"WikiTestData.xml");
            WikiPage page = wikiCollection.wikiPages[3];
            //wikiCollection.ExtractTokens();

            // Verify test results - testing tf values
				Assert.AreEqual(page.tf_IDF_Vec["the"].TF, 1, .01, "'the' TF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["cow"].TF, 1, .01, "'cow' TF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["is"].TF, 1, .01, "'is' TF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["white"].TF, 1, .01, "'white' TF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["and"].TF, 1, .01, "'and' TF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["tire"].TF, 1, .01, "'tire' TF correct for doc 4");


            // Verify test results - testing df values
				Assert.AreEqual(page.tf_IDF_Vec["the"].DF, 2, .01, "'the' DF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["cow"].DF, 2, .01, "'cow' DF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["is"].DF, 2, .01, "'is' DF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["white"].DF, 1, .01, "'white' DF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["and"].DF, 1, .01, "'and' DF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["tire"].DF, 2, .01, "'tire' DF correct for doc 4");

            // Verify test results - testing tf-idf values
				Assert.AreEqual(page.tf_IDF_Vec["the"].TF_IDF, .2887, .01, "'the' TF-IDF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["cow"].TF_IDF, .2887, .01, "'cow' TF-IDF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["is"].TF_IDF, .2887, .01, "'is' TF-IDF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["white"].TF_IDF, .5774, .01, "'white' TF-IDF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["and"].TF_IDF, .5774, .01, "'and' TF-IDF correct for doc 4");
				Assert.AreEqual(page.tf_IDF_Vec["tire"].TF_IDF, .2887, .01, "'tire' TF-IDF correct for doc 4");

        }
    }
}
