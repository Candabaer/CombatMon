using UnityEngine;

public abstract class RuntimeInstance<T> where T : ScriptableObject
{
	public T Template { get; set; }

	public RuntimeInstance(T template)
	{
		Template = template;
	}
}
