using UnityEngine;

public class Chest : Collectable
{


	public Sprite Emptychest;
	public int pesosAmount = 5;

	protected override void OnCollide(Collider2D collider)
	{
		if (collider == null) Debug.Log($"collider is null");
		if (Collected == false)
		{
			Collected = true;
			GetComponent<SpriteRenderer>().sprite = Emptychest;
			Debug.Log($"Grant {pesosAmount}  pesos !");


		}



	}
}


