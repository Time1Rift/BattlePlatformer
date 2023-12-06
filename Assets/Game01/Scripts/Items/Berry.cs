using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    public bool _isUsed { get; private set; } = false;

    public void Use() => _isUsed = true;
}