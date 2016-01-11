using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

	private Camera eyes;
	private float defaultFOV;
	private float zoom = 1.5f;
	private Vector3 initialCameraPosition;
	private bool hasSeenExplosion = false;
	private float shakeCamera = 0f;

	void Start () {
		eyes = GetComponent<Camera>();
		defaultFOV = eyes.fieldOfView;
		initialCameraPosition = eyes.transform.localPosition;
	}

	void Update () {
		if (Input.GetButton("Zoom")) {
			eyes.fieldOfView = (defaultFOV / zoom);
		} else {
			eyes.fieldOfView = defaultFOV;
		}

		if(shakeCamera > 0) {
			eyes.transform.localPosition = initialCameraPosition + Random.insideUnitSphere;
			shakeCamera -= Time.deltaTime;
		}
	}

	void OnTriggerEnter (Collider other) {
		if(other.tag == "HelicopterCrashed" && !hasSeenExplosion) {
			hasSeenExplosion = true;
			shakeCamera = 1f;
		}
	}
}
