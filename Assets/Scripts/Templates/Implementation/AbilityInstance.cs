using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInstance : RuntimeInstance<Ability>
{
	public string Name;
	public string Description;
	public int UsagePoints;
	public int Power;
	public int Accuracy;

	public List<Type> Types;
	public List<Effects> Effects;

	public AbilityInstance(Ability abilities) : base(abilities)
	{
		Name = abilities.Name;
		Description = abilities.Description;
		UsagePoints = abilities.UsagePoints;
		Power = abilities.Power;
		Accuracy = abilities.Accuracy;
		Types = abilities.Types;
		Effects = abilities.Effects;
	}
	
	public void Apply(MonInstance source, MonInstance target)
	{
		Debug.Log($"{source.Name} macht {target.Name}, {Power} viel schaden");
		target.LifePoints -= Power;
	}
}
