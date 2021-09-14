using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
	public Text textConter;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Timer timer = other.GetComponent<Timer>();
			timer.StopTimer();
			timer.TimerText.color = Color.green;
			timer.TimerText.fontSize = 60;
		}
	}
}