using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityInstance : RuntimeInstance<Ability>
{
	public string Name;
	public string Description;
	public int UsagePoints;
	public int Power;
	public int Accuracy;
	public List<Type> Types;
	public List<EffectInstance> Effects;

	public AbilityInstance(Ability ability) : base(ability)
	{
		Name = ability.Name;
		Description = ability.Description;
		UsagePoints = ability.UsagePoints;
		Power = ability.Power;
		Accuracy = ability.Accuracy;
		Types = ability.Types;
		Effects = new();

		foreach (Effects effect in ability.Effects)
		{
			Effects.Add(EffectFactory.CreateEffect(effect));
		}
	}

	public void Apply(MonInstance source, MonInstance target)
	{
		target.LifePoints -= Power;
		foreach(var e in Effects)
		{
			e.Apply(source, target);
		}
	}
}
