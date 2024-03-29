using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FirstAidKitCollector : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out FirstAidKit kit))
        {
            _health.Heal(kit.Heal);
            kit.PickUp();
        }
    }
}
