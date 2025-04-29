using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMon", menuName = "Mon/Create New Mon")]
public class Mon : ScriptableObject
{
	public string Name;
	public string Description;
	public int LifePoints;
	public bool IsActive = false;
	public int SortOrder;

	private int LP;

	public void GetAttacked(Ability ability)
	{
		LP = LifePoints;
		Debug.Log($"I'm getting hurt {LP}");
		LP -= ability.Power;
		Debug.Log($"I'm GOTTING hurt {LP}");
	}

	public Stats Stats = new Stats();
	public List<Ability> Abilities  = new List<Ability>(4);
	public List<Type> Types  = new();
	public List<Effects> Effects  = new();
}
