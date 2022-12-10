using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVisionWithController : MonoBehaviour
{
    private bool onController;

    void Start()
    {
        onController = false;
    }

    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other.tag == "Player"){
            Debug.Log("Set false");
            if (onController == true){
                onController = false;
                Debug.Log("Set false");
            }
            else{
                onController = true;
                Debug.Log("Set true");
            }
        }
        if(other.tag == "Box1"){
            Debug.Log("test1)");
        }
    }
}
