using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
	public UnitStats unit;
	public TextMeshProUGUI myHealth;
	public TextMeshProUGUI MyName;
	public TextMeshProUGUI myArmor;
	public TextMeshProUGUI myDamage;

	[Header("--------------------")]
	public TextMeshProUGUI TargetHealth;
	public TextMeshProUGUI TargetName;
	public TextMeshProUGUI TargetArmor;
	public TextMeshProUGUI TargetDamage;

	private void Start()
	{
	}

	public void triggerEvent()
	{
		unit.eventToListnTo.Raise(unit);
	}

	public void Die()
	{
		Debug.Log($"player died");
	}

	public void addArmorModifier()
	{
		if (unit.damage.modifiers.Count != 0)

		{
			unit.armor.AddModifier(unit.damage.modifiers[unit.damage.modifiers.Count - 1] + 2);
		}
		else
		{
			unit.armor.AddModifier(7);
		}
		triggerEvent();
	}

	public void addDamageModifier()
	{
		if (unit.damage.modifiers.Count != 0)

		{
			unit.damage.AddModifier(unit.damage.modifiers[unit.damage.modifiers.Count - 1] + 2);
		}
		else
		{
			unit.damage.AddModifier(10);
		}
		triggerEvent();
	}

	public void heal(int healValue)
	{
		unit.Health = Mathf.Clamp(unit.Health += healValue, 0, int.MaxValue);
		triggerEvent();
	}
}