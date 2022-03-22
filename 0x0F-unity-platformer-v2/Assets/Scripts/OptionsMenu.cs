using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
	private bool _inverted = false;
	private GameManager settings;
	public Slider BGMSlider;
	public Slider SVXSlider;

	// this script is attached to the canvas
	private void Start()
	{
		settings = GameManager.Instance;
		_inverted = GameManager.Instance.IsInverted;

		Transform toggleButton = transform.Find("InvertYToggle");

		if (toggleButton)
		{
			toggleButton.GetComponent<Toggle>().isOn = GameManager.Instance.IsInverted;
		}
		BGMSlider.value = settings.MasterVolume;
		SVXSlider.value = settings.SFXVolume;
		BGMParams(settings.MasterVolume);
		SFXParams(settings.SFXVolume);
	}

	public void invertAxcesY(bool newstatus)
	{
		_inverted = newstatus;
	}

	public void Back()
	{
		SceneManager.LoadScene("Level01");
	}

	public void Apply()
	{
		// update the game manager of the change of bool value
		GameManager.Instance.IsInverted = _inverted;
		Back();
	}

	public void BGMParams(float sliderValue)
	{
		settings.MasterVolume = sliderValue;
		settings.mainAudioMixer.SetFloat("BGMVolume", sliderValue);
	}

	public void SFXParams(float sliderValue)
	{
		settings.SFXVolume = sliderValue;
		settings.mainAudioMixer.SetFloat("SVXVolume", sliderValue);
		settings.mainAudioMixer.SetFloat("AmbianceVolume", sliderValue);
	}
}