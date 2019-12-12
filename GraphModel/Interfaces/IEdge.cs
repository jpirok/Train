using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.Interfaces
{
	public interface IEdge
	{
		int Weight { get; }
		INode Destination { get; }
	}
}
