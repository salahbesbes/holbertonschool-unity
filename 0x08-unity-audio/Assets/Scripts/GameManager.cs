using UnityEngine;

public class GameManager : MonoBehaviour
{

	// singleton patter
	public static GameManager Instance { get; private set; }
	public bool IsInverted { get; set; } = false;
	public string[] AvailableScene { get; set; } = new string[] { "Level01", "Level02", "Level03", "MainMenu" };


	void Awake()
	{
		// only a single instance of this class lives in the game
		// when ever a new scene is loaded even if the create a new Gamemanager instance
		// it will be destroyed because we have alread a living instance in the game
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(transform.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}


	}
}
