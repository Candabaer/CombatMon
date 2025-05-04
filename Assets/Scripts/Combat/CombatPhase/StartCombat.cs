using UnityEngine;

public class StartCombat : ICombatPhase
{
	public CombatController CombatController { get ; set; }

	public void Enter(CombatController controller)
	{
		CombatController = controller;
		CombatController.SetPhase(new MonSelectionPhase());
		Debug.Log("Ending StartCombatPhase");
	}

	public void Exit()
	{
	}
}
