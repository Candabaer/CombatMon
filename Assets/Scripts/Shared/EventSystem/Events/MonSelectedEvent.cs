public class MonSelectedEvent
{
	public MonInstance SelectedMon { get; }
	public bool AsAttackTarget { get; }

	public MonSelectedEvent(MonInstance mon, bool asAttackTarget)
	{
		SelectedMon = mon;
		AsAttackTarget = asAttackTarget;
	}
}