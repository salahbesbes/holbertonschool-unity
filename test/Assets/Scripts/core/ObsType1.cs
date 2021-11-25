using UnityEngine;

public class ObsType1 : MonoBehaviour
{
	public Transform partToRotate;

	private void Update()
	{
		partToRotate.RotateAround(partToRotate.position, Vector3.up, Time.deltaTime * 200);
	}
}