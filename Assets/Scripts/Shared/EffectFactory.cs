using Assets.Scripts.Minions;
using System;

public static class EffectFactory
{
	public static EffectInstance CreateEffect(Effects effect)
	{
		switch (effect)
		{
			case ControlEffect controlEffect:
				return new ControlEffectInstance(controlEffect);
			case DamageOverTimeEffect dot:
				return new DamageOverTimeInstance(dot);
			default:
				throw new ArgumentException($"Unsupported effect type: {effect.GetType().Name}");
		}
	}

}
