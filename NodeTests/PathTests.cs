using Graph.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Graph.Extensions;
using Graph.Exceptions;

namespace GraphTests
{
	[TestClass]
	public class PathTests
	{
		private readonly List<INode> trainGraph = new List<INode>();
		private readonly List<string> routeList = new List<string> {"AB5","BC4","CD8","DC8","DE6","AD5","CE2","EB3","AE7"};

		[TestInitialize]
		public void PathTestInitialization()
		{
			routeList.ForEach(edge => trainGraph.AddEdge(edge));
		}

		[TestMethod]
		public void VerifyTotalRouteLengthIsNine()
		{
			// Arrange
			Queue<string> nodePath = new Queue<string>(new List<string> { "A", "B", "C" });
					 
			// Act
			var total = trainGraph.TotalPathWeight(nodePath);

			// Assert
			Assert.AreEqual(total, 9);
		}

		[TestMethod]
		public void VerifyTotalRouteLengthIsFive()
		{
			// Arrange
			Queue<string> nodePath = new Queue<string>(new List<string> { "A", "D" });

			// Act
			var total = trainGraph.TotalPathWeight(nodePath);

			// Assert
			Assert.AreEqual(total, 5);
		}

		[TestMethod]
		public void VerifyTotalRouteLengthIsThirteen()
		{
			// Arrange
			Queue<string> nodePath = new Queue<string>(new List<string> { "A", "D", "C" });

			// Act
			var total = trainGraph.TotalPathWeight(nodePath);

			// Assert
			Assert.AreEqual(total, 13);
		}

		[TestMethod]
		public void VerifyTotalRouteLengthIsTwentyTwo()
		{
			// Arrange
			Queue<string> nodePath = new Queue<string>(new List<string> { "A", "E", "B", "C", "D" });

			// Act
			var total = trainGraph.TotalPathWeight(nodePath);

			// Assert
			Assert.AreEqual(total, 22);
		}

		[ExpectedException(typeof(PathException),"Did not fail for no path")]
		[TestMethod]
		public void VerifyExceptionIsThrownWhenThereIsNoRoute()
		{
			// Arrange
			Queue<string> nodePath = new Queue<string>(new List<string> { "A", "E", "D" });

			// Act
			trainGraph.TotalPathWeight(nodePath);
		}
	}
}
