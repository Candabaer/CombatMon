using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class ActionQueueEntry
{
	public MonInstance Source;
	public MonInstance Target;
	public AbilityInstance ChosenAbility;
	public int Speed => Source.Stats.Speed;
}

public class ActionQueue
{
	private List<ActionQueueEntry> Queue = new();

	public void AddToQueue(ActionQueueEntry item)
	{
		Queue.Add(item);
		Queue.Sort((a, b) => a.Speed.CompareTo(b.Speed));
	}
	public ActionQueueEntry Dequeue()
	{
		if (Queue.Count == 0)
		{
			throw new SystemException("Tried to dequeue from an empty queue.");
		}

		var item = Queue[0];
		Queue.RemoveAt(0);
		return item;
	}
	public IReadOnlyList<ActionQueueEntry> AllEntries => Queue;

	public ActionQueueEntry Peek()
	{
		return Queue.First();
	}
}
