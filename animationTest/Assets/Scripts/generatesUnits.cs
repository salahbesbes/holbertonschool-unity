using UnityEngine;

public class generatesUnits : MonoBehaviour
{
	public GameObject cubePrefab;
	private MeshRenderer renderer;
	private Vector3 size;

	// Start is called before the first frame update
	private void Start()
	{
		renderer = GetComponent<MeshRenderer>();
		size = renderer.bounds.size;
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		int boxX = Mathf.FloorToInt(x);
		int boxZ = Mathf.FloorToInt(z) + 1;
		int boxY = Mathf.FloorToInt(Mathf.Abs(y));
		GameObject unit = Instantiate(cubePrefab, new Vector3(boxX, boxY, boxZ), Quaternion.identity).gameObject;

		unit.AddComponent<detectCollision>();
	}

	// Update is called once per frame
	private void Update()
	{
	}
}