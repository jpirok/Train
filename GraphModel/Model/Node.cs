using System.Collections.Generic;
using Graph.Interfaces;

namespace Graph.Model
{
	public class Node : INode
	{
		public IList<IEdge> Edges { get; } = new List<IEdge>();

		public string Name { get; }

		private Node(string Name)
		{
			this.Name = Name;
		}

		public static INode Create(string Name)
		{
			return new Node(Name);
		}
	}
}
