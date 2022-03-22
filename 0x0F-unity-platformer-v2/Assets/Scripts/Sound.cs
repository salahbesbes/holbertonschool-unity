using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
	public string name;

	[Range(0, 1)]
	public float volume = 1;

	[Range(0, 1)]
	public float pitch = 1;
	public bool loop = false;
	public bool playOnAwake = false;
	public AudioSource source;
	public AudioClip clip;
	public AudioMixerGroup audioMixer;
}