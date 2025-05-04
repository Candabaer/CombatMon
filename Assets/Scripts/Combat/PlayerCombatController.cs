using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCombatController
{
	public List<GameObjectController> PlayerMons = new();
	public List<GameObjectController> EnemyMons = new();
	public PlayerCombatController(string PlayerTag, List<string> EnemyPlayers)
	{
		var go = GameObject.FindGameObjectsWithTag(PlayerTag).ToList();
		foreach (var gameobject in go)
		{
			PlayerMons.Add(gameobject.GetComponent<GameObjectController>());
		}

		foreach (string enemy in EnemyPlayers)
		{
			var ego = GameObject.FindGameObjectsWithTag(enemy).ToList();

			foreach (var controller in ego)
			{
				EnemyMons.Add(controller.GetComponent<GameObjectController>());
			}
		}
	}
}
