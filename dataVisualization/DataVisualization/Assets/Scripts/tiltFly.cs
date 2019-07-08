using UnityEngine;
using System.Collections;

public class tiltFly : MonoBehaviour {
	float roll = 0;
	Quaternion referenceRotation;
	Quaternion deviceRotation;
	Quaternion eliminationOfXY;
	Quaternion rotationZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		referenceRotation = Quaternion.identity;
		deviceRotation = DeviceRotation.Get();
		eliminationOfXY = Quaternion.Inverse(
			Quaternion.FromToRotation(referenceRotation * Vector3.forward, 
		                          deviceRotation * Vector3.forward)
			);
		rotationZ = eliminationOfXY * deviceRotation;

		roll = rotationZ.eulerAngles.z;
	}
}
