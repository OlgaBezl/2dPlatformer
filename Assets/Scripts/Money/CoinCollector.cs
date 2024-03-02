using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin();
            coin.PickUp();
        }
    }
}
