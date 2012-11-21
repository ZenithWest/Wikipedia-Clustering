using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clustering;
using Wiki;

namespace ClusteringTest
{
    [TestClass]
    public class HierarchicalClusterTests
    {

        HierarchicalCluster hierarchicalCluster;
        WikiCollection wikiCollection;


        [TestInitialize]
        public void Initialize()
        {
            // Set up wikiCollection test variable
            wikiCollection = new WikiCollection();
            wikiCollection.ParseXML(@"WikiTestData.xml");
            wikiCollection.ExtractTokens();

            // Set up hierarchicalCluster test variable
            hierarchicalCluster = new HierarchicalCluster(wikiCollection);
            hierarchicalCluster.initializeClusters();
            hierarchicalCluster.Cluster();
        }

        [TestMethod]
        public void HACTestMethod1()
        {

        }
    }
}
