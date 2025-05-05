using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CombatController : MonoBehaviour
{
	//public UnityEvent<MonInstance> OnSelected;
	//public List<GameObjectController> GameObjectControllers = new List<GameObjectController>();
	public ActionQueue ActionQueue = new();
	private int TurnCounter = 0;

	//public PlayerCombatController PlayerCombatController;
	public PlayerCombatController ActivePlayer;
	public PlayerCombatController InActivePlayer;

	[SerializeField]
	public CombatUI CombatUI;

	private ICombatPhase CurrentPhase;
	public MonInstance SelectedMon { get; set; }
	public MonInstance TargetMon { get; set; }
	public AbilityInstance SelectedAbility { get; set; }


	private void Awake()
	{
		ActivePlayer = new PlayerCombatController("PlayerA", new List<string> { "PlayerB" });
		InActivePlayer = new PlayerCombatController("PlayerB", new List<string> { "PlayerA" });
		SetPhase(new StartCombat());
	}

	public void SetPhase(ICombatPhase newPhase)
	{
		CurrentPhase?.Exit();
		CurrentPhase = newPhase;
		CurrentPhase.Enter(this);
	}

	public void AddActionQueue()
	{
		var actionItem = new ActionQueueEntry(SelectedMon, TargetMon, SelectedAbility);
		ActionQueue.AddToQueue(actionItem);
	}

	public bool QueueFull()
	{
		var x = ActivePlayer.EnemyMons;
		var y = ActivePlayer.PlayerMons;
		x.AddRange(y);
		return ActionQueue.QueueFull(x);
	}

	public void ExecuteTurn()
	{
		while (ActionQueue.Peek() != null)
		{
			ActionQueueEntry TurnAction = ActionQueue.Dequeue();
			TurnAction.ChosenAbility.Apply(TurnAction.Source, TurnAction.Target);
		}
	}
}

