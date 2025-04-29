using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCombatController
{
	List<Mon> Squad = new(6);

	public List<Mon> GetInactive()
	{
		return Squad.Where(s => !s.IsActive && s.LifePoints > 0).ToList();
	}
	public List<Mon> GetActive()
	{
		return Squad.Where(s => s.IsActive).ToList();
	}


	public void Switch(int activeIndex, int inactiveIndex)
	{
		Squad[activeIndex].IsActive = false;
		Squad[inactiveIndex].IsActive = true;
		var tmp = Squad[activeIndex];
		Squad[activeIndex] = Squad[inactiveIndex];
		Squad[inactiveIndex] = tmp;
	}

	//public void Attack(int index, int ability, List<Mon> targets)
	//{
	//	if (Squad[index].IsActive)
	//	{
	//		Squad[index].Abilities[ability].Apply(targets);
	//	}
	//}

	public void StartCombat()
	{
		for (int i = 0; i < 3; i++)
		{
			Squad[i].IsActive = true;
		}
	}

	public void Retreat()
	{

	}
}
