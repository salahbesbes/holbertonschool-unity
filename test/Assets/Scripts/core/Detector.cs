using UnityEngine;

public class Detector : MonoBehaviour
{
	private Vector3 detectorPosition;

	private void Start()
	{
		detectorPosition = transform.Find("detector").position;
	}

	private void Update()
	{
		int layerToCheck = LayerMask.GetMask("Player");
		// each frame check if player pass
		if (Physics.Raycast(detectorPosition, Vector3.right * 3, layerToCheck))
		{
			// if player Pass update distance of the player
			GameObject.Find("Player").GetComponent<playerController>().distance++;
			// free some memory disable by disabling this Class if the player has passed
			// this detector
			transform.GetComponent<Detector>().enabled = false;
		}
	}

	private void OnDrawGizmos()
	{
		// drow ray
		Gizmos.DrawRay(detectorPosition, Vector3.right * 3);
	}
}