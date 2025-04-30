using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewDebuffEffect", menuName = "Effects/Debuff")]
public class DamageOverTimeEffect : Effects
{
	public int Damage;
	public int TurnsActive;
	public DamageOverTimeEnum Type;
}

public enum DamageOverTimeEnum
{
	None,        // Kein DoT-Effekt aktiv
	Burn,        // Verliert KP pro Runde, senkt Angriff (Feuer)
	Poison,      // Verliert KP pro Runde (Gift)
	BadPoison,   // Toxische Vergiftung, Schaden steigt jede Runde (Toxin)
	Curse,       // Verliert jede Runde KP (Geist-Typ F‰higkeit)
	Nightmare,   // Verliert KP jede Runde, nur wenn das PokÈmon schl‰ft
	LeechSeed,   // Egelsamen, verliert KP und heilt den Gegner
	Sandstorm,   // Schaden am Ende der Runde (auﬂer Boden, Gestein, Stahl)
	Hail         // Hagelschaden am Ende der Runde (auﬂer Eis-Typen)
}