using UnityEngine;

public class Chest : Collidable
{
	protected override void OnCollide(Collider2D collider)
	{
		//base.OnCollide(collider);
		Debug.Log($"hit some one ");

	}
}
