using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class Node
//{
//	public List<Node> neighbours;
//	public int x;
//	public int y;

// //Edges public Node() { neighbours = new List<Node>(); }

//	public float DistanceTo(Node n)
//	{
//		return Vector2.Distance(new Vector2(x, y), new Vector2(n.x, n.y));
//	}
//}

[System.Serializable]
public class Tile
{
	public string name;
	public GameObject tileVisualPrefab;
	public GameObject unitOnTile;
	public float movementCost = 1;
	public bool isWalkable = true;

	/*
	private int x;
	private int y;

	public Tile( int xLocation, int yLocation)
	{
	    x = xLocation;
	    y = yLocation;
	}

	public void setCoords(int xLocation, int yLocation)
	{
	    x = xLocation;
	    y = yLocation;
	}
	*/
}

public class TileMap : MonoBehaviour
{
	[Header("Board Size")]
	public int mapSizeX;
	public int mapSizeY;

	public GameObject[,] tilesOnMap;

	[Header("Tiles")]
	public Tile[] tileTypes;
	public int[,] tiles;

	[Header("Containers")]
	public GameObject tileContainer;

	public Node[,] graph;
	public GameObject playerPrefab;
	public TileScript tileClicked;
	public TileScript TileSelected;
	public int range = 4;
	private HashSet<Node> highlightMveTile = new HashSet<Node>();
	public Text gridText;

	// Start is called before the first frame update
	private void Start()
	{
		generateMapInfo();
		generatePathFindingGraph();
		generateMapVisuals();

		//getMovementRange(range, graph[TileSelected.tileX, TileSelected.tileY], highlightMveTile);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			// this methode update the variable TileClicker
			tileClicked = selectTileToMoveTo();

			if (tileClicked)
			{
				tileClicked.node.icon = "E";
				TileSelected.makeSource(tileClicked);

				printGrid(graph);
				generatePathToSelectedNode(TileSelected, tileClicked);
			}
		}

