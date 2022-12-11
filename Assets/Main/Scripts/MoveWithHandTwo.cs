using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SpatialTracking;

public class MoveWithHandTwo : MonoBehaviour
{
    public XRNode control;
    public Camera mainCamera;
    public GameObject hand;
    public TrackedPoseDriver driver;

    private Vector3 inputAxis;
    private Vector3 cameraPosition;
    private Vector3 cameraRotation;
    private Vector3 rotation;
    private bool trigger;

    // Start is called before the first frame update
    void Start()
    {
        driver.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(control);
        rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out trigger);

        Debug.Log(trigger);
        Debug.Log(inputAxis);

        if (trigger) {
            inputAxis = hand.transform.position;
            rotation = hand.transform.eulerAngles;

            cameraPosition = mainCamera.transform.localPosition;
            cameraRotation = mainCamera.transform.eulerAngles;

            driver.enabled = false;

            transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
            transform.position = new Vector3(inputAxis.x, inputAxis.y, inputAxis.z);
        }

        else {
            transform.localPosition = new Vector3(0f, 0f, 0f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            driver.enabled = true;
        }
    }
}
