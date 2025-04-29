using UnityEngine;

public class EffectInstance : RuntimeInstance<Effects>
{
	public string Name;
	public string Description;

	public EffectInstance(Effects effect) : base(effect)
	{
		Name = effect.Name;
		Description = effect.Description;
	}

}
