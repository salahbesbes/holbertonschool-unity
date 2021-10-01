using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
	private Text textUi;

	private void Start()
	{
		textUi = transform.GetComponent<Text>();
	}

	private void Update()
	{
		textUi.text = $"$ {PlayerStats.Money}";
	}
}