using UnityEngine;

public class UnitScript : MonoBehaviour
{
	public int teamNum;
	public int x;
	public int y;

	public GameObject tileBeingOccupied;

	//UnitStats
	public string unitName;
	public int moveSpeed = 2;
	public int attackRange = 1;
	public int attackDamage = 1;
	public int maxHealthPoints = 5;
	public int currentHealthPoints;

	public TileMap map;
	public float moveSpeedTime = 1f;

	public System.Collections.Generic.List<Node> path = null;
}