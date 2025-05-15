public class AbilitySelectedEvent
{
	public AbilityInstance SelectedAbility { get; }

	public AbilitySelectedEvent(AbilityInstance selectedAbility)
	{
		SelectedAbility = selectedAbility;
	}
}