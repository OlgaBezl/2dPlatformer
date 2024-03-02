using UnityEngine;

public class ItemSpawnPoin : MonoBehaviour
{
    [field: SerializeField] public Item ItemPrefab { get; private set; }

    public Item CurrentItem { get; private set; }
    public bool IsBusy => CurrentItem != null;

    public void AddICurrentItem(Item item)
    {
        CurrentItem = item;
        CurrentItem.PickUped += RemoveCurrentItem;
    }

    private void RemoveCurrentItem(Item item)
    {
        CurrentItem = null;
    }
}
