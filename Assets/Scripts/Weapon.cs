using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	private Animator anim;
	private AudioSource audioSource;

	void Start () {
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.timeScale != 0) {
			anim.SetTrigger("Shooting");
			audioSource.Play();
		}

		if (Time.timeScale == 0) {
			audioSource.Pause();
		}
	}
}
