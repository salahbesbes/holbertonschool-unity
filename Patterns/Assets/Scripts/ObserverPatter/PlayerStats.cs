using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public HealthSystem health = new HealthSystem(100);

	public SphereObserverUI shpereUi;
	public HealthBar healthBar;
	public Button ButtonDamage;
	public Button ButtonHeal;

	[Header("Damage")]
	public float DamageAmout = 10;

	[Header("Heal")]
	public float HealAmount = 0.5f;

	private void OnEnable()
	{
		// subscribe the observer to the Subject (HealthSystem). to avoid any malfunction
		// the subscrition of the Observers are done here not in the Start func
		healthBar.Subsribe(health);
		shpereUi.Subsribe(health);
	}

	private void Start()
	{
		// display some button for easy debug
		Button damageButton = ButtonDamage.GetComponent<Button>();
		damageButton.onClick.AddListener(TakeDamage);

		Button healButton = ButtonHeal.GetComponent<Button>();
		healButton.onClick.AddListener(HealPlayer);
	}

	// update the HealthSystem instance
	private void HealPlayer()
	{
		health.Heal(HealAmount);
	}

	private void TakeDamage()
	{
		health.Damage(DamageAmout);
	}
}