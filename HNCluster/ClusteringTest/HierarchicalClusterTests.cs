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
        }

        [TestMethod]
        public void Test_ClusterInitialization()
        {
            // Initialize clusters
            hierarchicalCluster.initializeClusters();

            // Expected results
            int numberOfClusters = hierarchicalCluster.clusters.Count;
            int expectedNumClusters = 4;

            Assert.AreEqual(numberOfClusters, expectedNumClusters, "Error during hierarchical clustering.");
        }

        [TestMethod]
        public void Test_ClusteringAlgorithm()
        {
            // Kick off Clustering algorithm
            hierarchicalCluster.Cluster();

            int numberOfClusters = hierarchicalCluster.clusters.Count;
            int expectedNumClusters = 1;

            Assert.AreEqual(numberOfClusters, expectedNumClusters, "Error during hierarchical clustering.");
        }
    }
}
