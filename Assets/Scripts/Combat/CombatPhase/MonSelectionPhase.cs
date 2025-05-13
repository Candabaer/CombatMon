using UnityEngine;
using UnityEngine.Events;

public class MonSelectionPhase : ICombatPhase
{
	public CombatController CombatController { get; set; }

	public void Enter(CombatController controller)
	{
		Debug.Log("Entering Player Mon Selection Phase");
		CombatController = controller;
		EventManager.Instance.Subscribe<MonSelectedEvent>(HandleMonSelection);
	}
	public void Exit()
	{
		EventManager.Instance.Unsubscribe<MonSelectedEvent>(HandleMonSelection);
		Debug.Log("Leaving Mon Selection Phase");
	}

	public void HandleMonSelection(MonSelectedEvent SelectedMon)
	{
		if (SelectedMon.AsAttackTarget)
			return;
		var selectedMon = SelectedMon.SelectedMon;
		CombatController.SelectedMon = selectedMon;
		Debug.Log($"SELECTED: {CombatController.SelectedMon.Name}" );

		CombatController.SetPhase(new AbilitySelectionPhase());
		Debug.Log("Setting AbilitySelection Phase");
	}
}
