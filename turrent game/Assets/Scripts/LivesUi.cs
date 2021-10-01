using UnityEngine;
using UnityEngine.UI;

public class LivesUi : MonoBehaviour
{
	private Text livesText;

	private void Start()
	{
		livesText = transform.GetComponent<Text>();
	}

	private void Update()
	{
		livesText.text = $"{PlayerStats.Lives} Lives";
	}
}