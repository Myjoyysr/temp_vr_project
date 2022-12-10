using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertVision : MonoBehaviour
{

    public InputActionProperty leftActivate;
    private bool rotated;
    private float zRotation;

    // Start is called before the first frame update
    void Start()
    {
        rotated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftActivate.action.ReadValue<float>() > 0.1f) {
            if (rotated)
                zRotation = 180F;
            else
        zRotation = 0; // 0 degrees

            transform.rotation = Quaternion.Euler (0, 0, zRotation);
            rotated= !rotated;
        }
    }
}
