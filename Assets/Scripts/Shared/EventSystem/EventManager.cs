using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	private static EventManager _instance = new();
	public static EventManager Instance => _instance;

	private Dictionary<System.Type, Delegate> eventTable = new();

	public void Subscribe<T>(Action<T> listener)
	{
		if (eventTable.TryGetValue(typeof(T), out var del))
			eventTable[typeof(T)] = Delegate.Combine(del, listener);
		else
			eventTable[typeof(T)] = listener;
	}

	public void Unsubscribe<T>(Action<T> listener)
	{
		if (eventTable.TryGetValue(typeof(T), out var del))
		{
			del = Delegate.Remove(del, listener);
			if (del == null)
				eventTable.Remove(typeof(T));
			else
				eventTable[typeof(T)] = del;
		}
	}

	public void Raise<T>(T evt)
	{
		if (eventTable.TryGetValue(typeof(T), out var del))
			((Action<T>)del)?.Invoke(evt);
	}
}