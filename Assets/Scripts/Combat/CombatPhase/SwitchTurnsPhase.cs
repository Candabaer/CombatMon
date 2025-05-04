using UnityEngine;

internal class SwitchTurnsPhase : ICombatPhase
{
	public CombatController CombatController { get; set;  }

	public void Enter(CombatController controller)
	{
		CombatController = controller;
		var tmpPlayer = CombatController.ActivePlayer;
		CombatController.ActivePlayer = CombatController.InActivePlayer;
		CombatController.InActivePlayer = tmpPlayer;
		CombatController.SetPhase(new MonSelectionPhase());
	}

	public void Exit()
	{
	}
}