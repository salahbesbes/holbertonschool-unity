using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
	public int x;
	public int y;
	public bool obsacle = false;
	public bool visited = false;
	public float h = float.PositiveInfinity;
	public float g = float.PositiveInfinity;
	public List<Node> neighbours;
	public Node parent = null;
	public string icon = "*";
	public List<Node> path;

	public Node(int x, int y)
	{
		this.x = x;
		this.y = y;
		neighbours = new List<Node>();
		path = new List<Node>();
	}

	public void resetNode()
	{
		visited = false;
		h = float.PositiveInfinity;
		g = float.PositiveInfinity;

		parent = null;
		icon = "*";
		path = new List<Node>();
	}
}

/// <summary>
/// when ever we create an instance of this class a new Graph Grid is created every node has its 4
/// sides and 4 diagonals nodes as neighbor in a list
/// </summary>
public class PathFinding
{
	public int mapSizeX = 5, mapSizeY = 5;
	public int[,] tiles;
	public Node[,] graph;
	public Node start;
	public Node end;

	public PathFinding(int sizeX, int sizeY, Node selectedNode, Node Destination)
	{
		mapSizeX = sizeX;
		mapSizeY = sizeY;

		end = Destination;
		end.icon = "E";

		start = selectedNode;
		start.parent = null;
		start.icon = "S";
		start.g = 0.0f;
		// CalcH need destination(end) variable
		start.h = CalcH(selectedNode, end);

		// create graph of Nodes (Grid)
		generatePathFindingGraph();
	}

	private void generatePathFindingGraph()
	{
		graph = new Node[mapSizeX, mapSizeY];

		//initialize graph
		for (int x = 0; x < mapSizeX; x++)
		{
			for (int y = 0; y < mapSizeY; y++)
			{
				graph[x, y] = new Node(x, y);
				if (x == 2 && y < 10 || x == 3 && y > 10 || x == 5 && y > 15 || x >= 5 && x < 11 && y == 15 || (x == 10 && y >= 15 && y < 20) || x == 20 && y > 0)
				{
					graph[x, y].obsacle = true;
					graph[x, y].icon = "@";
				}
			}
		}

		// after we create a new Grid with new Nodes(default) we Override the start and the
		// end node with the right information
		graph[start.x, start.y] = start;
		graph[end.x, end.y] = end;

		//graph[1, mapSizeY - 1].obsacle = false;
		//graph[1, mapSizeY - 1].icon = "*";

		//graph[mapSizeX - 1, mapSizeY - 1].parent = graph[mapSizeX - 1, mapSizeY - 2];
		//graph[mapSizeX - 1, mapSizeY - 2].parent = graph[mapSizeX - 1, mapSizeY - 3];
		//graph[mapSizeX - 1, mapSizeY - 3].parent = graph[mapSizeX - 1, mapSizeY - 4];
		//end = graph[mapSizeX - 1, mapSizeY - 1];
		//end.icon = "E";

		//calculate neighbours
		for (int x = 0; x < mapSizeX; x++)
		{
			for (int y = 0; y < mapSizeY; y++)
			{
				// sides
				if (x > 0)
				{
					graph[x, y].neighbours.Add(graph[x - 1, y]);
				}
				if (x < mapSizeX - 1)
				{
					graph[x, y].neighbours.Add(graph[x + 1, y]);
				}
				if (y > 0)
				{
					graph[x, y].neighbours.Add(graph[x, y - 1]);
				}
				if (y < mapSizeY - 1)
				{
					graph[x, y].neighbours.Add(graph[x, y + 1]);
				}

				// diagonals
				if (x > 0 && y > 0)
				{
					graph[x, y].neighbours.Add(graph[x - 1, y - 1]);
				}
				if (x < mapSizeY - 1 && y < mapSizeY - 1)
				{
					graph[x, y].neighbours.Add(graph[x + 1, y + 1]);
				}

				if (x > 0 && y < mapSizeY - 1)
				{
					graph[x, y].neighbours.Add(graph[x - 1, y + 1]);
				}
				if (x < mapSizeY - 1 && y > 0)
				{
					graph[x, y].neighbours.Add(graph[x + 1, y - 1]);
				}
			}
		}
	}

	private static void getThePaht(Node startNode, Node current)
	{
		//current.icon = "o";
		Node tmp = current;
		startNode.path = new List<Node>();
		while (tmp.parent != null)
		{
			current.path.Add(tmp);
			startNode.path.Add(tmp);

			tmp = tmp.parent;
			tmp.icon = ".";
		}
		startNode.icon = "S";
		//startNode.path.Add(startNode);

		//current.path.Add(start);
		//foreach (var item in current.path)
		//{
		//	//item.icon = ".";
		//	start.path.Add(item);
		//}
		startNode.path.Reverse();
	}

	private void printGrid(Node current)
	{
		//getThePaht(current);
		Console.Clear();
		for (int x = 0; x < mapSizeX; x++)
		{
			for (int y = 0; y < mapSizeY; y++)
			{
				Console.Write(graph[x, y].icon + " ");
			}
			Console.Write(Environment.NewLine);
		}
	}

	public static int CalcG(Node a, Node b)
	{
		return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
	}

	public static int CalcH(Node a, Node e)
	{
		return Math.Abs(a.x - e.x) + Math.Abs(a.y - e.y);
	}

	/// <summary>
	/// "using Graph dataType" grid of Nodes is needed to find the closest path between the
	/// start node to the destination node
	/// </summary>
	/// <param name="startNode"> selected Node </param>
	/// <param name="destination"> destination to reach </param>
	// link to visit https://www.youtube.com/watch?v=icZj67PTFhc
	public static bool AStarAlgo(Node startNode, Node destination)
	{
		List<Node> QueueNotTested = new List<Node>();
		QueueNotTested.Insert(0, startNode);
		while (QueueNotTested.Count >= 0)
		{
			// sort the list in acending order by the heuretic value
			QueueNotTested = QueueNotTested.OrderBy(item => item.h).ToList();

			//we can loop throw an empty list in that case we are sure we didnt
			//find any path
			if (QueueNotTested.Count == 0)
			{
				Console.WriteLine("cant find path");
				return false;
			}

			// select the first node of the list which have the less value of the
			// heuritic value
			Node current = QueueNotTested[0];
			// make it visited
			current.visited = true;
			//remove it from the rhe list
			QueueNotTested.RemoveAt(0);

			// if the current == end we find the en point
			if (current == destination)
			{
				Console.WriteLine("Found End :) ");
				//printGrid(current);
				getThePaht(startNode, current);
				break;
			}
			//printGrid(current);

			if (current.obsacle == true) continue;

			for (int i = 0; i < current.neighbours.Count; i++)
			{
				// foreach neighbor which is not an obstacle
				Node neighbor = current.neighbours[i];
				if (neighbor.obsacle == true) continue;
				else
				{
					// calculate the g val (toWard the parent)
					float neighborG = CalcG(current, neighbor);
					// calculate the new possible g value (toWard the start
					// node)
					float tempG = current.g + neighborG;
					// by default the neighbor.g is positif Infinit but after
					// setting g val to a neighbor we can revisit this node and
					// at this time the g val is not infinit so we wan do the
					// comparison

					if (tempG < neighbor.g)
					{
						neighbor.parent = current;
						neighbor.g = tempG;
						neighbor.h = neighbor.g + CalcH(neighbor, destination);
						// update the list we are worrking on
						QueueNotTested.Add(neighbor);
					}
				}
			}
		}
		return true;
	}
}