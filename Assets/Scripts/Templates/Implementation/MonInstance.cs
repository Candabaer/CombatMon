using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonInstance : RuntimeInstance<Mon>
{
	public string Name;
	public string Description;
	public int LifePoints;
	public bool IsActive = false;
	public int SortOrder;

	public Stats Stats;
	public List<AbilityInstance> Abilities = new List<AbilityInstance>(4);
	public List<TypeInstance> Types = new();
	public List<EffectInstance> AppliedEffects = new();


	public MonInstance(Mon template) : base(template)
	{
		Name = template.Name;
		Description = template.Description;
		LifePoints = template.LifePoints;
		IsActive = template.IsActive;
		SortOrder = template.SortOrder;

		Stats = new Stats(template.Stats);
		foreach (var a in template.Abilities)
			Abilities.Add(new AbilityInstance(a));

		foreach (var a in template.Types)
			Types.Add(new TypeInstance(a));

		foreach (var a in template.Effects)
			AppliedEffects.Add(new EffectInstance(a));

	}

	public void GetAttacked(Ability ability)
	{
		Debug.Log($"I'm getting hurt {LifePoints}");
		LifePoints -= ability.Power;
		Debug.Log($"I'm GOTTING hurt {LifePoints}");
	}
}
