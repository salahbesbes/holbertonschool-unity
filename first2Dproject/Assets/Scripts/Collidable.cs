using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{


	public ContactFilter2D filter = new ContactFilter2D();
	private BoxCollider2D boxCollider;
	private List<Collider2D> hits = new List<Collider2D>();



	protected virtual void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
		hits.Add(boxCollider);
	}

	protected virtual void Update()
	{
		int res = boxCollider.OverlapCollider(filter, hits);
		Debug.Log($"{res}");
		for (int i = 0; i < res; i++)
		{
			OnCollide(hits[i]);
		}
	}

	protected virtual void OnCollide(Collider2D collider)
	{
		Debug.Log($"collide with  { collider.gameObject.name}");
	}
}
