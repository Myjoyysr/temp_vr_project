using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SpatialTracking;

public class MoveWithHandTwo : MonoBehaviour
{
    public XRNode control;
    public GameObject raycast;
    public GameObject hand;
    public TrackedPoseDriver driver;


    private Vector3 inputAxis;
    private Vector3 rotation;
    private bool trigger;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(control);
        rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out trigger);

        //Debug.Log(trigger);
        //Debug.Log(inputAxis);

        if (trigger)
        {
            if (startTime == 0)
            {
                startTime = Time.time;
            }
            //Debug.Log(startTime);


            if (trigger && (Time.time - startTime > 0.3f))
            {
                inputAxis = hand.transform.position;
                rotation = hand.transform.eulerAngles;

                driver.enabled = false;
                raycast.SetActive(false);

                transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
                transform.position = new Vector3(inputAxis.x, inputAxis.y, inputAxis.z);
            }
        }

        else
        {
            startTime = 0;
            transform.localPosition = new Vector3(0f, 0f, 0f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            driver.enabled = true;
            raycast.SetActive(true);
        }
    }
}

