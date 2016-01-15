using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Helicopter : MonoBehaviour {

	private Rigidbody rigiBody;
	private Scene activeScene;
	private bool inInitialMenu = false;
	private Vector3 initialPosition;

	void Start () {
		rigiBody = GetComponent<Rigidbody>();
		activeScene = SceneManager.GetActiveScene();
		initialPosition = transform.position;
	}

	void Update () {
		if (activeScene.buildIndex == 0) inInitialMenu = true;

		if (transform.position.z > 1000f && inInitialMenu) {
			float randXPosition = Random.Range(0f, 250f);
			transform.position = new Vector3(randXPosition, initialPosition.y, initialPosition.z - 8000f);
		}

		if (inInitialMenu) {
			rigiBody.velocity = new Vector3(0, 0, -50f);
			if (transform.position.z < -1000f) {
				transform.position = initialPosition;
			}
		}
	}

	void OnDispatchHelicopter () {
		Debug.Log ("Helicopter called");
		rigiBody.velocity = new Vector3(0, 0, -50f);
	}
}
