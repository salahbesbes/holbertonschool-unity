using UnityEngine;

public class DragObject : MonoBehaviour

{
	private Vector3 mOffset;
	private float mZCoord;
	private NodeGrid grid;

	private void Awake()
	{
		grid = FindObjectOfType<NodeGrid>();
	}

	private void OnMouseDown()
	{
		mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
	}

	private Vector3 GetMouseAsWorldPoint()
	{
		// Pixel coordinates of mouse (x,y)

		Vector3 mousePoint = Input.mousePosition;

		// z coordinate of game object on screen

		mousePoint.z = mZCoord;

		// Convert it to world points

		return Camera.main.ScreenToWorldPoint(mousePoint);
	}

	private void OnMouseDrag()
	{
		Node currentNode = grid.getNodeFromTransformPosition(null, GetMouseAsWorldPoint() + mOffset);
		if (currentNode != null && currentNode.isObstacle == false)
			transform.position = currentNode.coord;
	}
}