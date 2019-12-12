using Graph.Interfaces;

namespace Graph.Model
{
	public class Edge : IEdge
	{
		public int Weight { get; } = 0;
		public INode Destination { get; }

		private Edge(int Weight, INode Destination)
		{
			this.Weight = Weight;
			this.Destination = Destination;
		}

		public static IEdge Create(int Weight, INode Destination)
		{
			return new Edge(Weight, Destination);
		}
	}
}
