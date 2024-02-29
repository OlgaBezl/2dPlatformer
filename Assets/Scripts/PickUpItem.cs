using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickUpItem : MonoBehaviour
{  
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
