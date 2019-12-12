using Graph.Exceptions;
using Graph.Extensions;
using Graph.Interfaces;
using System;
using System.Collections.Generic;

namespace Train
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please enter a comma seperated list of routes in the form AB5,BC3:");
			Console.Write("Enter Routes: ");

			var coordinates = Console.ReadLine();

			List<INode> nodes = new List<INode>();

			try
			{
				var routes = coordinates.Split(',');
				foreach (string route in routes)
				{
					nodes.AddEdge(route);
				}
			}
			catch (EdgeException ee)
			{
				Console.WriteLine(ee.Message);
				Console.WriteLine("Processing Terminated");
				return;
			}

			string output1 = string.Empty;
			string output2 = string.Empty;
			string output3 = string.Empty;
			string output4 = string.Empty;
			string output5 = string.Empty;

			try
			{
				output1 = nodes.AddEdgeWeightsInPath(new Queue<string>(new string[] { "A", "B", "C" })).ToString();
			}
			catch (PathException pe)
			{
				output1 = pe.Message;
			}

			try
			{
				output2 = nodes.AddEdgeWeightsInPath(new Queue<string>(new string[] { "A", "D" })).ToString();
			}
			catch (PathException pe)
			{
				output2 = pe.Message;
			}

			try
			{
				output3 = nodes.AddEdgeWeightsInPath(new Queue<string>(new string[] { "A", "D", "C" })).ToString();
			}
			catch (PathException pe)
			{
				output3 = pe.Message;
			}

			try
			{
				output4 = nodes.AddEdgeWeightsInPath(new Queue<string>(new string[] { "A", "E", "B", "C", "D" })).ToString();
			}
			catch (PathException pe)
			{
				output4 = pe.Message;
			}

			try
			{
				output5 = nodes.AddEdgeWeightsInPath(new Queue<string>(new string[] { "A", "E", "D" })).ToString();
			}
			catch (PathException pe)
			{
				output5 = pe.Message;
			}

			Console.WriteLine(string.Concat("Output 1: ", output1));
			Console.WriteLine(string.Concat("Output 2: ", output2));
			Console.WriteLine(string.Concat("Output 3: ", output3));
			Console.WriteLine(string.Concat("Output 4: ", output4));
			Console.WriteLine(string.Concat("Output 5: ", output5));
			Console.WriteLine(string.Concat("Output 6: ", ""));
			Console.WriteLine(string.Concat("Output 7: ", ""));
			Console.WriteLine(string.Concat("Output 8: ", ""));
			Console.WriteLine(string.Concat("Output 9: ", ""));
			Console.WriteLine(string.Concat("Output 10: ", ""));
		}
	}
}
