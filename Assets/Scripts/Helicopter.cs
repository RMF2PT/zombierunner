using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	public AudioClip callSound;

	private bool called = false;
	private AudioSource audioSource;
	private Rigidbody rigiBody;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		rigiBody = GetComponent<Rigidbody>();
	}

	public void Call () {
		if (!called) {
			called = true;
			Debug.Log ("Helicopter called");
			audioSource.clip = callSound;
			audioSource.Play();
			rigiBody.velocity = new Vector3(0, 0, -50f);
		}
	}
}
