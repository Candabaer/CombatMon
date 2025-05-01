using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CombatState
{
	WaitingForCharacter,
	WaitingForAbility,
	WaitingForTarget,
	PerformingAction,
	EnemyTurn,
	Victory,
	Defeat
}

public class CombatController : MonoBehaviour
{
	public UnityEvent<MonInstance> OnSelected;
	private int TurnCounter = 0;
	private MonInstance SelectedMon;
	private MonInstance TargetMon;
	private AbilityInstance SelectedAttack;
	private CombatState currentState = CombatState.WaitingForCharacter;
	[SerializeField]
	private CombatUI CombatUI;


	private void Awake()
	{
		CombatUI.OnSelectedAttack.AddListener(OnAttackSelected);
	}

	void Start()
	{
	}

	public void OnCharacterSelected(MonInstance selectedMon)
	{
		if (currentState != CombatState.WaitingForCharacter)
			return;
		SelectedMon = selectedMon;
		OnSelected.Invoke(selectedMon);
		currentState = CombatState.WaitingForAbility;
	}

	public void OnAttackSelected(AbilityInstance selectedAttack)
	{
		if (currentState != CombatState.WaitingForAbility)
			return;
		Debug.Log($"attack selected {selectedAttack.Name}");
		SelectedAttack = selectedAttack;
		currentState = CombatState.WaitingForTarget;
	}

	public void OnTargetSelected(MonInstance targetMon)
	{
		if (currentState != CombatState.WaitingForTarget)
			return;
		Debug.Log($"Target selected {targetMon.Name}");
		SelectedAttack.Apply(SelectedMon, targetMon);
		currentState = CombatState.PerformingAction;
	}


	// Update is called once per frame
	void Update()
	{



	}
}
