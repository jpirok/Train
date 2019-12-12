using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.Interfaces
{
	public interface INode
	{
		string Name { get; }
		IList<IEdge> Edges { get; }
	}
}
