using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackValue = 10f;
    [SerializeField] private float _cooldown = 3f;

    private Coroutine _coroutine;

    public bool IsAttack {  get; private set; }

    public void TryAttack(Health health)
    {
        Debug.Log("TryAttack");
        if (IsAttack == false)
        {
            IsAttack = true;
            _coroutine = StartCoroutine(Attack(health));
        }
    }

    public void StopAttack()
    {
        Debug.Log("StopAttack");
        IsAttack = false;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator Attack(Health health)
    {
        var wait = new WaitForSeconds(_cooldown);

        while (IsAttack)
        {
            health.TakeDamage(_attackValue);
            yield return wait;
        }
    }
}
