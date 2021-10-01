using UnityEngine;

public class GameManager : MonoBehaviour
{
	// static variable carrie the values even when we reload the scene thats why we initialize
	// it in the start methode
	public static bool GameIsOver { get; private set; }

	public GameObject gameOverUi;

	// Start is called before the first frame update
	private void Start()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	private void Update()
	{
		if (PlayerStats.Lives <= 0)
		{
			if (GameIsOver == true) return;
			GameEnd();
		}
	}

	private void GameEnd()
	{
		GameIsOver = true;
		gameOverUi.SetActive(true);
	}
}