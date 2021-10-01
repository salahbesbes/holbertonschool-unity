using UnityEngine;

public class GlobalControl : MonoBehaviour
{
	public static GlobalControl Instance;
	public float currentTimer = 1000f;

	// once create for the first time the Instance never get destroyed and it can be used as
	// GameObject transation data between scenes
	private void Awake()
	{
		if (Instance == null)
		{
			// this Instance will never be destroyed
			DontDestroyOnLoad(gameObject);
			// Singleton Pattern
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}
}