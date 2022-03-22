using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Next()
	{
		string[] availableScenes = GameManager.Instance.AvailableScene;
		string currentScene = SceneManager.GetActiveScene().name;
		int currentSceneIndex = Array.IndexOf(availableScenes, currentScene);
		GameManager.Instance.previousScene = availableScenes[currentSceneIndex];
		int nextSceneIndex = (currentSceneIndex + 1) % availableScenes.Length;

		SceneManager.LoadScene(availableScenes[nextSceneIndex]);
	}
}
