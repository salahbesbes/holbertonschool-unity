using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	// singleton patter
	public static GameManager Instance { get; private set; }

	public bool IsInverted { get; set; } = false;
	public string[] AvailableScene { get; set; } = new string[] { "Level01", "Level02", "Level03", "MainMenu" };

	public string previousScene = "Level01";
	private PlayerController player;
	private Audio playerAudio;

	public AudioMixerSnapshot pause;
	public AudioMixerSnapshot play;
	public AudioMixer mainAudioMixer;
	public List<Sound> playerSounds = new List<Sound>();
	public List<Sound> gameSounds = new List<Sound>();

	public List<Sound> SFX = new List<Sound>();
	public float MasterVolume = 0;
	public float SFXVolume = 0;
	public string playerInputString;
	public InputSaveLoader sc;
	public InputActionAsset playerInput;

	private void Awake()
	{
		// only a single instance of this class lives in the game when ever a new scene is
		// loaded even if the create a new Gamemanager instance it will be destroyed because
		// we have alread a living instance in the game
		//player = FindObjectOfType<PlayerController>();
		//playerAudio = player.GetComponent<Audio>();

		if (GameManager.Instance == null)
		{
			playerAudio = FindObjectOfType<Audio>();
			if (!string.IsNullOrEmpty(sc.playerInputString))
				playerInput.LoadBindingOverridesFromJson(sc.playerInputString);
			Instance = this;
			foreach (Sound s in gameSounds)
			{
				s.source = gameObject.AddComponent<AudioSource>();
				s.source.clip = s.clip;
				s.source.pitch = s.pitch;
				s.source.loop = s.loop;
				s.source.volume = s.volume;
				s.source.playOnAwake = s.playOnAwake;
				s.source.outputAudioMixerGroup = s.audioMixer;
				if (s.playOnAwake == true) Play(s.name);
			}
			//DontDestroyOnLoad(transform.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	public void Play(string soundName)
	{
		Sound sound = gameSounds.SingleOrDefault(el => el.name == soundName);
		if (sound != null)
		{
			sound.source.Play();
		}
	}

	public void Stop(string soundName)
	{
		Sound sound = gameSounds.SingleOrDefault(el => el.name == soundName);
		if (sound != null)
		{
			sound.source.Stop();
		}
	}
}