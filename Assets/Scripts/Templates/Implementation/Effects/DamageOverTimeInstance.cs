using Assets.Scripts.Minions;
using System;
using System.Linq;
using UnityEngine;

public class DamageOverTimeInstance : EffectInstance
{
	public int Damage;
	public int TurnsActive;
	public DamageOverTimeEnum Type;
	public int PoisonTicks;

	public DamageOverTimeInstance(DamageOverTimeEffect effect) : base(effect)
	{
		Damage = effect.Damage;
		TurnsActive = effect.TurnsActive;
		Type = effect.Type;
		PoisonTicks = 0;
	}

	public override void Apply(MonInstance source, MonInstance target)
	{
		if (target.AppliedEffects.
				OfType<DamageOverTimeInstance>().
				Any(e => e.Type == this.Type))
		{
			return;
		}
		target.AppliedEffects.Add(this);
	}

	protected override void Remove(MonInstance target)
	{
		throw new System.NotImplementedException();
	}

	public override void Tick(MonInstance target)
	{
		switch (Type)
		{
			case DamageOverTimeEnum.Burn:
				target.LifePoints -= Damage;
				break;
			case DamageOverTimeEnum.Poison:
				target.LifePoints -= (Damage * ++PoisonTicks);            
					break;
			case DamageOverTimeEnum.Curse:
#pragma warning disable CS0162 // Unreachable code detected
				throw new System.NotImplementedException();
				break;
			case DamageOverTimeEnum.BadPoison:
				throw new System.NotImplementedException();
				break;
#pragma warning restore CS0162 // Unreachable code detected
			case DamageOverTimeEnum.Nightmare:
				var sleepEffect = target.AppliedEffects.OfType<ControlEffectInstance>()
					.FirstOrDefault(e => e.Type == ControlEffectEnum.Sleep);
				if (sleepEffect != null)
				{
					target.LifePoints -= Damage;
				}
				break;
			default:
				throw new ArgumentException($"Type: {Type.ToString()} is not known");
		}
	}
}
