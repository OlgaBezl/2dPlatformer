using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin();
            coin.Destroy();
        }
    }
}
