using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
