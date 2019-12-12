using System.Collections.Generic;
using System.Linq;
using Graph.Exceptions;
using Graph.Interfaces;
using Graph.Model;

namespace Graph.Extensions
{
	public static class NodeExtensions
	{
		/// <summary>
		/// Adds a new edge in the format of AB5.
		/// </summary>
		/// <param name="Nodes">List of existing nodes to add an edge to.</param>
		/// <param name="EdgeDefinition">Edge definition in the form of AB5 where 
		/// A is the start node, 
		/// B is the destination node, 
		/// and 5 is the edge weight.</param>
		/// <exception cref="EdgeException">Invalid Route Input</exception>
		/// <exception cref="EdgeException">Third character must be a number</exception>
		public static void AddEdge(this IList<INode> Nodes, string EdgeDefinition)
		{
			if (EdgeDefinition?.Length < 3)
				throw new EdgeException("Invalid Route Input");

			if (!int.TryParse(EdgeDefinition.Substring(2, EdgeDefinition.Length - 2), out int weight))
				throw new EdgeException("Third character must be a number.");

			string startNodeName = EdgeDefinition[0].ToString();
			string destinationNodeName = EdgeDefinition[1].ToString();

			var startNode = Nodes.FindOrCreateNode(startNodeName);
			var destinationNode = Nodes.FindOrCreateNode(destinationNodeName);

			startNode.Edges.Add(Edge.Create(weight, destinationNode));
		}

		/// <summary>
		/// Returns an existing node with the given name or 
		/// a new node with the given name if one is not present.
		/// </summary>
		/// <param name="Nodes">List of nodes to search</param>
		/// <param name="NodeName">Name of the node to find or Create.</param>
		/// <returns></returns>
		public static INode FindOrCreateNode(this IList<INode> Nodes, string NodeName)
		{
			var node = Nodes.FirstOrDefault(n => n.Name == NodeName);

			if (node == null)
			{
				node = Node.Create(NodeName);
				Nodes.Add(node);
			}

			return node;
		}
	}
}
