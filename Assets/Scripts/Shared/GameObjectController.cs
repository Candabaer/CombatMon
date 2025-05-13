using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class GameObjectController : MonoBehaviour
{
	[Header("Monwerte")]
	[SerializeField]
	public Mon Mon;
	[SerializeField]
	public MonInstance MonInstance;

	[Header("Rest")]
	[SerializeField]
	Collider2D Collider;

	//[SerializeField]
	//public UnityEvent<MonInstance> OnSelected;

	private void Start()
	{
		this.MonInstance = new MonInstance(this.Mon);
		EventManager.Instance.Subscribe<MonDiedEvent>(MonDead);
	}

	private void MonDead(MonDiedEvent mon)
	{
		if (MonInstance == mon.DeadMon)
		{
			EventManager.Instance.Unsubscribe<MonDiedEvent>(MonDead);
			Destroy(this.gameObject);
		}
	}

	void OnMouseDown()
	{
		//OnSelected.Invoke(this.MonInstance);
		EventManager.Instance.Raise(new MonSelectedEvent(MonInstance, false));
	}

}
