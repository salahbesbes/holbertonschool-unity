using UnityEngine;

public class GameManager : MonoBehaviour
{
	private bool gameEnded = false;

	// Start is called before the first frame update
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
		if (PlayerStats.Lives <= 0)
		{
			if (gameEnded == true) return;
			GameEnd();
		}
	}

	private void GameEnd()
	{
		gameEnded = true;
		Debug.Log("Game Ended");
	}
}