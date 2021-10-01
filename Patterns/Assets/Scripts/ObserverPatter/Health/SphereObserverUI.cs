using UnityEngine.UI;

// this is an observer for the Subject HealthSystem
public class SphereObserverUI : ObserverAbstraction
{
	//private HealthSystem healthSystem;
	private Text textUi;

	private void Start()
	{
		textUi = GetComponent<Text>();
		//textUi.text = $"{base.healthSystem.GetHealth()}";
	}

	public override void OnHealthChange()
	{
		textUi.text = $"{healthSystem.GetHealth()}";
	}
}