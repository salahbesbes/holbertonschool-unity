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

	private void Start()
	{
		// when this object spawn it gets the last counter found in the globalControl class
		currentTime = GlobalControl.Instance.currentTimer;
	}

	private void Update()
	{
		// while we start the timer Conter and we dint finish we are updating the counter
		// time counting
		if (runTimer && !finished)
		{
			currentTime += Time.deltaTime;
		}
		// always updating the counter to the globalContral classs which is not destroyable
		GlobalControl.Instance.currentTimer = currentTime;
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
}