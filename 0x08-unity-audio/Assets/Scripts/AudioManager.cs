using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public List<Sound> sounds = new List<Sound>();


	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}


		foreach (Sound s in sounds)
		{

			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
			s.source.volume = s.volume;
			s.source.playOnAwake = s.playOnAwake;
			s.source.outputAudioMixerGroup = s.audioMixer;

		}
		Play("wallpaper");
	}
	public void Play(string soundName)
	{
		Sound sound = sounds.Single(el => el.name == soundName);
		if (sound != null)
		{
			sound.source.Play();
		}
	}


	public void Stop(string soundName)
	{
		Sound sound = sounds.Single(el => el.name == soundName);
		if (sound != null)
		{
			sound.source.Stop();
		}


	}
	[System.Serializable]
	public class Sound
	{
		public string name;
		public AudioSource source;
		public AudioClip clip;
		[Range(0, 1)]
		public float volume = 1;
		[Range(0, 1)]
		public float pitch = 1;
		public bool loop = false;
		public bool playOnAwake = true;
		public AudioMixerGroup audioMixer;


	}
}