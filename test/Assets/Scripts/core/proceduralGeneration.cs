using UnityEngine;

public class proceduralGeneration : MonoBehaviour
{
	// Used to generate planes based on the player position
	private Transform player;

	// Plane model, later will be changed to a list and randomized
	public GameObject plane_model;

	// Last game object instantied
	public GameObject planeContainer;

	public Vector3 lastPos;
	// Start is called before the first frame update

	// prefab to instantiate
	public GameObject objPrefab;
	public float heightPrefab = 10f;

	public float DistanceKM = 0;

	private void Start()
	{
		player = GameObject.Find("Player").transform;
		lastPos = gameObject.transform.position;
	}

	// Update is called once per frame
	private void Update()
	{
		if (lastPos.z <= player.position.z + 30)
		{
			GameObject lastPlane = Instantiate(plane_model, lastPos + Vector3.forward, Quaternion.identity);
			// add the Detector Class to the object
			lastPlane.AddComponent<Detector>();
			// generate some prefab at the lastPlane
			randomGeneratePrefab(objPrefab, lastPlane);
			lastPlane.transform.parent = planeContainer.transform;
			lastPos = lastPlane.transform.position;
			if (planeContainer.transform.childCount >= 100)
			{
				for (int i = 0; i < 10; i++)
				{
					Destroy(planeContainer.transform.GetChild(0).gameObject);
				}
			}
		}
	}

	private void randomGeneratePrefab(GameObject objPrefab, GameObject lastPlane)
	{
		// the frequence
		if (lastPlane.transform.position.z % 4 == 0 && lastPlane.transform.position.z >= 30)
		{
			// scale the height of the prefab
			objPrefab.transform.localScale = new Vector3(0.3f, heightPrefab, 0.3f);

			Vector3 updatedPos = lastPlane.transform.position;

			// set the prefab on the Ground
			updatedPos.y = (heightPrefab / 2) * 0.05f;

			// create 3 position, in 3 ways
			Vector3[] allPosition = new Vector3[] { updatedPos ,
								updatedPos + Vector3.left ,
								updatedPos + Vector3.right };
			// select random way
			int randomIndex = Mathf.RoundToInt(Random.Range(0, allPosition.Length));
			// init the prefab
			Instantiate(objPrefab, allPosition[randomIndex], Quaternion.identity, lastPlane.transform);
		}
	}
}