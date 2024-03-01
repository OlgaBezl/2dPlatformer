using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{  
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
