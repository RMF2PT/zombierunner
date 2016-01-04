using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

	public float timeSinceLastTrigger = 0f;

	private bool foundClearArea = false;
	private BoxCollider boxCollider;
	private Vector3 initialSize;
	private Vector3 initialCenter;

	void Start () {
		boxCollider = GetComponent<BoxCollider>();
		initialSize = boxCollider.size;
		initialCenter = boxCollider.center;
	}

	void Update () {
		timeSinceLastTrigger += Time.deltaTime;
	}

	public void OnCheckClearArea () {
		boxCollider.size = new Vector3(20, 30, 30);
		boxCollider.center = new Vector3(0, 15, 0);

		if (timeSinceLastTrigger > 3f && Time.realtimeSinceStartup > 10f && !foundClearArea) {
			SendMessageUpwards ("OnFindClearArea");
			foundClearArea = true;
			boxCollider.size = initialSize;
			boxCollider.center = initialCenter;
		} else {
			SendMessageUpwards ("OnNotClearArea");
			boxCollider.size = initialSize;
			boxCollider.center = initialCenter;
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.tag != "Player") {
			timeSinceLastTrigger = 0f;
		}
	}
}