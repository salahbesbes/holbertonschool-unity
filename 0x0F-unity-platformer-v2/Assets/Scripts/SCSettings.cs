using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "settings", menuName = "settings")]
public class SCSettings : ScriptableObject
{
	public AudioMixerSnapshot pause;
	public AudioMixerSnapshot play;
	public AudioMixer mainAudioMixer;
	public List<Sound> playerSounds = new List<Sound>();
	public List<Sound> gameSounds = new List<Sound>();
	public List<Sound> SFX = new List<Sound>();
	public float MasterVolume = 0;
	public float SFXVolume = 0;
}