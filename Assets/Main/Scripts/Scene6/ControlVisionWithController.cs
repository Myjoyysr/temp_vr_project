using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVisionWithController : MonoBehaviour
{
    private bool onController;

    public GameObject cam;
    public GameObject controller;

    private Vector3 rotation;

    void Start()
    {
        onController = true;
    }

    void Update()
    {
        if(onController == true){
            rotation = new Vector3(controller.transform.eulerAngles.x, controller.transform.eulerAngles.y, controller.transform.eulerAngles.z);
            cam.transform.eulerAngles = rotation;
            cam.transform.position = controller.transform.position;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("test");
        if (other.tag == "ControllerCollider"){
            if (onController == true){
                onController = false;
                Debug.Log("Set false");
            }
            else{
                onController = true;
                Debug.Log("Set true");
            }
        }
    }
}
