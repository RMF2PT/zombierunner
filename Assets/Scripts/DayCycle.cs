﻿using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour {

	[Tooltip ("Number of minutes per second: try setting at 60")]
	public float minutesPerSecond;

	void Update () {
		float angleThisFrame = Time.deltaTime / 360 * minutesPerSecond;
		transform.RotateAround (transform.position, Vector3.forward, angleThisFrame);
	}
}
