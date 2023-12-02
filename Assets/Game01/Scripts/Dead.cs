using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private void Start()
    {
        int lifetime = 1;
        Destroy(gameObject, lifetime);
    }
}