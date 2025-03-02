using UnityEngine;
public interface Effects
{
	public string Name { get; set; }
	public string Description {  get; set; }

	public void ApplyEffect();
}
