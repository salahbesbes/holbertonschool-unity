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
	public GameObject leftObstacleType1;
	public GameObject rightObstacleType1;
	public float heightPrefab = 10f;
	public float doubleObstacleHeight = 1f;
	public float singleObstacleHeight = 1f;
	private int nbOfPersongGeneratedSinceLastObstacle = 0;

	private Vector3 instantiatePoint;

	[Range(1, 9)]
	public float frequenceOfObstacle;
	public float DistanceKM = 0;
	public GameObject singleObstaclePrefab;

	private void Start()
	{
		player = GameObject.Find("Player").transform;
		lastPos = gameObject.transform.position;
	}

	// Update is called once per frame
	private void Update()
	{
		DistanceKM = Mathf.Floor(player.position.z);
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

	private void selectObstacleType(float XPosition, Vector3 updatedPos, GameObject lastPlane)
	{
		Vector3 offset;

		// select tthe type of the obstacle based on the X position of the Vec3
		switch (XPosition)
		{
			case -1:
				// create obstacle
				offset = new Vector3(1f, doubleObstacleHeight * 0.05f, 0);
				instantiatePoint = updatedPos + offset;

				Instantiate(rightObstacleType1, updatedPos + offset, rightObstacleType1.transform.rotation, lastPlane.transform);
				break;

			case 0:
				//this create an obstacle ontop of the person to pick(at the same time)
				offset = new Vector3(0f, singleObstacleHeight * 0.05f, 0);

				instantiatePoint = updatedPos + offset;

				Instantiate(singleObstaclePrefab, updatedPos + offset, singleObstaclePrefab.transform.rotation, lastPlane.transform);
				break;

			case 1:
				offset = new Vector3(-1f, doubleObstacleHeight * 0.05f, 0);
				instantiatePoint = updatedPos + offset;
				Instantiate(leftObstacleType1, updatedPos + offset, leftObstacleType1.transform.rotation, lastPlane.transform);
				break;

			default:
				break;
		}
	}

	private void randomGeneratePrefab(GameObject objPrefab, GameObject lastPlane)
	{
		// the frequence
		if (lastPlane.transform.position.z % 4 == 0 && lastPlane.transform.position.z >= 30)
		{
			//// scale the height of the prefab
			objPrefab.transform.localScale = new Vector3(objPrefab.transform.localScale.x, heightPrefab, objPrefab.transform.localScale.z);

			Vector3 updatedPos = lastPlane.transform.position;

			// set the prefab on the Ground
			//updatedPos.y = (heightPrefab / 2) * 0.05f;

			// create 3 position, in 3 ways
			Vector3[] allPosition = new Vector3[] { updatedPos ,
								updatedPos + Vector3.left ,
								updatedPos + Vector3.right };
			// select random way
			int randomIndex = Mathf.RoundToInt(Random.Range(0, allPosition.Length));

			// create an obstacle + the person at the same time at some frequence

			nbOfPersongGeneratedSinceLastObstacle++;
			if (nbOfPersongGeneratedSinceLastObstacle > frequenceOfObstacle)
			{
				nbOfPersongGeneratedSinceLastObstacle = 0;
				selectObstacleType(allPosition[randomIndex].x, lastPlane.transform.position, lastPlane);
			}
			else
			{
				// init the prefab
				GameObject person = Instantiate(objPrefab, allPosition[randomIndex], Quaternion.identity, lastPlane.transform);
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawSphere(instantiatePoint, 0.1f);
	}
}