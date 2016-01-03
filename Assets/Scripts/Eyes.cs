using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

	private Camera eyes;
	private float defaultFOV;
	private float zoom = 1.5f;

	void Start () {
		eyes = GetComponent<Camera>();
		defaultFOV = eyes.fieldOfView;
	}

	void Update () {
		if (Input.GetButton("Zoom")) {
			eyes.fieldOfView = (defaultFOV / zoom);
		} else {
			eyes.fieldOfView = defaultFOV;
		}
	}
}
