public class MonDiedEvent
{
	public MonInstance DeadMon { get; }

	public MonDiedEvent(MonInstance mon)
	{
		DeadMon = mon;
	}
}