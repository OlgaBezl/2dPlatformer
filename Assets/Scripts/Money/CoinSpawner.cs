using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<CoinSpawnPoint> _spawnPoints;
    [SerializeField] private float _spawnDelay = 2f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            CoinSpawnPoint spawnPoint = GetRandomPoin();

            if(spawnPoint.CoinSpawned == false)
            {
                Instantiate(spawnPoint.CoinPrefab, spawnPoint.transform.position, Quaternion.identity, transform);
                spawnPoint.SetCoinSpawned(true);
            }

            yield return wait;
        }
    }

    private CoinSpawnPoint GetRandomPoin()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        return _spawnPoints[randomIndex];
    }
}
