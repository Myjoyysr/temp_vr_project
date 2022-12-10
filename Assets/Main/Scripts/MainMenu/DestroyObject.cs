using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float lifetime = 2.2f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
