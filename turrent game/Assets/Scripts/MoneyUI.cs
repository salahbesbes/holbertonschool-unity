using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
	private Text textUi;
	void Start()
	{
		textUi = transform.GetComponent<Text>();
	}

	void Update()
	{
		textUi.text = $"$ {PlayerStats.Money}";
	}
}
