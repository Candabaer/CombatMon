using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	public static EventManager Instance { get ; private set; }
	[SerializeField]
	private Dictionary<System.Type, Delegate> EventTable = new();


	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void Subscribe<T>(Action<T> listener)
	{
		if (EventTable.TryGetValue(typeof(T), out var del))
			EventTable[typeof(T)] = Delegate.Combine(del, listener);
		else
			EventTable[typeof(T)] = listener;
	}

	public void Unsubscribe<T>(Action<T> listener)
	{
		if (EventTable.TryGetValue(typeof(T), out var del))
		{
			del = Delegate.Remove(del, listener);
			if (del == null)
				EventTable.Remove(typeof(T));
			else
				EventTable[typeof(T)] = del;
		}
	}

	public void Raise<T>(T evt)
	{
		if (EventTable.TryGetValue(typeof(T), out var del))
			((Action<T>)del)?.Invoke(evt);
	}
}