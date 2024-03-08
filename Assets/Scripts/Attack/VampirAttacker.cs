using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VampirAttacker : BaseAttacker
{
    [SerializeField] private float _timeAttack = 6f;
    [SerializeField] private float _attackValueFactor = 6f;
    [SerializeField] private GameObject _visualArea;
    [SerializeField] private SpriteRenderer _visualAreaSprite;

    private Color _defaultAreaColor = Color.white;
    private Color _attackAreaColor = Color.magenta;

    private void Update()
    {
        if (IsIntentAttack == false && Input.GetIntentVampire())
        {
            StartAttack();
        }
    }

    protected override void StartAttack()
    {
        if (IsAttack)
        {
            return;
        }

        ChangeVisualArea(true);
        IsAttack = true;
        Coroutine = StartCoroutine(Attack(_timeAttack));
    }

    protected override void StoptAttack()
    {
        if (IsAttack == false)
        {
            return;
        }

        ChangeVisualArea(false);
        base.StoptAttack();
    }

    protected override IEnumerator Attack(float? maxTime)
    {
        var wait = new WaitForSeconds(0f);
        float time = 0f;

        while (time < maxTime)
        {
            time += Time.deltaTime;
            _visualAreaSprite.color = TargetHelths.Count == 0 ? _defaultAreaColor : _attackAreaColor;

            float attackValue = _attackValueFactor * Time.deltaTime;

            foreach (Health health in TargetHelths)
            {
                health.TakeDamage(attackValue);
                CharacterHealth.Heal(attackValue);
            }

            yield return wait;
        }

        StoptAttack();
    }

    private void ChangeVisualArea(bool on)
    {
        if (on)
        {
            _visualArea.SetActive(true);
        }
        else
        {
            _visualArea.SetActive(false);
            _visualAreaSprite.color = _defaultAreaColor;
        }
    }

}
