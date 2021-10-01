using UnityEngine.UI;

public class StateObserverUI : ObserverStateAbstract
{
	private Text textUi;

	private void Start()
	{
		textUi = GetComponent<Text>();
		//textUi.text = $"{base.healthSystem.GetHealth()}";
	}

	public override void OnStateChange(PlayerBaseState newState)
	{
		textUi.text = $"{newState}";
	}
}