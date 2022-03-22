using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void LevelSelect(int level)
	{
		switch (level)
		{
			case 1:
				SceneManager.LoadScene("Level01");
				break;

			case 2:
				SceneManager.LoadScene("Level02");
				break;

			case 3:
				SceneManager.LoadScene("Level03");
				break;

			default:
				break;
		}
	}

	public void Options()
	{
		SceneManager.LoadScene("Options");
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void HoverButton()
	{
	}
}