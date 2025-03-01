using System.Collections.Generic;

public class Mon 
{
	public string Name;
	public string Description;
	public Stats Stats { get; set; }
	public List<Ability> Abilities { get; set; }
	public List<Type> Types { get; set; }
	public List<Effects> Effects { get; set; }
}
