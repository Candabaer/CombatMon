using UnityEngine;

public interface ICombatPhase
{
	public CombatController CombatController { get; set; }

	void Enter(CombatController controller);
	void Exit();

}
