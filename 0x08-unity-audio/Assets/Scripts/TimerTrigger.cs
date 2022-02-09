using UnityEngine;

public class TimerTrigger : MonoBehaviour
{

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			Timer timer = other.GetComponent<Timer>();
			timer.enabled = true;
			timer.StartTimer();


		}
	}
}