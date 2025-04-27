using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Ability/Create New")]
[System.Serializable]
public class Ability : ScriptableObject
{
	public string Name;
	public string Description;
	public int UsagePoints;
	public int Power;
	public int Accuracy;
	public List<Type> Types;
	public List<Effects> Effects;

	public Ability()
	{

	}

	internal void Apply(List<Mon> Target)
	{
		throw new System.NotImplementedException();
	}
}
