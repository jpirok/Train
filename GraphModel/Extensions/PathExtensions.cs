using System.Collections.Generic;
using System.Linq;
using Graph.Exceptions;
using Graph.Interfaces;

namespace Graph.Extensions
{
	public static class PathExtensions
	{
		/// <summary>
		/// Finds the total weight of all edges in the given path.
		/// </summary>
		/// <param name="Nodes">List of nodes to search</param>
		/// <param name="NodePath"></param>
		/// <returns>Integer, total of all weights for the route.</returns>
		public static int TotalPathWeight(this IList<INode> Nodes, Queue<string> NodePath)
		{
			var path = Nodes.Where(n => NodePath.Contains(n.Name)).ToList();

			if (path.Count != NodePath.Count)
			{
				throw new PathException("NO SUCH ROUTE");
			}

			return path.AddEdgeWeightsInPath(NodePath);
		}

		/// <summary>
		/// Recursive, function walks all the node supplied in the nodePath and sums the weight of all the edges.
		/// </summary>
		/// <param name="nodes"></param>
		/// <param name="nodePath"></param>
		/// <returns></returns>
		public static int AddEdgeWeightsInPath(this IList<INode> nodes, Queue<string> nodePath)
		{
			if (nodePath.Count == 1) return 0;
			var nextPath = nodePath.Dequeue();
			var startNode = nodes.FirstOrDefault(n => n.Name == nextPath);
			var edge = startNode?.Edges.FirstOrDefault(e => e.Destination.Name == nodePath.FirstOrDefault());

			if (edge == null)
			{
				throw new PathException("NO SUCH ROUTE");
			}

			int prevWeight = nodes.AddEdgeWeightsInPath(nodePath);

			return edge.Weight + prevWeight;
		}
	}
}
