using Assets.Scripts.Minions;
using System;
using System.Linq;
using UnityEngine;

public class ControlEffectInstance : EffectInstance
{
	public ControlEffectEnum Type;

	public ControlEffectInstance(ControlEffect effect) : base(effect)
	{
		Type = effect.Type;
	}

	public override void Apply(MonInstance source, MonInstance target)
	{
		if (target.AppliedEffects.
			OfType<ControlEffectInstance>().
			Any(e => e.Type == this.Type))
		{
			return;
		}
		target.AppliedEffects.Add(this);
	}

	protected override void Remove(MonInstance target)
	{
		var existing = target.AppliedEffects
			.OfType<ControlEffectInstance>()
			.FirstOrDefault(e => e.Type == this.Type);
		if (existing != null)
			target.AppliedEffects.Remove(existing);
	}

	public override void Tick(MonInstance target)
	{
		switch (Type)
		{
			case ControlEffectEnum.Sleep:
				//throw new System.NotImplementedException();
				if (UnityEngine.Random.Range(0, 101) < target.Stats.Body)
				{
					target.IsActive = false;
				}
				else
					Remove(target);
				break;
			case ControlEffectEnum.Freeze:

				break;
			case ControlEffectEnum.Flinch:
				target.IsActive = false;
				break;
			case ControlEffectEnum.Paralysis:
				if (UnityEngine.Random.Range(0, 101) < 50)
					target.IsActive = false;
				break;
			case ControlEffectEnum.Confusion:
				if (UnityEngine.Random.Range(0, 101) < 30)
				{
					target.LifePoints -= 10;
					target.IsActive = false;
				}
				break;
			default:
				throw new ArgumentException($"Type: {Type.ToString()} is not known");
		}
	}
}
