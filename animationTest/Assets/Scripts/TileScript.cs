using UnityEngine;

public class TileScript : MonoBehaviour
{
	public bool Walkable = true;
	public int tileX;
	public int tileY;
	public TileMap map;
	public System.Collections.Generic.List<Node> path = null;
	public GameObject unitOnTile = null;
	public Node node;

	public void initTile(int x, int y, Node[,] grid, TileMap map, GameObject parent, GameObject unitOnTilePrefab = null)
	{
		tileX = x;
		tileY = y;
		node = grid[x, y];
		this.map = map;
		path = new System.Collections.Generic.List<Node>();

		if (unitOnTilePrefab != null)
		{
			GameObject unit = Instantiate(unitOnTilePrefab, transform.position + Vector3.up, Quaternion.identity).gameObject;
			unit.transform.SetParent(parent.transform);
			this.unitOnTile = unit;
		}
	}

	public override string ToString()
	{
		return $"({this.tileX},{this.tileY})";
	}

	public void ResetTile()
	{
		node.g = float.PositiveInfinity;
		node.h = float.PositiveInfinity;
		node.icon = "*";
		node.path = new System.Collections.Generic.List<Node>();
		node.visited = false;
		node.parent = null;
	}

	public void makeSource(TileScript end)
	{
		if (end != null)
		{
			node.parent = null;
			node.icon = "S";
			node.g = 0.0f;
			// CalcH need destination(end) variable
			node.h = PathFinding.CalcH(node, end.node);
		}
	}

	public void highlight()
	{
	}
}