using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TargetSelectionPhase : ICombatPhase
{
	public CombatController CombatController { get; set; }

	public void Enter(CombatController controller)
	{
		//TODO Legal Targets filtern
		Debug.Log($"Entered Target Selection Phase");
		CombatController = controller;

		foreach (var go in CombatController.ActivePlayer.EnemyMons)
		{
			//go.OnSelected.AddListener(HandleMonSelection);
		}
	}

	public void Exit()
	{
		foreach (var go in CombatController.ActivePlayer.EnemyMons)
		{
			//go.OnSelected.RemoveAllListeners();
		}
		Debug.Log($"Now leaving Target Selection Phase");
	}

	private void HandleMonSelection(MonInstance target)
	{
		CombatController.TargetMon = target;
		Debug.Log($"TARGETED MON: {CombatController.TargetMon.Name}");
		CombatController.SetPhase(new SwitchTurnsPhase());
		Debug.Log($"Target for Attack determined switching Phase");
	}
}
