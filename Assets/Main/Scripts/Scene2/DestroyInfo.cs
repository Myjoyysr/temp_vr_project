using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInfo : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.tag == "Player"){
            Debug.Log("Player ENter");
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit COLLISION");
        if (other.tag == "Player"){
            Destroy (GameObject.Find("Info 0"));
        }
    }
}
