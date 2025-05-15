using UnityEditor.Playables;
using UnityEngine;

public class AbilitySelectionPhase : ICombatPhase
{
	public CombatController CombatController { get; set; }

	public void Enter(CombatController controller)
	{
		Debug.Log("Entering Ability Selection Phase");
		CombatController = controller;
		EventManager.Instance.Subscribe<AbilitySelectedEvent>(AbilitySelection);
	}

	public void Exit()
	{
		Debug.Log("Leaving Ability Phase");

		EventManager.Instance.Unsubscribe<AbilitySelectedEvent>(AbilitySelection);
		CombatController.CombatUI.Deactivate(); //TODO Besser über Event gesteuert? 
	}

	private void AbilitySelection(AbilitySelectedEvent Ability)
	{
		var ability = Ability.SelectedAbility;
		CombatController.SelectedAbility = ability;
		Debug.Log($"SELECTED ABILITY: {CombatController.SelectedAbility.Name}");
		CombatController.SetPhase(new TargetSelectionPhase());
		Debug.Log("Setting up next Phase entering Target Selection Phase");
	}
}
