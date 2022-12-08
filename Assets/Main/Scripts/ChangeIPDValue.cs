using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeIPDValue : MonoBehaviour
{
    public XRNode inputSource;
    private Vector2 inputAxis;

    public float sensitivityX = 0.1F;

    private float ipdChange = 1F;

    private float minimumX = 0.5F;
    private float maximumX = 1.5F;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        ipdChange += inputAxis.x * sensitivityX;
        ipdChange = Mathf.Clamp (ipdChange, minimumX, maximumX);

		transform.localScale = new Vector3(ipdChange, 1, ipdChange);

    }
}
