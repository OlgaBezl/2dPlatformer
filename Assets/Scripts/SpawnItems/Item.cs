using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    public event Action<Item> PickUped;

    public void PickUp()
    {
        PickUped?.Invoke(this);
    }
}
