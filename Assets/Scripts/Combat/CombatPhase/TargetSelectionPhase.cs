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

		EventManager.Instance.Subscribe<MonSelectedEvent>(HandleMonSelection);
	}

	public void Exit()
	{
		EventManager.Instance.Unsubscribe<MonSelectedEvent>(HandleMonSelection);

		Debug.Log($"Now leaving Target Selection Phase");
	}

	private void HandleMonSelection(MonSelectedEvent Target)
	{
		CombatController.TargetMon = Target.SelectedMon;
		CombatController.SetPhase(new SwitchTurnsPhase());
	}
}
