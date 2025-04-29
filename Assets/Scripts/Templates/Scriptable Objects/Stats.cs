using UnityEngine;

[System.Serializable]
public class Stats
{
	public int Physical_Strength;
	public int Physical_Defense;
	public int Special_Strength;
	public int Special_Defense;

	public int Body;
	public int Speed;

	public Stats() { }

	public Stats(Stats stats)
	{
		Physical_Strength = stats.Physical_Strength;
		Physical_Defense = stats.Physical_Defense;
		Special_Strength = stats.Special_Strength;
		Special_Defense = stats.Special_Defense;
		Body = stats.Body;
		Speed = stats.Speed;
	}
}
