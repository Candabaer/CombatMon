using System.Collections.Generic;

public class Ability
{
	public string Name;
	public string Description;
	public int UsagePoints;
	public int Power;
	public int Accuracy;
	public List<Type> Types = new();
	public List<Effects> Effects = new();


	public Ability()
	{

	}

}
