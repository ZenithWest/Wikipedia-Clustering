using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PorterStemmerAlgorithm;

namespace WikiTest
{
    [TestClass]
    public class PorterStemmerTests
    {
        [TestMethod]
        public void Test_Stemmer1()
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

        [TestMethod]
        public void Test_Stemmer2()
        {
            // Setup testing variables
            string token = "Winning";

            // Setup expected test results
            string expectedStem = "Win";

            PorterStemmer stemmer = new PorterStemmer();
            string actualStem = stemmer.stemTerm(token);

            // Verify test results
            Assert.AreEqual(actualStem, expectedStem, "Porter Stemmer returned incorrect stem");
        }

        [TestMethod]
        public void Test_Stemmer3()
        {
            // Setup testing variables
            string token = "Gaining";

            // Setup expected test results
            string expectedStem = "Gain";

            PorterStemmer stemmer = new PorterStemmer();
            string actualStem = stemmer.stemTerm(token);

            // Verify test results
            Assert.AreEqual(actualStem, expectedStem, "Porter Stemmer returned incorrect stem");
        }

        [TestMethod]
        public void Test_Stemmer4()
        {
            // Setup testing variables
            string token = "Soars";

            // Setup expected test results
            string expectedStem = "Soar";

            PorterStemmer stemmer = new PorterStemmer();
            string actualStem = stemmer.stemTerm(token);

            // Verify test results
            Assert.AreEqual(actualStem, expectedStem, "Porter Stemmer returned incorrect stem");
        }

        [TestMethod]
        public void Test_Stemmer5()
        {
            // Setup testing variables
            string token = "Feeling";

            // Setup expected test results
            string expectedStem = "Feel";

            PorterStemmer stemmer = new PorterStemmer();
            string actualStem = stemmer.stemTerm(token);

            // Verify test results
            Assert.AreEqual(actualStem, expectedStem, "Porter Stemmer returned incorrect stem");
        }
    }
}
