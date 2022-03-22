using UnityEngine;
using UnityEngine.InputSystem;

public class ResetBindings : MonoBehaviour
{
	public InputActionAsset input;
	public InputSaveLoader sc;

	public void ResetAllBinding()
	{
		foreach (InputActionMap binding in input.actionMaps)
		{
			binding.RemoveAllBindingOverrides();
		}
	}

	public void PersistData()
	{
		sc.playerInputString = input.SaveBindingOverridesAsJson();
		Debug.Log($"we persist data");
	}
}