using Graph.Extensions;
using Graph.Exceptions;
using Graph.Interfaces;
using Graph.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraphTests
{
	[TestClass]
	public class NodeTests
	{
		[TestMethod]
		public void TestNodeCreated()
		{
			// Arrange
			var nodes = new List<INode>();

			// Act
			var foundNode = nodes.FindOrCreateNode("A");

			// Assert 
			Assert.IsNotNull(foundNode);
			Assert.IsTrue(foundNode.Name == "A");
		}

		[TestMethod]
		public void TestNodeFound()
		{
			// Arrange
			var nodeB = Node.Create("B");
			var nodeA = Node.Create("A");
			nodeA.Edges.Add(Edge.Create(5, nodeB));

			var nodes = new List<INode>
			{
				nodeB,
				nodeA,
				Node.Create("C")
			};

			// Act
			var foundNode = nodes.FindOrCreateNode("A");

			// Assert 
			Assert.IsNotNull(foundNode);
			Assert.IsTrue(foundNode.Name == "A");
			// If the node was just created, there would be no edges.
			Assert.IsTrue(foundNode.Edges.Count == 1);
		}

		[TestMethod]
		public void TestNodeEdgeCreated()
		{
			// Arrange
			var nodes = new List<INode>();

			// Act 
			nodes.AddEdge("AB4");
			var nodeA = nodes.FirstOrDefault(n => n.Name == "A");
			var nodeB = nodes.FirstOrDefault(n => n.Name == "B");
			var nodeEdgeAB = nodeA.Edges.FirstOrDefault();

			// Assert
			Assert.IsTrue(nodes.Count == 2);
			Assert.IsNotNull(nodeA);
			Assert.IsNotNull(nodeB);
			Assert.IsTrue(nodeA.Edges.Count == 1);

			Assert.IsTrue(nodeEdgeAB.Destination.Name == "B");
			Assert.IsTrue(nodeEdgeAB.Weight == 4);
		}

		[TestMethod]
		public void CheckCanUseMoreThanOneDigitForWeight()
		{
			// Arrange
			var nodes = new List<INode>();

			// Act 
			nodes.AddEdge("AB44");
			var nodeA = nodes.FirstOrDefault(n => n.Name == "A");

			// Assert
			Assert.AreEqual(nodeA.Edges.First().Weight, 44);
		}

		[TestMethod]
		[ExpectedException(typeof(EdgeException), "EdgeException not thrown.")]
		public void TestExceptionThrownOnBadInput()
		{
			// Arrange
			var nodes = new List<INode>();

			// Act
			nodes.AddEdge("AB");
		}

		[TestMethod]
		[ExpectedException(typeof(EdgeException), "EdgeException not thrown.")]
		public void TestExceptionThrownOnBadWeight()
		{
			// Arrange
			var nodes = new List<INode>();

			// Act
			nodes.AddEdge("ABA");
		}
	}
}
