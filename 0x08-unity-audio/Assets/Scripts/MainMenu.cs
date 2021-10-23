using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public AudioSource hoverSound;
	public AudioSource clickSound;

	public void LevelSelect(int level)
	{
		clickSound.Play();
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
		clickSound.Play();
		SceneManager.LoadScene("Options");
	}

	public void Exit()
	{

		clickSound.Play();
		Application.Quit();
	}

	public void HoverButton()
	{
		hoverSound.Play();

	}
}