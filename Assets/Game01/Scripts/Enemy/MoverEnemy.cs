using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[RequireComponent(typeof(PatrollingEnemy))]
public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PatrollingEnemy _patrollingEnemy;

    private void Start()
    {
        _patrollingEnemy = GetComponent<PatrollingEnemy>();
    }

    public void Movement(Vector2 target)
    {
        _patrollingEnemy.enabled = false;
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}