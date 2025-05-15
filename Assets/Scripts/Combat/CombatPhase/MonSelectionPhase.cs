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
		EventManager.Instance.Raise(new MonAbilityUIEvent(SelectedMon.SelectedMon));

		var selectedMon = SelectedMon.SelectedMon;
		CombatController.SelectedMon = selectedMon;

		CombatController.SetPhase(new AbilitySelectionPhase());
	}
}
