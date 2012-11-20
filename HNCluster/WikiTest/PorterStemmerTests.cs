using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PorterStemmerAlgorithm;

namespace WikiTest
{
    [TestClass]
    public class PorterStemmerTests
    {
        [TestMethod]
        public void Test_Stemmer()
        {
            // Setup testing variables
            string token = "Programming";

            // Setup expected test results
            string expectedStem = "Program";

            PorterStemmer stemmer = new PorterStemmer();
            string actualStem = stemmer.stemTerm(token);

            // Verify test results
            Assert.AreEqual(actualStem, expectedStem, "Porter Stemmer returned incorrect stem");
        }
    }
}