		//highlightUnitRange();
	}

	public void generateMapInfo()
	{
		tiles = new int[mapSizeX, mapSizeY];
		for (int x = 0; x < mapSizeX; x++)
		{
			for (int y = 0; y < mapSizeY; y++)
			{
				tiles[x, y] = 0;
			}
		}
		// at pos (2,2) => player => 1
		tiles[mapSizeX / 2, mapSizeY / 2] = 1;
	}

	public void generatePathFindingGraph()
	{
		graph = new Node[mapSizeX, mapSizeY];

		//initialize graph
		for (int x = 0; x < mapSizeX; x++)
		{
			for (int y = 0; y < mapSizeY; y++)
			{
				graph[x, y] = new Node(x, y);
			}
		}
		//calculate neighbours
		for (int x = 0; x < mapSizeX; x++)
		{
			for (int y = 0; y < mapSizeY; y++)
			{
				//X is not 0, then we can add left (x - 1)
				if (x > 0)
				{
					graph[x, y].neighbours.Add(graph[x - 1, y]);
				}
				//X is not mapSizeX - 1, then we can add right (x + 1)
				if (x < mapSizeX - 1)
				{
					graph[x, y].neighbours.Add(graph[x + 1, y]);
				}
				//Y is not 0, then we can add downwards (y - 1 )
				if (y > 0)
				{
					graph[x, y].neighbours.Add(graph[x, y - 1]);
				}
				//Y is not mapSizeY -1, then we can add upwards (y + 1)
				if (y < mapSizeY - 1)
				{
					graph[x, y].neighbours.Add(graph[x, y + 1]);
				}
			}
		}
	}

	public void generateMapVisuals()
	{
		//generate list of actual tileGameObjects
		tilesOnMap = new GameObject[mapSizeX, mapSizeY];
		int index;
		for (int x = 0; x < mapSizeX; x++)
		{
			for (int y = 0; y < mapSizeY; y++)
			{
				index = tiles[x, y];
				GameObject newTile = Instantiate(tileTypes[index].tileVisualPrefab, new Vector3(x, 0, y), Quaternion.identity);
				tilesOnMap[x, y] = newTile;

				newTile.GetComponent<TileScript>().initTile(x, y, graph, this, newTile, tileTypes[index].unitOnTile);

				newTile.transform.SetParent(tileContainer.transform);
			}
		}
		// set the tileSelected Var
		TileSelected = tilesOnMap[mapSizeX / 2, mapSizeY / 2].GetComponent<TileScript>();
	}

	private TileScript selectTileToMoveTo()
	{
		RaycastHit hit;
		// in any case tile Clicked (pointeur) is asigned to TileMapFloor
		TileScript newTileCoord = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.transform.gameObject.CompareTag("Tile"))
			{
				// we found the tile we want to click update the TileMapFloor
				newTileCoord = hit.transform.GetComponent<TileScript>();
				Node node = newTileCoord.node;
			}
		}
		// if we didnt click of a Tile we asign tileClicked with null

		if (newTileCoord && tileClicked)
		{
			Debug.Log($"old tile {tileClicked}");
			resetGraphExcept(TileSelected);
		}
		return newTileCoord;
	}

	private HashSet<Node> getUnitMovementOptions()
	{
		HashSet<Node> UIHighlight = new HashSet<Node>();
		HashSet<Node> tempUIHighlight = new HashSet<Node>();
		HashSet<Node> finalMovementHighlight = new HashSet<Node>();
		float[,] cost = new float[mapSizeX, mapSizeY];

		UnitScript unitOntile = TileSelected.unitOnTile.GetComponent<UnitScript>();
		int moveSpeed = unitOntile.moveSpeed;
		Node selectedNode = graph[TileSelected.tileX, TileSelected.tileY];
		foreach (Node neighbour in selectedNode.neighbours)
		{
			TileScript tile = tilesOnMap[neighbour.x, neighbour.y].GetComponent<TileScript>();
			if (unitCanEnterTile(tile))
			{
				// get the cost of move of the neighbour
				Tile t = tileTypes[tiles[neighbour.x, neighbour.y]];
				float dist = t.movementCost;
				cost[neighbour.x, neighbour.y] = dist;
				// after substruction the moveSpeed we have from the cost of the
				// neighbour if we have some value >= 0 we save the neighbour node
				// into a HashSet
				if (moveSpeed - cost[neighbour.x, neighbour.y] >= 0)
				{
					UIHighlight.Add(neighbour);
				}

				// union both sets
			}
		}

		finalMovementHighlight.Add(selectedNode);
		finalMovementHighlight.UnionWith(UIHighlight);
		return finalMovementHighlight;
	}

	private bool unitCanEnterTile(TileScript tile)
	{
		return tile.Walkable;
	}

	private void generatePathToSelectedNode(TileScript source, TileScript destination)
	{
		if (tileClicked && TileSelected)
		{
			// generate path
			getPath();
			if (TileSelected == tileClicked)
			{
				Debug.Log($"you clicked on tile selected");
				return;
			}
		}
	}

	public void highlightUnitRange()
	{
		//highlightMovement();
	}

	public void getPath()
	{
		/**
		 * toDO: in the graph grid update the status of tehe tile (selected, clicked .... )
		 * so that when we re click to an other tile the path finding change the destination
		 * todo: optimaze the Path finding so that it wont init the source node in the constructor
		 * toDo: optimatze tthe TileSctipt Tile and Node file and understand the grid tiletypes
		 */
		Node destination = tileClicked.node;
		//Debug.Log($" tile clicked =>  ({tileClicked.node.x},{tileClicked.node.y})");
		Node source = TileSelected.node;

		Debug.Log($" new desti {tileClicked} source {TileSelected}");
		PathFinding.AStarAlgo(source, destination);
		Debug.Log($"----");
		foreach (var node in source.path)
		{
			//TileScript tile = GetComponent<TileScript>();
			//Renderer renderer = tile.GetComponent<Renderer>();
			//renderer.material.color = new Color(255, 255, 255, 6);
		}
		Debug.Log($"----");
		printGrid(graph);
	}

	private void printGrid(Node[,] graph)
	{
		//getThePaht(current);
		string str = "";
		for (int x = 0; x < mapSizeX; x++)
		{
			for (int y = 0; y < mapSizeY; y++)
			{
				str += graph[x, y].icon + " ";
			}
			str += "\n";
		}
		gridText.text = str;
	}

	private void resetGraphExcept(TileScript tileException)
	{
		for (int x = 0; x < mapSizeX; x++)
		{
			for (int y = 0; y < mapSizeY; y++)
			{
				if (x == tileException.tileX && y == tileException.tileY)
					continue;

				graph[x, y].resetNode();
			}
		}
	}
}