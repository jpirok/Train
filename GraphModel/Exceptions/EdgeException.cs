using System;
using System.Runtime.Serialization;

namespace Graph.Exceptions
{
	[Serializable]
	public class EdgeException : Exception
	{
		public EdgeException()
		{
		}

		public EdgeException(string message) : base(message)
		{
		}

		public EdgeException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected EdgeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}