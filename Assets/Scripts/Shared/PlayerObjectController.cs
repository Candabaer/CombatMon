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

	[SerializeField]
	public UnityEvent<MonInstance> OnSelected;

	private void Awake()
	{
		this.MonInstance = new MonInstance(this.Mon);
	}

	void OnMouseDown()
	{
		Debug.Log("LOLOLOL");
		OnSelected.Invoke(this.MonInstance);
	}

}
