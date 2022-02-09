using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
	private bool _inverted = false;
	public AudioMixer soundVol;

	// this script is attached to the canvas
	private void Start()
	{
		_inverted = GameManager.Instance.IsInverted;

		System.Console.WriteLine();
		// when the scene is loaded we need to get the value of the isInverted from the
		// gameManager and set it to isOn attribute of the child of the canvas

		//Toggle toggleButton = transform.GetChild(4).GetComponent<Toggle>();

		// Find methode can return null thats why using the check condition
		Transform toggleButton = transform.Find("InvertYToggle");

		if (toggleButton)
		{
			toggleButton.GetComponent<Toggle>().isOn = GameManager.Instance.IsInverted;
		}
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
		soundVol.SetFloat("BGMVolume", Mathf.Log10(sliderValue) * 20);
		float val;

		soundVol.GetFloat("BGMVolume", out val);
		Debug.Log($"{val}");
	}
}