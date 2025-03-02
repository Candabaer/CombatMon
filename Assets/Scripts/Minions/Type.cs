using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewType", menuName = "Type/New")]

public class Type : ScriptableObject
{
    public TypeEnum Name;
    public List<TypeEnum> Weakness;
    public List<TypeEnum> Strength;
}

public enum TypeEnum
{
	Normal,
	Fire,
	Water,
	Grass,
	Electric,
	Ice,
	Fighting,
	Poison,
	Ground,
	Flying,
	Psychic,
	Bug,
	Rock,
	Ghost,
	Dragon,
	Dark,
	Steel,
	Fairy
}