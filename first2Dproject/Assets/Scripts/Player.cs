using UnityEngine;

public class Player : MonoBehaviour
{
	private BoxCollider2D collider;
	private Vector3 moveDelta;
	private RaycastHit2D hit;

	private void Start()
	{
		collider = GetComponent<BoxCollider2D>();
	}

	private void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		moveDelta = new Vector3(x, y, 0);

		if (moveDelta.x > 0)
		{
			// flip the cahr to the right
			transform.localScale = Vector3.one;
		}
		else if (moveDelta.x < 0)
		{
			// flip the cahracter to the left
			transform.localScale = new Vector3(-1, 1, 1);
		}

		// make sure we can move in this direction, by casting a box there, if box return
		// null we free to move for the y axes but if it collide with Actor or Blocking
		// Layer it will stop but since the charachter layer is Actior it will collide with
		// it self too and wont walk, to fix that we need to go to queries start on collider
		// under project_setting/Physics2D and uncheck it
		hit = Physics2D.BoxCast(transform.position,
			collider.size,
			0,
			new Vector2(0, moveDelta.y),
			Mathf.Abs(moveDelta.y * Time.fixedDeltaTime),
			LayerMask.GetMask("Actor", "Blocking"));

		if (hit.collider == null)
		{
			transform.Translate(0, moveDelta.y * Time.fixedDeltaTime, 0);
		}

		// make sure we can move in this direction, by casting a box there, if box return
		// null we free to move for the X axes but if it collide with Actor or Blocking
		// Layer it will stop but since the charachter layer is Actior it will collide with
		// it self too and wont walk, to fix that we need to go to queries start on collider
		// under project_setting/Physics2D and uncheck it
		hit = Physics2D.BoxCast(transform.position,
			collider.size,
			0,
			new Vector2(moveDelta.x, 0),
			Mathf.Abs(moveDelta.x * Time.fixedDeltaTime),
			LayerMask.GetMask("Actor", "Blocking"));
		if (hit.collider == null)
		{
			transform.Translate(moveDelta.x * Time.fixedDeltaTime, 0, 0);
		}
	}
}