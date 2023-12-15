using UnityEngine;

public class Detector : MonoBehaviour
{
    private MoverEnemy _parentMoverEnemy;
    private PatrollingEnemy _parentPatrollingEnemy;

    private void Awake()
    {
        _parentMoverEnemy = GetComponentInParent<MoverEnemy>();
        _parentPatrollingEnemy = GetComponentInParent<PatrollingEnemy>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>())
            _parentMoverEnemy.Movement(collision.transform.position);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>())
            _parentPatrollingEnemy.enabled = true;
    }
}