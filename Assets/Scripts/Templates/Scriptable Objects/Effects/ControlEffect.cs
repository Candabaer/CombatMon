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
		Sleep,      // Kann f�r einige Runden nicht angreifen
		Paralysis,  // Chance, nicht angreifen zu k�nnen, Geschwindigkeit gesenkt
		Freeze,     // Kann sich nicht bewegen, au�er durch spezielle Attacken
		Flinch,     // Pok�mon verliert seine Runde (z. B. durch Biss, Steinhagel)
		Confusion   // Pok�mon hat eine Chance, sich selbst zu verletzen
	}

}

