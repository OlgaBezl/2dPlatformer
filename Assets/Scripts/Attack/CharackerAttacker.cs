using System;
using System.Collections;
using UnityEngine;

public class CharackerAttacker : BaseAttacker
{
    [SerializeField] protected float AttackValue = 1f;

    public event Action<bool> Attacking;

    protected override void MeetTarget(Health targetHealth)
    {
        if (targetHealth.IsAlive == false)
        {
            return;
        }

        base.MeetTarget(targetHealth);
        StartAttack();
    }

    protected override void BreakUpWithTarget(Health targetHealth)
    {
        base.BreakUpWithTarget(targetHealth);
        
        if(TargetHelths.Count == 0)
        {
            StoptAttack();
        }
    }

    protected override void StartAttack()
    {
        if (IsAttack)
        {
            return;
        }

        IsAttack = true;
        Attacking?.Invoke(true);
        Coroutine = StartCoroutine(Attack());
    }

    protected override IEnumerator Attack(float? maxTime = null)
    {
        var wait = new WaitForSeconds(Cooldown);

        while (IsAttack)
        {
            foreach (Health health in TargetHelths)
            {
                health.TakeDamage(AttackValue);
            }

            yield return wait;
        }

        StoptAttack();
    }

    protected override void StoptAttack()
    {
        Attacking?.Invoke(false);
        base.StoptAttack();
    }
}
