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

	public ActionQueueEntry(MonInstance source, MonInstance target, AbilityInstance chosenAbility)
	{
		Source = source;
		Target = target;
		ChosenAbility = chosenAbility;
	}

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
		var x = Queue.FirstOrDefault();
		return x;
	}

	public bool QueueFull(List<GameObjectController> gameObjectControllers)
	{

		var q = new HashSet<MonInstance>(Queue.Select(q => q.Source));
		foreach (var item in gameObjectControllers)
		{
			if (!q.Contains(item.MonInstance))
				return false;
		}
		return true;
	}
}
