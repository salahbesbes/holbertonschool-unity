using System.Linq;
using UnityEngine;

public class Audio : MonoBehaviour
{
	private GameManager settings;

	// Start is called before the first frame update
	private void Start()
	{
		settings = GameManager.Instance;
		foreach (Sound s in settings.playerSounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
			s.source.volume = s.volume;
			s.source.playOnAwake = s.playOnAwake;
			s.source.outputAudioMixerGroup = s.audioMixer;
		}
	}

	/*
	 * this methode is used in the Animation event System
	 */

	public void playSound(string soundName)
	{
		if (soundName == "running")
		{
			if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
			{
				Renderer renderer = hit.transform?.gameObject?.GetComponent<Renderer>();
				if (renderer)
				{
					if (hit.collider.CompareTag("grass") || renderer.material.name.Contains("Wood"))
					{
						Sound sound = settings.playerSounds.SingleOrDefault(el => el.name == "runningOnGrass");
						if (sound != null)
						{
							sound.source.Play();
						}
					}
					else if (hit.collider.CompareTag("rock") || renderer.material.name.Contains("Stone"))
					{
						Sound sound = settings.playerSounds.SingleOrDefault(el => el.name == "runningOnRock");
						if (sound != null)
						{
							sound.source.Play();
						}
					}
				}
			}
		}
		else if (soundName == "landing")
		{
			if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
			{
				Renderer renderer = hit.transform?.gameObject?.GetComponent<Renderer>();
				if (renderer)
				{
					if (hit.collider.CompareTag("grass") || renderer.material.name.Contains("Wood"))
					{
						Sound sound = settings.playerSounds.SingleOrDefault(el => el.name == "landingOnGrass");
						if (sound != null)
						{
							sound.source.Play();
						}
					}
					else if (hit.collider.CompareTag("rock") || renderer.material.name.Contains("Stone"))
					{
						Sound sound = settings.playerSounds.SingleOrDefault(el => el.name == "landingOnRock");
						if (sound != null)
						{
							sound.source.Play();
						}
					}
				}
			}
		}
		else
		{
			Sound sound = settings.playerSounds.SingleOrDefault(el => el.name == soundName);
			if (sound != null)
			{
				sound.source.Play();
			}
			else
				Debug.Log($"can't Play Sound with Name  {soundName}");
		}
	}

	public void Stop(string soundName)
	{
		Sound sound = settings.playerSounds.SingleOrDefault(el => el.name == soundName);
		if (sound != null)
		{
			sound.source.Stop();
		}
		else
			Debug.Log($"can't Stop Sound with Name  {soundName}");
	}
}