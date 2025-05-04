using UnityEngine;

public class AbilitySelectionPhase : ICombatPhase
{
	public CombatController CombatController { get; set; }

	public void Enter(CombatController controller)
	{
		Debug.Log("Entering Ability Selection Phase");
		CombatController = controller;
		CombatController.CombatUI.Activate(CombatController.SelectedMon);
		CombatController.CombatUI.OnSelectedAttack.AddListener(AbilitySelection);
	}

	public void Exit()
	{
		Debug.Log("Leaving Ability Phase");
		CombatController.CombatUI.Deactivate();
		CombatController.CombatUI.OnSelectedAttack.RemoveAllListeners();
	}

	private void AbilitySelection(AbilityInstance ability)
	{
		CombatController.SelectedAbility = ability;
		Debug.Log($"SELECTED ABILITY: {CombatController.SelectedAbility.Name}");
		CombatController.SetPhase(new TargetSelectionPhase());
		Debug.Log("Setting up next Phase entering Target Selection Phase");
	}
}
