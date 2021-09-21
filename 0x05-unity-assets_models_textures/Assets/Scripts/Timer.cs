using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	private DateTime startTime;
	public Text TimerText;
	public float currentTime;
	private bool runTimer = false;
	private bool finished = false;






	private void Update()
	{
		// while we start the timer Conter and we dint finish we are updating the counter
		// time counting
		if (runTimer && !finished)
		{
			currentTime += Time.deltaTime;
		}

		// every frame print the current counter in the global Control
		printTimer(currentTime);
		// always updating the counter to the globalContral classs which is not destroyable
	}

	public void StartTimer()
	{
		runTimer = true;
	}

	public void StopTimer()
	{
		runTimer = false;
		finished = true;
	}


	public void printTimer(float currentTime)
	{
		float sec = currentTime % 60;
		float min = (currentTime / 60) % 60;
		float h = currentTime / 3600;

		TimerText.text = $"{h,0:00}:{min,0:00}.{sec,0:00}";
	}

}