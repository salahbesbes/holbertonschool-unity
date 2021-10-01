using UnityEngine;
using UnityEngine.UI;

public class SphereObsever : ObserverAbstraction
{
	public Transform p;
	PlayerStatus player;
	private void Awake()
	{
		player = p.GetComponent<PlayerStatus>();
	}

	private void OnHeal(int amount)
	{
		Text TextComp = GetComponent<Text>();
		TextComp.text = $"{player.Health}";
	}

	public override void OnEnable()
	{
		PlayerStatus.Heal += OnHeal;
	}
	public override void OnDisable()
	{
		PlayerStatus.Heal -= OnHeal;
	}
}
