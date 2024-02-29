using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    public Coin CoinPrefab => _coinPrefab;
}
