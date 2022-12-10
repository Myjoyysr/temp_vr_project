using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{
    public Transform controller;
    public Transform spawnPoint;
    public GameObject item;
    public float throwCooldown;
    public KeyCode keypress = KeyCode.Space;
    public float throwForce;
    public float throwUpwardForce;
    bool canThrow;

    public InputActionProperty rightGrab;

    void Start()
    {
        canThrow = true;
    }

    void Update()
    {
        //if(Input.GetKeyDown(keypress) && canThrow){
        if((Input.GetKeyDown(keypress)) || (rightGrab.action.ReadValue<float>() > 0.1f) && canThrow){
            ThrowBall();
        }
    }

    public void ThrowBall(){
        canThrow = false;
        GameObject projectile = Instantiate(item, spawnPoint.position,spawnPoint.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        Vector3 forceToAdd = spawnPoint.transform.forward * throwForce + transform.up * throwUpwardForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow(){
        canThrow = true;
    }
}
