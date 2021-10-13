using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{

	public string[] scenesNames;

	protected override void OnCollide(Collider2D collider)
	{
		if (collider.name == "Player")
		{
			SceneManager.LoadScene(Random.Range(0, scenesNames.Length));
		}



	}
}


