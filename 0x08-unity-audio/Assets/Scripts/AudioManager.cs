using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;
	void Start()
	{
		instance = this;
		if (instance != null)
		{
			Destroy(this.gameObject);
		}
	}

	void Update()
	{

	}
}
