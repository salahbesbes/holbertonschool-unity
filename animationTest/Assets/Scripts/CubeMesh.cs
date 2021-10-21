using UnityEngine;

public class CubeMesh : MonoBehaviour
{
	// Start is called before the first frame update
	private void Start()
	{
		makeCube();
	}

	// Update is called once per frame
	private void Update()
	{
	}

	private void makeCube()
	{
		var size = 20;

		Vector3[] VertexList ={
			new Vector3(-size, -size, -size),
			    new Vector3(-size, size, -size),
			    new Vector3(size, size, -size),
			    new Vector3(size, -size, -size),
			    //new Vector3(size, -size, size),
			    //new Vector3(size, size, size),
			    //new Vector3(-size, size, size),
			    //new Vector3(-size, -size, size)
  		    };

		int[] FaceList = {
		    0, 1, 3, //   1: face arrière
		    3, 1, 2,
		    //3, 2, 5, //   2: face droite
		    //3, 5, 4,
		    //5, 2, 1, //   3: face dessue
		    //5, 1, 6,
		    //3, 4, 7, //   4: face dessous
		    //3, 7, 0,
		    //0, 7, 6, //   5: face gauche
		    //0, 6, 1,
		    //4, 5, 6, //   6: face avant
		    //4, 6, 7
		};

		Vector2[] newUVs = {
		new Vector2(0, 0), //   1: face arrière
		new Vector2(0, 0),
		//new Vector2(0, 0), //   2: face droite
		//new Vector2(0, 0),
		//new Vector2(0, 0), //   3: face dessue
		//new Vector2(0, 0),
		//new Vector2(0, 0), //   4: face dessous
		//new Vector2(0, 0),
		//new Vector2(0, 0), //   5: face gauche
		//new Vector2(0, 0),
		//new Vector2(0, 0), //   6: face avant
		//new Vector2(0, 0)
		};

		var mesh = new Mesh();

		MeshFilter meshFilter = GetComponent(typeof(MeshFilter)) as MeshFilter;
		meshFilter.mesh = mesh;

		mesh.vertices = VertexList;

		//mesh.uv = newUVs;
		mesh.triangles = FaceList;

		mesh.RecalculateNormals();

		//meshFilter.transform.position = Vector3(0, 0.5, 0);
	}
}