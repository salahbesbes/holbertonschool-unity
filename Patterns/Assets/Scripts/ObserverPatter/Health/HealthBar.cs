using UnityEngine.UI;

public class HealthBar : ObserverAbstraction
{
	private Slider slider;

	public override void OnHealthChange()
	{
		// callBak ececuted when the Subject (HealthSystem) Invoke the Event
		slider.value = healthSystem.GetHealthPercent();
	}

	private void Start()
	{
		// get ref of the Ui (Observer)
		slider = transform.GetComponent<Slider>();
	}
}