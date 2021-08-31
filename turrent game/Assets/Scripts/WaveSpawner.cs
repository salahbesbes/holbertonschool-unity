using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public Transform enemyPrefab;

	public float timeBetweenWaves = 5.5f;
	private float countDown = 2f;
	private int waveIndex = 1;
	public Transform spawnPoint;
	public Text waveCountDownText;

	private void Update()
	{
		if (countDown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countDown = timeBetweenWaves;
		}
		// reduce countDown by 1 sec every frame
		countDown -= Time.deltaTime;
		// update the canvas UI
		waveCountDownText.text = Math.Round(countDown).ToString();
	}

	// this methode is independent from the update methode it has its own time counter
	private IEnumerator SpawnWave()
	{
		waveIndex++;
		// time to spend to spawn all enemyin a wave + 0.5 (safe time to avoid lags)
		double timeNeededToSpawnNextWave = 0.5 * waveIndex + 0.5;
		// update timeBetweenWaves to fixed time 5 sec (even with large waves of enemies)
		timeBetweenWaves = 5 + (float)timeNeededToSpawnNextWave;
		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			// spend 0.5 sec to spawn 1 enemy in a wave
			yield return new WaitForSeconds(0.5f);
		}
	}

	private void SpawnEnemy()
	{
		// create new enemy at some position
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}