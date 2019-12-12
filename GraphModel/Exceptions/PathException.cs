using System;
using System.Runtime.Serialization;

namespace Graph.Exceptions
{
	[Serializable]
	public class PathException : Exception
	{
		public PathException()
		{
		}

		public PathException(string message) : base(message)
		{
		}

		public PathException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected PathException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}