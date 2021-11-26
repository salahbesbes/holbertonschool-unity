using UnityEngine;

public class ObsType1 : MonoBehaviour
{
	public Transform partToRotate;

	private void Update()
	{
		transform.RotateAround(partToRotate.position, Vector3.up, Time.deltaTime * 200);
	}
}