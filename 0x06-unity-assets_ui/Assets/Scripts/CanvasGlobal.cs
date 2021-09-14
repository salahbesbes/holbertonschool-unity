using UnityEngine;
using UnityEngine.UI;

public class CanvasGlobal : MonoBehaviour
{
	private void Update()
	{
		// every frame print the current counter in the global Control
		printTimer(GlobalControl.Instance.currentTimer);
	}

	public void printTimer(float currentTime)
	{
		float sec = currentTime % 60;
		float min = (currentTime / 60) % 60;
		float h = currentTime / 3600;

		transform.GetChild(0).GetComponent<Text>().text = $"{h,0:00}:{min,0:00}.{sec,0:00}";
	}
}