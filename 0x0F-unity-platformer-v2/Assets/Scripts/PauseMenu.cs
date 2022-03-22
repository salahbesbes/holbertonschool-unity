using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// this component is attached to the pause canvase which is by default deactivated
/// </summary>
public class PauseMenu : MonoBehaviour
{
	private GameManager settings;

	private void Awake()
	{
		settings = GameManager.Instance;
	}

	/// <summary>
	/// set the time scale to 0 and activate the Pause canvas ( freeze the game )
	/// </summary>
	public void Pause()
	{
		Time.timeScale = 0;
		this.gameObject.SetActive(true);
		settings.pause.TransitionTo(0.01f);
	}

	/// <summary>
	/// set the time scale to 1 and disable the Pause canvas ( unfreeze the game )
	/// </summary>
	public void Resume()
	{
		Time.timeScale = 1;
		this.gameObject.SetActive(false);
		//AudioManager.Instance.Play("cheeryMonday");
		settings.play.TransitionTo(0.01f);
	}

	public void Restart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	public void Options()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Options");
	}
}