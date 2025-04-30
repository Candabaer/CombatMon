using UnityEngine;

namespace Assets.Scripts.Minions
{
	[System.Serializable]
	[CreateAssetMenu(fileName = "NewStatEffect", menuName = "Effects/Stats")]

	public class ControlEffect : Effects
	{
		public ControlEffectEnum Type { get; set; }
	}
	public enum ControlEffectEnum
	{
		None,       // Kein Bewegungsstatus aktiv
		Sleep,      // Kann für einige Runden nicht angreifen
		Paralysis,  // Chance, nicht angreifen zu können, Geschwindigkeit gesenkt
		Freeze,     // Kann sich nicht bewegen, außer durch spezielle Attacken
		Flinch,     // Pokémon verliert seine Runde (z. B. durch Biss, Steinhagel)
		Confusion   // Pokémon hat eine Chance, sich selbst zu verletzen
	}

}

