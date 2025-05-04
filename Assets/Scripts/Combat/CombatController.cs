using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CombatController : MonoBehaviour
{
	public UnityEvent<MonInstance> OnSelected;
	//public List<GameObjectController> GameObjectControllers = new List<GameObjectController>();
	public ActionQueue ActionQueue;
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
		ActivePlayer = new PlayerCombatController("PlayerA", new List<string> { "PlayerB"});
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
		ActionQueue.AddToQueue(new ActionQueueEntry(SelectedMon, TargetMon, SelectedAbility));
	}
}
