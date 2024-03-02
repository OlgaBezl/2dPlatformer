using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnPoin> _spawnPoints;
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
            ItemSpawnPoin spawnPoint = GetRandomPoin();

            if (spawnPoint.IsBusy == false)
            {
                Item item = Instantiate(spawnPoint.ItemPrefab, spawnPoint.transform.position, Quaternion.identity, transform);
                item.PickUped += PickUpItem;
                spawnPoint.AddICurrentItem(item);
            }

            yield return wait;
        }
    }

    private ItemSpawnPoin GetRandomPoin()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        return _spawnPoints[randomIndex];
    }

    private void PickUpItem(Item item)
    {
        item.PickUped -= PickUpItem;
        Destroy(item.gameObject);
    }
}
