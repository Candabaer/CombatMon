using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public enum CombatState
{
	WaitingForCharacter = 0,
	WaitingForAbility = 1,
	WaitingForTarget = 2
}

public class CombatController : MonoBehaviour
{
	public UnityEvent<MonInstance> OnSelected;
	public List<GameObjectController> GameObjectControllers = new List<GameObjectController>();
	public ActionQueue ActionQueue;
	private int TurnCounter = 0;

	private CombatState currentState = CombatState.WaitingForCharacter;



	[SerializeField]
	public CombatUI CombatUI;

	private ICombatPhase CurrentPhase;
	public MonInstance SelectedMon { get; set; }
	public MonInstance TargetMon { get; set; }
	public AbilityInstance SelectedAbility { get; set; }


	private void Awake()
	{
		var go = GameObject.FindGameObjectsWithTag("Player").ToList();
		foreach (var goc in go)
		{
			GameObjectControllers.Add(goc.GetComponent<GameObjectController>());
		}
		SetPhase(new MonSelectionPhase());
	}

	public void SetPhase(ICombatPhase newPhase)
	{
		CurrentPhase?.Exit();
		CurrentPhase = newPhase;
		CurrentPhase.Enter(this);
	}
}
