using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	public AudioClip callSound;

	private bool called = false;
	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("CallHeli") && !called) {
			called = true;
			audioSource.clip = callSound;
			audioSource.Play();
			Debug.Log ("Helicopter called");
		}
	}
}
