using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>())
            transform.GetComponentInParent<MoverEnemy>().Movement(collision.transform.position);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>())
            transform.GetComponentInParent<PatrollingEnemy>().enabled = true;
    }
}