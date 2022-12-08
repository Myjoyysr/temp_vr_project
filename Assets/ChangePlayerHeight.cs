using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangePlayerHeight : MonoBehaviour
{

    public XRNode inputSource;
    private Vector2 inputAxis;

    public float sensitivityY = 0.1F;
    public float minimumY = 0F;
    public float maximumY = 10F;

    private float heightChange = 0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        heightChange += inputAxis.y * sensitivityY;
        heightChange = Mathf.Clamp (heightChange, minimumY, maximumY);

		transform.localPosition = new Vector3(0, heightChange, 0);

    }
}
