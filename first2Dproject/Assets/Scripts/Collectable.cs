using UnityEngine;

public class Collectable : Collidable
{
	protected bool Collected = false;

	protected override void OnCollide(Collider2D collider)
	{
		base.OnCollide(collider);
		Collected = true;
	}


}
