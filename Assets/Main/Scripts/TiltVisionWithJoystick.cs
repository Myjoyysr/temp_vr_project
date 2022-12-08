using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TiltVisionWithJoystick : MonoBehaviour
{
    public XRNode inputSource;
    private Vector2 inputAxis;

    public float sensitivityX = 0.1F;
	public float sensitivityY = 0.1F;

	public float minimumY = -60F;
	public float maximumY = 60F;

    float rotationY = 0F;

    // Start is called before the first frame update
    void Start()
    {
        // Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        float rotationX = transform.localEulerAngles.y + inputAxis.x * sensitivityX;
			
		rotationY += inputAxis.y * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		
    }
}
