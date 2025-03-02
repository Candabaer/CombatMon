using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMon", menuName = "Mon/Create New Mon")]
public class Mon : ScriptableObject
{
	public string Name;
	public string Description;
	public int LifePoints;
	[SerializeField] public Stats Stats { get; set; }
	[SerializeField] public List<Ability> Abilities { get; set; } = new List<Ability>(4);
	[SerializeField] public List<Type> Types { get; set; }
	[SerializeField] public List<Effects> Effects { get; set; }
}
