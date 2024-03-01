using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    public bool CoinSpawned { get; private set; }

    public Coin CoinPrefab => _coinPrefab;

    public void SetCoinSpawned(bool spawned)
    {
        CoinSpawned = spawned;
    }

}
