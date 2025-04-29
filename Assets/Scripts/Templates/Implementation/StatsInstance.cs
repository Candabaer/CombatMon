
public class StatsInstance 
{
	public int Physical_Strength;
	public int Physical_Defense;
	public int Special_Strength;
	public int Special_Defense;

	public int Body;
	public int Speed;
	public StatsInstance(Stats template)
	{
		Physical_Strength = template.Physical_Strength;
		Physical_Defense = template.Physical_Defense;
		Special_Strength = template.Special_Strength;
		Special_Defense = template.Special_Defense;
		Body = template.Body;
		Speed = template.Speed;
	}
}
