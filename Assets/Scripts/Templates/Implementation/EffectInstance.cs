using UnityEngine;

public abstract class EffectInstance : RuntimeInstance<Effects>
{
	public string Name;
	public string Description;
	public int Duration;

	public EffectInstance(Effects effect) : base(effect)
	{
		Name = effect.Name;
		Duration = effect.Duration;
		Description = effect.Description;
	}

	public abstract void Apply(MonInstance source, MonInstance target);
	public abstract void Tick(MonInstance target);
	protected abstract void Remove(MonInstance target);
}
