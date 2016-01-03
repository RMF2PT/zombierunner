using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	private Rigidbody rigiBody;

	void Start () {
		rigiBody = GetComponent<Rigidbody>();
	}

	void OnDispatchHelicopter () {
		Debug.Log ("Helicopter called");
		rigiBody.velocity = new Vector3(0, 0, -50f);
	}
}
