using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public Text RoundsText;

	private void OnEnable()
	{
		RoundsText.text = $"{PlayerStats.Rounds}";
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Menu()
	{
		Debug.Log("got to menu");
	}
}