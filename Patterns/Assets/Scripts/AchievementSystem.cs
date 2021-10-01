using UnityEngine;

public class AchievementSystem : Observable
{


	private void Start()
	{
		FindObjectOfType<Subject>().Register(this);
	}

	public override void UpdateObservable(Collider collider)
	{
		//Debug.Log($"{collider.tag}");
		//switch (collider.tag)
		//{
		//	case "stage1":
		//		Debug.Log($" you finished the {collider.tag}");
		//		break;

		//	case "stage2":
		//		Debug.Log($" you finished the {collider.tag}");
		//		break;

		//	case "stage3":
		//		Debug.Log($" you finished the {collider.tag}");
		//		break;
		//	default:
		//		break;
		//}
	}

}


