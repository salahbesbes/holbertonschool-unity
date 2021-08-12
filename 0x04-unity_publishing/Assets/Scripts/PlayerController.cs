using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed = 50f;
	public Rigidbody rb;
	private int score = 0;
	public int health = 5;

	public Text scoreText;
	public Text healthText;
	public Image winLoseImage;

	private void OnTriggerEnter(Collider other)
	{
		switch (other.tag)
		{
			case "Pickup":
				score++;
				SetScoreText();
				Destroy(other.gameObject); // destroy

				break;

			case "Trap":
				health--;
				SetHealthText();
				break;

			case "Goal":
				DisplayWinPanel();
				StartCoroutine(LoadScene(3));
				break;

			default:
				return;
		}
	}

	// fixedUpdate execute after the Update (after player channge position the camera get it new one)
	private void FixedUpdate()
	{
		float currentXPosition = Input.GetAxis("Horizontal");
		float currentZPosition = Input.GetAxis("Vertical");

		Vector3 dir = new Vector3(currentXPosition, 0, currentZPosition).normalized;

		Vector3 force = dir * speed * Time.deltaTime;

		rb.AddForce(force);
	}

	private void Update()
	{
		if (health == 0)
		{
			// if player health raech 0 -> restart the game
			DisplayLosePanel();
			// we use caroutine because this function is async (will execute after
			// certain sec)
			StartCoroutine(LoadScene(3));
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			// if player press the "esc"
			SceneManager.LoadScene("menu");
		}
	}

	private void SetScoreText()
	{
		scoreText.text = $"Score {score}";
	}

	private void SetHealthText()
	{
		healthText.text = $"Health: {health}";
	}

	private void DisplayWinPanel()
	{
		Text winLoseText = winLoseImage.GetComponentInChildren<Text>();
		winLoseText.text = "You Win!";
		winLoseText.color = Color.black;

		winLoseImage.color = Color.green;

		winLoseImage.gameObject.SetActive(true);
	}

	private void DisplayLosePanel()
	{
		Text winLoseText = winLoseImage.GetComponentInChildren<Text>();
		winLoseText.text = "Game Over!";
		winLoseText.color = Color.white;

		winLoseImage.color = Color.red;

		winLoseImage.gameObject.SetActive(true);
	}

	private IEnumerator LoadScene(float seconds)
	{
		// wait for sertain sec before we pass the the next line
		yield return new WaitForSeconds(seconds);

		// we restart the level
		health = 5;
		score = 0;
		Scene scene = SceneManager.GetActiveScene();
		Debug.Log(scene.name);
		SceneManager.LoadScene(scene.name);
	}
}