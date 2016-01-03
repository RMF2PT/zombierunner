using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

	public float timeSinceLastTrigger = 0f;

	void Start () {
	
	}

	void Update () {
		timeSinceLastTrigger += Time.deltaTime;

	}

	void OnTriggerStay () {
		timeSinceLastTrigger = 0f;
		Debug.Log ("Not enough space for heli");
	}
}
