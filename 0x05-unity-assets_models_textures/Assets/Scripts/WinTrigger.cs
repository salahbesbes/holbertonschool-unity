using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
	public Transform player;

	private Timer TimerCMP;
	private Text textTimer;

	private void Start()
	{
		// Timer component in the player instance is the one responsible for the time Counter
		TimerCMP = player.GetComponent<Timer>();
		textTimer = TimerCMP.TimerText;
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
		textTimer.color = Color.green;
		textTimer.fontSize = 80;

		TimerCMP.StopTimer();
	}
}