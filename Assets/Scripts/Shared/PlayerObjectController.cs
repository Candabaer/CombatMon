using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class GameObjectController : MonoBehaviour
{
    [SerializeField]
    public Mon Mon;

    [SerializeField]
    Collider2D Collider;

    [SerializeField]
    public UnityEvent<Mon> OnSelected;


	void OnMouseDown()
    {
        Debug.Log("LOLOLOL");
        OnSelected.Invoke(this.Mon);
    }

}
