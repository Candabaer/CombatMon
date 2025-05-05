using UnityEngine;

public class ExecuteRound : ICombatPhase
{
	public CombatController CombatController { get; set; }

	public void Enter(CombatController controller)
	{
		CombatController = controller;
		CombatController.ExecuteTurn();
		CombatController.SetPhase(new MonSelectionPhase());
	}

	public void Exit()
	{

	}
}
