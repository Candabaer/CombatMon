using UnityEngine;
using UnityEngine.Events;

public class MonSelectionPhase : ICombatPhase
{
	public UnityEvent<MonInstance> OnSelected;

	public CombatController CombatController { get; set; }


	public void Enter(CombatController controller)
	{
		Debug.Log("Entering Player Mon Selection Phase");
		CombatController = controller;

		foreach (var go in CombatController.GameObjectControllers)
		{
			go.OnSelected.AddListener(HandleMonSelection);
		}
		Debug.Log($"Subscribing all Click Events from MONS");
	}
	public void Exit()
	{
		foreach (var go in CombatController.GameObjectControllers)
		{
			go.OnSelected.RemoveAllListeners();
		}
		Debug.Log("Leaving Mon Selection Phase");
	}

	public void HandleMonSelection(MonInstance selectedMon)
	{
		CombatController.SelectedMon = selectedMon;
		Debug.Log($"SELECTED: {CombatController.SelectedMon.Name}" );

		CombatController.SetPhase(new AbilitySelectionPhase());
		Debug.Log("Setting AbilitySelection Phase");
	}
}
