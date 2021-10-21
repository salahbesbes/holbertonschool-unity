using UnityEngine;

public class detectCollision : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("trigger some thing");
	}

	private void Update()
	{
		Debug.Log($"hi");
	}
}