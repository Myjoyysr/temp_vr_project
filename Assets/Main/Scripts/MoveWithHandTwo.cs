using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveWithHandTwo : MonoBehaviour
{
    public XRNode control;
    public Camera mainCamera;
    public GameObject hand;

    private Vector3 inputAxis;
    private Vector3 cameraPosition;
    private Vector3 cameraRotation;
    private Vector3 rotation;
    private bool trigger;

    // Start is called before the first frame update
    void Start()
    {

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

            //transform.position = new Vector3((inputAxis.x - cameraPosition.x), (inputAxis.y - cameraPosition.y), (inputAxis.z - cameraPosition.z));
            transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
            transform.position = new Vector3(inputAxis.x, (inputAxis.y - 1.25f), inputAxis.z);
            //transform.eulerAngles = new Vector3((rotation.x - cameraRotation.x), (rotation.y - cameraRotation.y), (rotation.z - cameraRotation.z));
        }

        else {
            transform.localPosition = new Vector3(0f, 0f, 0f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
