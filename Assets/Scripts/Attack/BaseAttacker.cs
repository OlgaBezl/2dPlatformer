using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseAttacker : MonoBehaviour
{
    [SerializeField] protected float Cooldown = 0f;
    [SerializeField] protected LayerMask TargetLayerMask;
    [SerializeField] protected Health CharacterHealth;

    protected Coroutine Coroutine;
    protected CustomInput Input;
    protected List<Health> TargetHelths;
    protected bool IsIntentAttack;

    public bool IsAttack { get; protected set; }

    protected void Start()
    {
        Input = new CustomInput();
        TargetHelths = new List<Health>();
    }

    protected void OnEnable()
    {
        CharacterHealth.Died += DisableComponent;
    }

    protected void OnDisable()
    {
        CharacterHealth.Died -= DisableComponent;
        CharacterHealth.Died -= StoptAttack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckIfCollisionInTargetLayer(collision))
        {
            if (collision.TryGetComponent(out Health health))
            {
                MeetTarget(health);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CheckIfCollisionInTargetLayer(collision))
        {
            if (collision.TryGetComponent(out Health health))
            {
                BreakUpWithTarget(health);
            }
        }
    }

    protected virtual void MeetTarget(Health targetHealth)
    {
        if(targetHealth.IsAlive == false)
        {
            return;
        }

        TargetHelths.Add(targetHealth);
        targetHealth.Died += RemoveDeadTargetsFromList;
    }
    
    protected virtual void BreakUpWithTarget(Health targetHealth)
    {
        TargetHelths.Remove(targetHealth);
    }

    protected virtual void StartAttack()
    {
        if(IsAttack)
        {
            return;
        }

        IsAttack = true;
        Coroutine = StartCoroutine(Attack());
    }

    protected virtual void StoptAttack()
    {
        StopCoroutine(Coroutine);
        IsAttack = false;
    }

    protected abstract IEnumerator Attack(float? maxTime = null);
  
    protected void DisableComponent()
    {
        OnDisable();
        GetComponent<Collider2D>().enabled = false;
    }

    protected bool CheckIfCollisionInTargetLayer(Collider2D collision)
    {
        return 1 << collision.gameObject.layer == TargetLayerMask.value;
    }

    protected void RemoveDeadTargetsFromList()
    {
        TargetHelths = TargetHelths.Except(TargetHelths.Where(target => target.IsAlive == false)).ToList();
    }
}
