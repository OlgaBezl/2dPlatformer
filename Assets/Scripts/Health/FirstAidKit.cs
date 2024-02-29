using UnityEngine;

public class FirstAidKit : PickUpItem
{
    [SerializeField] private float _heal;

    public float HealValue => _heal;
}
