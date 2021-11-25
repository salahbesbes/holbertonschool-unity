using UnityEngine;

public class PersonBehavior : MonoBehaviour
{
	public Person person;
	private Transform player;

	private void Start()
	{
		player = GameObject.Find("Player").transform;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			switch (person.personType)
			{
				case PersonType.cha3bi:
					Cha3bi newPerson = new Cha3bi();
					newPerson.OnPickUp(other.transform);
					break;

				default:
					break;
			}
		}
	}

	private void Update()
	{
		lookAt(player);
	}

	private void lookAt(Transform target)
	{
		// handle rotation on axe Y
		Vector3 dir = (target.position + Vector3.forward) - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		// smooth the rotation of the turrent
		Vector3 rotation = Quaternion.Lerp(transform.rotation,
						lookRotation,
						Time.deltaTime * 100f)
						.eulerAngles;
		transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}
}