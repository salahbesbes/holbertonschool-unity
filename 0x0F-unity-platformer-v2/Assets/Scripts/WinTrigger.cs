using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
	public Text textConter;
	public Text winText;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Win();
		}
	}

	public void Win()
	{
		// freeze the all the game timer and the camera
		Time.timeScale = 0;
		// activate the win Canvas
		textConter.transform.parent.gameObject.SetActive(false);
		winText.text = textConter.text;
		winText.transform.parent.gameObject.SetActive(true);

		Camera.main.GetComponent<AudioSource>().enabled = false;
		GameManager.Instance.Play("victoryPiano");
	}
}