using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Data", menuName = "Player Input", order = 1)]
public class InputSaveLoader : ScriptableObject
{
	public InputActionAsset playerInput;
	public string playerInputString;
}