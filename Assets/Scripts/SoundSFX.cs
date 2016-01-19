using UnityEngine;
using System.Collections;

public class SoundSFX : MonoBehaviour {

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			audioSource.Play();
		}

		if (Time.timeScale == 0) {
			audioSource.Pause();
		}
	}
}
