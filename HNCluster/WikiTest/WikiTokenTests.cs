using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiki;

namespace WikiTest
{
    [TestClass]
    public class WikiTokenTests
    {
        [TestMethod]
        public void NewToken_WithFullName()
        {
            // Setup testing variables
            string token = "Programming";

            // Setup expected test results
            string expectedToken = "Programming";
            int expectedTF = 1;
            int expectedDF = 1;

            WikiToken newToken = new WikiToken(token);

            // Verify test results
            Assert.AreEqual(newToken.Token, expectedToken, "Error initializing WikiToken");
            Assert.AreEqual(newToken.Stemmed, null,  "Error initializing WikiToken");
            Assert.AreEqual(newToken.TF, expectedTF,  "Error initializing WikiToken");
            Assert.AreEqual(newToken.DF, expectedDF,  "Error initializing WikiToken");
        }

        [TestMethod]
        public void NewToken_WithFullName_AndStemmedName()
        {
            // Setup testing variables
            string token = "Programming";
            string stemmed = "program";

            // Setup expected test results
            string expectedToken = "Programming";
            string expectedStem = "program";
            int expectedTF = 1;
            int expectedDF = 1;

            WikiToken newToken = new WikiToken(token, stemmed);

            // Verify test results
            Assert.AreEqual(newToken.Token, expectedToken, "Error initializing WikiToken");
            Assert.AreEqual(newToken.Stemmed, expectedStem, "Error initializing WikiToken");
            Assert.AreEqual(newToken.TF, expectedTF, "Error initializing WikiToken");
            Assert.AreEqual(newToken.DF, expectedDF, "Error initializing WikiToken");
        }
    }
}
