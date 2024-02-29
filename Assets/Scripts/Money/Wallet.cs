using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Money { get; private set; }

    public void AddCoin()
    {
        Money++;
    }
}
