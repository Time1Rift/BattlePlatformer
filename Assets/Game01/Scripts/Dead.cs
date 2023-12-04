using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private void Start()
    {
        float lifetime = 1f;
        Destroy(gameObject, lifetime);
    }
}