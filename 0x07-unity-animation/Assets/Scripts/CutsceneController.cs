using UnityEngine;

public class CutsceneController : MonoBehaviour
{
	public Camera mainCamera;
	public Transform player;
	public Canvas canvas;
	public void ActivateMainCamera()
	{
		player.GetComponent<PlayerController>().enabled = true;
		canvas.gameObject.SetActive(true);
		mainCamera.gameObject.SetActive(true);
		transform.gameObject.SetActive(false);
	}
}
