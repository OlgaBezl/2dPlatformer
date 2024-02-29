using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<CoinSpawnPoint> _spawnPoints;
    [SerializeField] private float _spawnDelay = 2f;

    private System.Random _random;

    private void Start()
    {
        _random = new System.Random();
        InvokeRepeating(nameof(Spawn), 0, _spawnDelay);
    }

    private void Spawn()
    {
        CoinSpawnPoint spawnPoint = GetRandomPoin();
        Instantiate(spawnPoint.CoinPrefab, spawnPoint.transform.position, Quaternion.identity, transform);
    }

    private CoinSpawnPoint GetRandomPoin()
    {
        int randomIndex = _random.Next(0, _spawnPoints.Count);
        return _spawnPoints[randomIndex];
    }
}
